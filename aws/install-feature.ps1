Write-Host "Start to install choco!"
Set-ExecutionPolicy Bypass -Scope Process -Force; iex ((New-Object System.Net.WebClient).DownloadString('https://chocolatey.org/install.ps1'))

Write-Host "Start to install dotnet core hosting bundle!"
choco install dotnetcore-windowshosting -y