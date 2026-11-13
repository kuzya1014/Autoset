# AutoSet

AutoSet is a WPF application for Tekla Structures 2025.0. It targets .NET Framework 4.8.

## Automatic updates

The GitHub Actions workflow builds and publishes a new GitHub Release after each push to `master`. It downloads the Tekla Structures 2025 Open API assemblies from NuGet for compilation. The release contains `AutoSet.exe` for updates and `AutoSet-windows.zip` with the build output and Tekla assemblies for first installation. Each build gets a version of `1.1.<GitHub run number>.0`.

On startup, AutoSet checks the latest release of `kuzya1014/Autoset`. When it finds a newer version, it asks whether to update, downloads `AutoSet.exe`, verifies its SHA-256 digest from the GitHub Releases API and its file version, then closes, replaces its EXE and restarts. The EXE's folder must be writable by the current Windows user. A network error does not stop the app. Do not install AutoSet under `Program Files` unless the user has permission to update its files.

For the first installation, extract `AutoSet-windows.zip` into a stable folder and run `AutoSet.exe` from that folder. If an older installation already works, close it and replace its EXE with the new one **once**, keeping the DLLs beside it. Do not run the EXE alone from Downloads: the window can open, but Tekla operations need the companion DLLs. Later releases can update the EXE automatically. A source commit alone is not enough until the Actions build and release have succeeded. The release repository must be public for the application to download updates without a GitHub credential. If you keep the source repository private, move releases to a separate public repository and update the URL in `UpdateService.cs` before building.

## Local build

Open `AutoSet.sln` on Windows with Visual Studio 2022, the .NET desktop development workload, and .NET Framework 4.8 targeting pack. The project uses assemblies from `C:\Program Files\Tekla Structures\2025.0\bin` by default. Override the `TeklaBinPath` MSBuild property if Tekla is installed elsewhere. Running and testing export functions also requires a working Tekla Structures 2025 installation and the external macros and report/NC templates used by this project.

This project has no automated application tests. Validate a release on a disposable Tekla model before relying on its exports. The Linux cloud environment can validate project structure, but cannot build or run this WPF application.
