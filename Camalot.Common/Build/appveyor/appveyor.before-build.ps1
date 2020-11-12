#$rootLocation = ((Get-Item Env:\APPVEYOR_BUILD_FOLDER).Value);
#$trunk = "$rootLocation\";
# change to the trunk
#$ignore = Set-Location $trunk;

#.\Build\InstallPfx.ps1 -pfx "$trunk\Shared\camalot.pfx" -password ((Get-Item Env:\CAMALOT_PFX_KEY).Value) -containerName ((Get-Item Env:\VS_PFX_KEY).Value);
# Go back to the root folder
#$ignore = Set-Location ((Get-Item Env:\APPVEYOR_BUILD_FOLDER).Value);