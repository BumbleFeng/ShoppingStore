# Instructions for Windows: https://azure.microsoft.com/documentation/articles/virtual-machines-windows-upload-image/
# Instructions for Linux: https://azure.microsoft.com/documentation/articles/virtual-machines-linux-capture-image/
Write-Host "Generalizing VM"
c:/windows/system32/sysprep/sysprep /quiet /generalize /oobe