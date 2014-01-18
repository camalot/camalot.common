call "C:\Program Files (x86)\Microsoft Visual Studio 12.0\VC\vcvarsall.bat" x86
REM this will only build the package
msbuild NugetPublish.msbuild /p:PublishMode=NuGet /p:Project=Camalot.Common
msbuild NugetPublish.msbuild /p:PublishMode=NuGet /p:Project=Camalot.Common.Mvc3
msbuild NugetPublish.msbuild /p:PublishMode=NuGet /p:Project=Camalot.Common.Mvc4
msbuild NugetPublish.msbuild /p:PublishMode=NuGet /p:Project=Camalot.Common.Mvc5
pause