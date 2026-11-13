# AutoSet

AutoSet is a WPF application for Tekla Structures 2025.0. It targets .NET Framework 4.8.

## Automatic updates

The GitHub Actions workflow builds and publishes a new GitHub Release after each push to `master`. It downloads the Tekla Structures 2025 Open API assemblies from NuGet, embeds the managed dependencies into `AutoSet.exe`, and publishes that single EXE. Each build gets a version of `1.1.<GitHub run number>.0`.

On startup, AutoSet checks the latest release of `kuzya1014/Autoset`. When it finds a newer version, it asks whether to update, downloads `AutoSet.exe`, verifies its SHA-256 digest from the GitHub Releases API and its file version, then closes, replaces its EXE and restarts. The EXE's folder must be writable by the current Windows user. A network error does not stop the app. Do not install AutoSet under `Program Files` unless the user has permission to update its files.

For the first installation, download `AutoSet.exe` and run it from any writable folder, including Downloads. It extracts its bundled managed DLLs into `%LOCALAPPDATA%\AutoSet\Dependencies\<version>` automatically. Later releases can update the EXE automatically. A source commit alone is not enough until the Actions build and release have succeeded. The release repository must be public for the application to download updates without a GitHub credential. If you keep the source repository private, move releases to a separate public repository and update the URL in `UpdateService.cs` before building.

## Local build

Open `AutoSet.sln` on Windows with Visual Studio 2022, the .NET desktop development workload, and .NET Framework 4.8 targeting pack. The project uses assemblies from `C:\Program Files\Tekla Structures\2025.0\bin` by default. Override the `TeklaBinPath` MSBuild property if Tekla is installed elsewhere. Local Visual Studio builds use the installed DLLs; the release workflow embeds its NuGet dependencies. Running and testing export functions still requires a working Tekla Structures 2025 installation and the external macros and report/NC templates used by this project. Tekla must find `ESD PDF Print.cs` and `ESD DWG Export.cs` in its drawing macro paths, and `ESD DSTV to DXF EIW.cs` in its modeling macro path. The macros and templates are provided through the shared Tekla environment, not by the EXE.

This project has no automated application tests. Validate a release on a disposable Tekla model before relying on its exports. The Linux cloud environment can validate project structure, but cannot build or run this WPF application.
