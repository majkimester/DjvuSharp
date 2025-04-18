# DjvuSharp : .NET bindings for DjvuLibre library

**DjvuSharp** is a fork of v8ify/DjvuSharp. It is a set of .NET bindings for DjvuLibre library and it targets .NET Framework 4.8

It is useful to decode .djvu files and it can render a djvu page to raw pixel data. It also has features
to access and decode other djvu file metadata.

## Getting Started

This DjvuSharp library fork targets .NET Framework 4.8. DjvuSharp includes a pre-compiled native libraries for:

- Windows x86
- windows x64

**Note**: 
The included libraries are built from majkimester/DjVuLibre repo, and they are statically linked with Visual C++ platform libraries. 
Installing of the [Microsoft Visual C++ Redistributable for Visual Studio 2015, 2017, 2019 and 2022](https://learn.microsoft.com/en-us/cpp/windows/latest-supported-vc-redist?view=msvc-170) is not required.

If you have issues with statically linked platform libraries you can build and replace `libdjvulibre.dll` and `libjpeg.dll` with dinamically linked platform dlls. 
In this case the Redistributable needs to be installed, otherwise they will get an error message stating that `libdjvulibre.dll` could not be loaded because a module was not found.

## Usage

### Examples

The [examples](https://github.com/Prajwal-Jadhav/DjvuSharp/tree/master/examples) folder in the repository contains some examples of how the library can be used to extract pages from document and render them to a raster to raw pixel bytes.

### DjvuSharp library

The first step when using DjvuSharp is to create a `DjvuSharp.DjvuDocument` object:

```Csharp
    DjvuDocument document = DjvuDocument.Create("path/to/your/djvu/file.djvu");
```

This object is `IDisposable`, therefore you should always call the `Dispose()` method on it once you are done with it (or, better yet, wrap it in a `using` directive).

From there on, you can work with `DjvuDocument` object directly. Or you can create a `DjvuPage` object.

```Csharp
    // Here we are accessing the second page of the document
    // Since, the page numbering starts from 0 in DjvuSharp
    DjvuPage page = new DjvuPage(document, 1);
```

The `DjvuPage` is the most important object, as it has most of the useful attributes and methods.

## License

DjvuSharp is released under GPL V2. Check the [LICENSE](https://github.com/majkimester/DjvuSharp/blob/master/LICENSE) file for more details.
