# AyBorg.Types

## Creating a step plugin

AyBorg’s `IStepBody` interface is the primary means of extending AyBorg’s functionality.

### Understanding the IStepBody interface

The `IStepBody` interface is central to creating a new plugin in AyBorg. The interface ensures that your plugin has a `TryRunAsync` method that the AyBorg system can call when it’s time to execute your step. It also requires that your plugin defines its Name and Ports. Here’s the interface structure:

```csharp
public interface IStepBody
{
    string Name { get; }
    IEnumerable<IPort> Ports { get; }
    ValueTask<bool> TryRunAsync(CancellationToken cancellationToken);
}
```

### Creating a new step

To create a new step, you will need to create a new class that implements the `IStepBody` interface. We’ll take the ImageScale class as a case study.

#### Step 1: Define your class

Your class should implement the `IStepBody` interface and optionally IDisposable if it requires cleanup after use. It should also include several `IPort` fields, representing inputs and outputs of your step. Here’s the class definition:

```csharp
public sealed class ImageScale : IStepBody, IDisposable
{
    private readonly ImagePort _imagePort = new("Image", PortDirection.Input, null!);
    private readonly ImagePort _scaledImagePort = new("Scaled image", PortDirection.Output, null!);
    private readonly NumericPort _widthPort = new("Width", PortDirection.Output, 0);
    private readonly NumericPort _heightPort = new("Height", PortDirection.Output, 0);
    private readonly NumericPort _scalePort = new("Scale factor", PortDirection.Input, 0.5d, 0.01d, 2d);
    private bool _disposedValue;

    public string Name => "Image.Scale";

    public IReadOnlyCollection<string> Categories { get; } = new List<string> { DefaultStepCategories.ImageProcessing };

    public IEnumerable<IPort> Ports { get; }

    public ImageScale()
    {
        Ports = new List<IPort>
        {
            _imagePort,
            _scaledImagePort,
            _widthPort,
            _heightPort,
            _scalePort
        };
    }
    // ...
}
```

#### Step 2: Implement the TryRunAsync method

The `TryRunAsync` method is where the main logic of your plugin will reside. For our ImageScale example, this method scales an image to a certain size:

```csharp
public ValueTask<bool> TryRunAsync(CancellationToken cancellationToken)
{
    _scaledImagePort.Value?.Dispose();
    Image sourceImage = _imagePort.Value;
    if (_scalePort.Value.Equals(1d))
    {
        _scaledImagePort.Value = sourceImage;
        return ValueTask.FromResult(true);
    }

    int w = (int)(sourceImage.Width * _scalePort.Value);
    int h = (int)(sourceImage.Height * _scalePort.Value);
    _scaledImagePort.Value = sourceImage.Resize(w, h);
    _widthPort.Value = w;
    _heightPort.Value = h;
    return ValueTask.FromResult(true);
}
```

#### Step 3: Implement the Dispose method (Optional)

If your plugin acquires resources that need to be released, it should implement the `IDisposable` interface and its `Dispose` method:

```csharp
public void Dispose()
{
    Dispose(disposing: true);
    GC.SuppressFinalize(this);
}

private void Dispose(bool disposing)
{
    if (!_disposedValue && disposing)
    {
        _scaledImagePort?.Dispose();
        _disposedValue = true;
    }
}
```

#### Step 4: Build and deploy your step

After you’ve implemented your plugin, you can build and deploy the resulting DLL to the **AyBorg’s plugins directory**.

## Creating a device provider plugin

Developing a device provider for AyBorg allows the creation and management of devices, such as cameras or other hardware peripherals.

### Implementing device provider class

Create a class implementing `IDeviceProvider`, encapsulating the functionalities of the device provider.

#### Provider properties

Define the properties for the provider:

- `Prefix`: A unique prefix for identifying the provider.
- `CanCreate`: A flag to indicate whether the provider can create devices.
- `Name`: The provider’s name.
- `Categories`: The collection of categories associated with the provider.

#### Device creation method

- `CreateAsync`: Implement this method to create a device instance based on a given ID, returning it asynchronously.

#### (Optional) Initialization using IAfterInitialized interface

If you need to perform any initialization, such as discovering available camera devices on the network, you can implement the `IAfterInitialized` interface:

```csharp
public interface IAfterInitialized
{
    ValueTask AfterInitializedAsync();
}
```

This interface provides the `AfterInitializedAsync` method, which is called once during initialization, allowing you to perform necessary preparations before the provider starts running.

#### Device provider example implementation

```csharp
using AyBorg.Types;
using Microsoft.Extensions.Logging;

namespace AyBorg.Plugins.ImageTorque;

public sealed class VirtualDeviceProvider : IDeviceProvider
{
    private readonly ILogger<VirtualDeviceProvider> _logger;
    private readonly ILoggerFactory _loggerFactory;
    private readonly IEnvironment _environment;

    public string Prefix => "AyBV";

    public bool CanCreate => true;

    public string Name => "Virtual Devices";

    public IReadOnlyCollection<string> Categories { get; } = new List<string> { DefaultDeviceCategories.Camera, "Virtual Device" };

    public VirtualDeviceProvider(ILogger<VirtualDeviceProvider> logger, ILoggerFactory loggerFactory, IEnvironment environment)
    {
        _logger = logger;
        _loggerFactory = loggerFactory;
        _environment = environment;
    }

    public async ValueTask<IDevice> CreateAsync(string id)
    {
        var device = new VirtualDevice(_loggerFactory.CreateLogger<VirtualDevice>(), _environment, id);
        _logger.LogTrace((int)EventLogType.Plugin, "Added virtual device '{id}'", id);
        return await ValueTask.FromResult(device);
    }
}
```

## Creating a camera device

### Import the necessary namespaces for camera devices

```csharp
using AyBorg.Types;
using AyBorg.Types.ImageAcquisition;
using AyBorg.Types.Ports;
```

### Implementing camera device class

Create a class implementing ICameraDevice, encapsulating the functionalities of the camera device.

### Implementing device properties

Define properties essential for the device:

- `Id`: A unique identifier for the device.
- `Manufacturer`: The manufacturer’s name.
- `IsConnected`: The connection status.
- `Ports`: The collection of the device’s ports.
- `Name`: The device’s name.
- `Categories`: The collection of categories associated with the device.

### Handling image acquisition

`AcquisitionAsync`: A method that retrieves an image asynchronously according to the device’s internal logic.

### Connection management

These methods are responsible for managing the device’s connection state:

- `TryConnectAsync`: A method that attempts to connect to the device, handling success or failure appropriately.
- `TryDisconnectAsync`: A method that attempts to disconnect from the device, handling success or failure appropriately.
- `TryUpdateAsync`: A method to update the values of ports, handling synchronization with existing ports.

### Device example implementation

```csharp
using AyBorg.Types;
using AyBorg.Types.ImageAcquisition;
using AyBorg.Types.Ports;
using ImageTorque;
using Microsoft.Extensions.Logging;

namespace AyBorg.Plugins.ImageTorque;

public sealed class VirtualDevice : ICameraDevice, IDisposable
{
    private readonly ILogger<VirtualDevice> _logger;
    private readonly IEnvironment _environment;
    private readonly FolderPort _folderPort = new("Folder", PortDirection.Input, string.Empty);
    private static readonly string[] s_supportedFileTypes = new[] { ".jpg", ".jpeg", ".png", ".bmp" };
    private int _imageIndex = 0;
    private Task<ImageContainer>? _preloadTask;
    private string _lastFolderPath = string.Empty;
    private ImageContainer? _lastImageContainer;
    private long _imageCounter;
    private bool _isDisposed = false;

    public string Id { get; }

    public string Manufacturer => "Source Alchemists";

    public bool IsConnected { get; private set; }

    public IReadOnlyCollection<IPort> Ports { get; }

    public string Name { get; }

    public IReadOnlyCollection<string> Categories { get; } = new List<string> { DefaultDeviceCategories.Camera, "Virtual Device" };

    public VirtualDevice(ILogger<VirtualDevice> logger, IEnvironment environment, string id)
    {
        _logger = logger;
        _environment = environment;
        Id = id;
        Name = $"Virtual Device ({id})";

        Ports = new List<IPort> { _folderPort };
    }

    public async ValueTask<ImageContainer> AcquisitionAsync(CancellationToken cancellationToken)
    {
        _lastImageContainer?.Dispose();
        if (_preloadTask == null)
        {
            _preloadTask = PreloadImageAsync();
        }
        else if (!string.IsNullOrEmpty(_lastFolderPath) && !_lastFolderPath.Equals(_folderPort.Value, StringComparison.InvariantCultureIgnoreCase))
        {
            // File path changed while preloading a image
            await _preloadTask;
            _preloadTask = PreloadImageAsync();
        }

        _lastFolderPath = _folderPort.Value;

        _lastImageContainer = await _preloadTask;
        _preloadTask.Dispose();
        _preloadTask = PreloadImageAsync();
        return _lastImageContainer;
    }

    public ValueTask<bool> TryConnectAsync()
    {
        try
        {
            _preloadTask?.Dispose();
            _preloadTask = PreloadImageAsync();
            IsConnected = true;
        }
        catch (Exception ex)
        {
            _logger.LogWarning(new EventId((int)EventLogType.Plugin), ex, "Failed to connect to virtual device");
            IsConnected = false;
        }

        return ValueTask.FromResult(IsConnected);
    }

    public ValueTask<bool> TryDisconnectAsync()
    {
        try
        {
            _preloadTask?.Dispose();
            IsConnected = false;
        }
        catch (Exception ex)
        {
            _logger.LogWarning(new EventId((int)EventLogType.Plugin), ex, "Failed to disconnect from virtual device");
            IsConnected = true;
        }

        return ValueTask.FromResult(!IsConnected);
    }

    public async ValueTask<bool> TryUpdateAsync(IReadOnlyCollection<IPort> ports)
    {
        bool prevConnected = IsConnected;
        if (IsConnected && !await TryDisconnectAsync())
        {
            _logger.LogWarning(new EventId((int)EventLogType.Plugin), "Failed disconnecting virtual device");
            return false;
        }

        foreach (IPort port in ports)
        {
            IPort? targetPort = Ports.FirstOrDefault(p => p.Id.Equals(port.Id) && p.Brand.Equals(port.Brand));
            if (targetPort == null)
            {
                _logger.LogWarning(new EventId((int)EventLogType.Plugin), "Port {PortId} not found", port.Id);
                continue;
            }

            targetPort.UpdateValue(port);
        }

        if (prevConnected && !await TryConnectAsync())
        {
            _logger.LogWarning(new EventId((int)EventLogType.Plugin), "Failed connecting virtual device");
            return false;
        }

        _logger.LogTrace(new EventId((int)EventLogType.Plugin), "Updated virtual device");
        return true;
    }

    private Task<ImageContainer> PreloadImageAsync()
    {
        return Task.Factory.StartNew(() =>
        {
            string absolutPath = Path.GetFullPath($"{_environment.StorageLocation}{_folderPort.Value}");
            string[] files = Directory.GetFiles(absolutPath);
            IEnumerable<string> supportedFiles = files.Where(f => s_supportedFileTypes.Contains(Path.GetExtension(f), StringComparer.OrdinalIgnoreCase)).Order();
            string[] imageFileNames = supportedFiles.ToArray();
            if (imageFileNames.Length == 0)
            {
                _logger.LogWarning(new EventId((int)EventLogType.Plugin), "No images found in folder {folder}", _folderPort.Value);
                return null!;
            }

            if (_imageIndex >= imageFileNames.Length)
            {
                _imageIndex = 0;
            }

            string imageFileName = imageFileNames![_imageIndex];
            var image = Image.Load(imageFileName);
            imageFileName = imageFileName.Replace(_environment.StorageLocation, string.Empty);
            imageFileName = imageFileName.Replace('\\', '/');
            _imageIndex++;
            return new ImageContainer(image, _imageCounter++, imageFileName);
        });
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    private void Dispose(bool isDisposing)
    {
        if(isDisposing && !_isDisposed)
        {
            _preloadTask?.Wait();
            _preloadTask?.Dispose();
            _lastImageContainer?.Dispose();
            _isDisposed = true;
        }
    }
}
```
