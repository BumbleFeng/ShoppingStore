Add-Type -AssemblyName System.IO.Compression.FileSystem
Import-Module IISAdministration
Import-Module WebAdministration
function Unzip {
    param([string]$zipfile, [string]$outpath)

    [System.IO.Compression.ZipFile]::ExtractToDirectory($zipfile, $outpath)
}

function AddWebSite([string]$Name) { 
    $physicalPath = "C:\Inetpub\$Name" 
  
    New-IISSite -Name $Name -PhysicalPath $physicalPath -BindingInformation "*:80:" 

    Invoke-Command -scriptblock {iisreset}
}

Write-Host "Stop IIS!"
iisreset /stop

Write-Host "Remove default iis website!"
Remove-IISSite -Name 'Default Web Site' -Confirm:$false

Write-Host "Add our Web site to IIS!"
$appName = "Website" 
New-Item "c:\Inetpub\$appName" -type directory
#Add-RDSCertificate
AddWebSite -Name $appName 

Write-Host "Unzip contents of zip file into IIS app folder!"
Unzip "C:\temp\Website.zip" "c:\Inetpub\$appName"

New-Item "c:\Inetpub\$appName\logs" -type directory
$accessRule = New-Object System.Security.AccessControl.FileSystemAccessRule("IIS_IUSRS", "FullControl", "ContainerInherit,ObjectInherit", "None", "Allow")
$acl = Get-ACL "c:\Inetpub\$appName\logs"
$acl.AddAccessRule($accessRule)
Set-ACL -Path "c:\Inetpub\$appName\logs" -ACLObject $acl

Write-Host "Restart IIS!"
iisreset /start