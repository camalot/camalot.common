call "C:\Program Files (x86)\Microsoft Visual Studio 12.0\VC\vcvarsall.bat" x86
REM this will only build the package
msbuild NugetPublish.msbuild /p:PublishMode=NuGet /p:Project=Camalot.Common /verbosity:Diagnostic
msbuild NugetPublish.msbuild /p:PublishMode=NuGet /p:Project=Camalot.Common.Mvc /p:ProjectFriendlyName=Camalot.Common.Mvc /p:NuSpecFile=Camalot.Common.Mvc3.nuspec /verbosity:Diagnostic
msbuild NugetPublish.msbuild /p:PublishMode=NuGet /p:Project=Camalot.Common.Mvc4 /p:ProjectFriendlyName=Camalot.Common.Mvc /p:NuSpecFile=Camalot.Common.Mvc4.nuspec /verbosity:Diagnostic
msbuild NugetPublish.msbuild /p:PublishMode=NuGet /p:Project=Camalot.Common.Mvc5 /p:ProjectFriendlyName=Camalot.Common.Mvc /p:NuSpecFile=Camalot.Common.Mvc5.nuspec /verbosity:Diagnostic
pause