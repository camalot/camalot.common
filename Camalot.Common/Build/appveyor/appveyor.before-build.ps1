$rootLocation = ((Get-Item Env:\APPVEYOR_BUILD_FOLDER).Value);
$trunk = "$rootLocation\trunk\Managed.AndroidDebugBridge";
# change to the trunk
$ignore = Set-Location $trunk;

.\Build\InstallPfx.ps1 -pfx "$trunk\Shared\madb.pfx" -password ((Get-Item Env:\MADB_PFX_KEY).Value) -containerName ((Get-Item Env:\VS_PFX_KEY).Value);
# Go back to the root folder
$ignore = Set-Location ((Get-Item Env:\APPVEYOR_BUILD_FOLDER).Value);