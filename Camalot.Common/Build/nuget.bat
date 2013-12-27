call "C:\Program Files (x86)\Microsoft Visual Studio 12.0\VC\vcvarsall.bat" x86
REM this will only build the package
msbuild NugetPublish.msbuild /p:PublishMode=NuGet
pause