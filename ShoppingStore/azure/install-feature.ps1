Write-Host "Installing IIS, ASP.NET!"
if(Get-Command -Name "Add-WindowsFeature")
{        
    Import-Module ServerManager
    Add-WindowsFeature Web-Server -IncludeManagementTools 
    Add-WindowsFeature NET-Framework-45-ASPNET 
    Add-WindowsFeature Web-Asp-Net45 
}else {
    throw "Could not add windows features"
}

Write-Host "Start to install choco!"
Set-ExecutionPolicy Bypass -Scope Process -Force; iex ((New-Object System.Net.WebClient).DownloadString('https://chocolatey.org/install.ps1'))

Write-Host "Start to install dotnet core hosting bundle!"
choco install dotnetcore-windowshosting -y