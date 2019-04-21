$cred = Get-Credential
Login-AzureRmAccount -Credential $cred

$subscription = Get-AzureRmSubscription

$password = "passw0rd12345!"
$tenant = $subscription.TenantId
$subscriptionId = $subscription.SubscriptionId

$app = New-AzureRmADApplication -DisplayName "Packer-Sitecore" -HomePage "https://dino.net/Packer-Sitecore" -IdentifierUris "https://dino.net/Packer-Sitecore" -Password $password

$appId = $app.ApplicationId 
$servicePrincipal = New-AzureRmADServicePrincipal -ApplicationId $appId
$spObjectId = $servicePrincipal.Id

Start-Sleep 15
New-AzureRmRoleAssignment -ObjectId $spObjectId  -RoleDefinitionName "Owner" -ServicePrincipalName $appId -Scope "/subscriptions/$subscriptionId"
New-AzureRmResourceGroup -Name "Packer-Sitecore" -Location "East US"
New-AzureRmStorageAccount -ResourceGroupName "Packer-Sitecore" -Name "packersitecorestorage" -SkuName Standard_LRS -Location "East US"

Write-Host "AZURE_PACKER_TENANTID = $tenant"
Write-Host "AZURE_PACKER_SUBSCRIPTIONID = $subscriptionId"
Write-Host "AZURE_PACKER_OBJECTID = $spObjectId"
Write-Host "AZURE_PACKER_APPID = $appId"


[Environment]::SetEnvironmentVariable("AZURE_PACKER_TENANTID", $tenant, "User")
[Environment]::SetEnvironmentVariable("AZURE_PACKER_SUBSCRIPTIONID", $subscriptionId, "User")
[Environment]::SetEnvironmentVariable("AZURE_PACKER_OBJECTID", $spObjectId, "User")
[Environment]::SetEnvironmentVariable("AZURE_PACKER_APPID", $appId, "User")
[Environment]::SetEnvironmentVariable("AZURE_PACKER_PASSWORD", $password, "User")
