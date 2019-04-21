StoreAPI:  
This is a RESTful API application based on ASP.NET Core. It works with MySQL database. Run localdb.sql to creat tables and insert primary data. Set the new ConnectionString in appsettings.json. It use JWT fo authorization. It is deployed on Azure as an [App Service](https://shoppingstoreapi.azurewebsites.net/api/item).  

ShoppingStre:  
This is a MVC web application based on ASP.NET Core. Set the API url in Models/StoreClient.cs. Deploy it to folder, and zip it properly (zip Website.zip * -r). Use packer to build images of Windows server and deploy the website with IIS. Use Terraform to run the VM. (There are scripts for both AWS and Azure). It is deployed on Azure as an [App Service](https://shoppingstorenet.azurewebsites.net).  

ShopNg:
This is an Angular project rewrited based on ShoppingStre. Set the API url in ShopClient/src/app/app.constants.ts. Use packer to build AWS AMI of Ubuntu and deploy the website with nginx. Use Terraform to run the VM. It is deployed on Azure as an [App Service](https://shoppingstoreng.azurewebsites.net).


App Service is a Paas Server form Azure. For the free plan, the first connection may take a while to get response, then it will work normally.

