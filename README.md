# BassSharp

BassSharp is a C# wrapper for Bass, with its core code derived from ManagedBass. The primary modification has been the replacement of DllImport with LibraryImport to enhance support for AOT (Ahead-of-Time compilation) and improve efficiency. Additionally, it has been altered to support only .NET 8 and .NET 9.

Currently, only the main program portion has been modified; no plugins have been addressed.

This is for my personal use, and at present, only the self-use components are functional. Other features have not been tested. If you wish to use it, please conduct tests first.

# Getting Started

* Install the NuGet package
```
Install-Package BassSharp
```
* Download the BASS libraries from http://un4seen.com and place them in Build Output Directory.
