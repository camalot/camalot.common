call "C:\Program Files (x86)\Microsoft Visual Studio 14.0\VC\vcvarsall.bat" x86

REM Builds the projects making sure they are up to date.

msbuild Build.msbuild /p:Project=Camalot.Common /verbosity:Diagnostic
msbuild Build.msbuild /p:Project=Camalot.Common.Mvc /verbosity:Diagnostic
msbuild Build.msbuild /p:Project=Camalot.Common.Mvc4 /verbosity:Diagnostic
msbuild Build.msbuild /p:Project=Camalot.Common.Mvc5 /verbosity:Diagnostic

REM this will only build the package

msbuild NugetPublish.msbuild /p:PublishMode=NuGet /p:Project=Camalot.Common /p:LocalDeploy=E:\Development\deploy\nuget\ /verbosity:Diagnostic
msbuild NugetPublish.msbuild /p:PublishMode=NuGet /p:Project=Camalot.Common.Mvc /p:ProjectFriendlyName=Camalot.Common.Mvc /p:NuSpecFile=Camalot.Common.Mvc3.nuspec /p:LocalDeploy=E:\Development\deploy\nuget\ /verbosity:Diagnostic
msbuild NugetPublish.msbuild /p:PublishMode=NuGet /p:Project=Camalot.Common.Mvc4 /p:ProjectFriendlyName=Camalot.Common.Mvc /p:NuSpecFile=Camalot.Common.Mvc4.nuspec /p:LocalDeploy=E:\Development\deploy\nuget\ /verbosity:Diagnostic
msbuild NugetPublish.msbuild /p:PublishMode=NuGet /p:Project=Camalot.Common.Mvc5 /p:ProjectFriendlyName=Camalot.Common.Mvc /p:NuSpecFile=Camalot.Common.Mvc5.nuspec /p:LocalDeploy=E:\Development\deploy\nuget\ /verbosity:Diagnostic

pause