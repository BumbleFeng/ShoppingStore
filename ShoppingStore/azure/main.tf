provider "azurerm" {
  subscription_id = "f8e73325-bd05-48f1-XXXX-cb5e25f02980"
  client_id       = "b7b56bda-052e-4ee2-XXXX-a62983e1aa06"
  client_secret   = "2064cf32-7f2c-4949-XXXX-55c99126f3b9"
  tenant_id       = "ad082942-7271-4a26-XXXX-57f03a8847ba"
  version         = "~> 1.23"
}

provider "random" {
  version         = "~> 2.0"
}

#Assume that custom image has been already created in the 'Packer-Sitecore' resource group
data "azurerm_resource_group" "image" {
  name = "Packer-Sitecore"
}

data "azurerm_image" "image" {
  name                = "packer-website-feng-001"
  resource_group_name = "${data.azurerm_resource_group.image.name}"
}

resource "azurerm_resource_group" "Demo" {
  name = "Demo"
  location = "East US"
}

resource "azurerm_virtual_network" "network" {
  name                = "demoNetwork"
  address_space       = ["10.0.0.0/16"]
  location            = "East US"
  resource_group_name = "${azurerm_resource_group.Demo.name}"
}

#resource "azurerm_resource_group" "networkGroup" {
#  name = "demoNetworkGroup"
#  location = "East US"
#}

# Generate random text for a unique storage account name
resource "random_id" "randomId" {
  keepers = {
  # Generate a new ID only when a new resource group is defined
  resource_group = "${azurerm_resource_group.Demo.name}"
  }  
  byte_length = 8
}

resource "azurerm_storage_account" "test" {
  name = "demo${random_id.randomId.hex}"
  resource_group_name      = "${azurerm_resource_group.Demo.name}"
  location                 = "East US"
  account_tier             = "Standard"
  account_replication_type = "LRS"
}

resource "azurerm_storage_container" "test" {
  name = "vhdss"
  resource_group_name = "${azurerm_resource_group.Demo.name}"
  storage_account_name = "${azurerm_storage_account.test.name}"
  container_access_type = "private"
}


resource "azurerm_network_security_group" "demo" {
    name = "demoSecurityGroup"
    location = "East US"
    #resource_group_name = "${azurerm_resource_group.networkGroup.name}"
	resource_group_name = "${azurerm_resource_group.Demo.name}"

    security_rule {
        name = "default-allow-rdp"
        priority = 1000
        direction = "Inbound"
        access = "Allow"
        protocol = "Tcp"
        source_port_range = "*"
        destination_port_range = "3389"
        source_address_prefix = "*"
        destination_address_prefix = "*"
    }
    security_rule {
        name = "winrm"
        priority = 1010
        direction = "Inbound"
        access = "Allow"
        protocol = "Tcp"
        source_port_range = "*"
        destination_port_range = "5985"
        source_address_prefix = "*"
        destination_address_prefix = "*"
    }
    security_rule {
        name = "winrm-out"
        priority = 100
        direction = "Outbound"
        access = "Allow"
        protocol = "*"
        source_port_range = "*"
        destination_port_range = "5985"
        source_address_prefix = "*"
        destination_address_prefix = "*"
    }

}

resource "azurerm_public_ip" "demoIP" {
    name = "demoIPAddress"
    location = "East US"
    resource_group_name = "${azurerm_resource_group.Demo.name}"
    allocation_method = "Static"
}

resource "azurerm_subnet" "demosubnet" {
    name = "testsubnet"
    resource_group_name = "${azurerm_resource_group.Demo.name}"
    virtual_network_name = "${azurerm_virtual_network.network.name}"
    address_prefix = "10.0.2.0/24"
}

resource "azurerm_network_interface" "nicdemo" {
    name = "nicdemo"
    location = "East US"
    resource_group_name = "${azurerm_resource_group.Demo.name}"

    ip_configuration {
        name = "ipconfiguration"
        subnet_id = "${azurerm_subnet.demosubnet.id}"
        private_ip_address_allocation = "dynamic"
        public_ip_address_id    = "${azurerm_public_ip.demoIP.id}"
    }
}

resource "azurerm_virtual_machine" "terraformtest" {
    name = "terraformtest"
    location = "East US"
    resource_group_name = "${azurerm_resource_group.Demo.name}"
    network_interface_ids = ["${azurerm_network_interface.nicdemo.id}"]
    vm_size = "Standard_D2_V2"
	
    #storage_image_reference {
    #    publisher = "MicrosoftWindowsServerHPCPack"
    #    offer = "WindowsServerHPCPack"
    #    sku = "2012R2"
    #    version = "latest"
    #}
	
    storage_image_reference {
      id = "/subscriptions/f8e73325-bd05-48f1-86fd-cb5e25f02980/resourceGroups/Packer-Sitecore/providers/Microsoft.Compute/images/packer-website-feng-001"
    }
	
    storage_os_disk {
        name = "myosdisk"
        #vhd_uri = "${azurerm_storage_account.test.primary_blob_endpoint}${azurerm_storage_container.test.name}/myosdisk.vhd"
        caching = "ReadWrite"
        create_option = "FromImage"
    }
    os_profile {
        computer_name = "terraformtest"
        admin_username = "feng"
        admin_password = "Passw0rd12345!"
    }
    os_profile_windows_config {
        enable_automatic_upgrades = false
    }
}