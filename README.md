# fruitstore

## How to set this up in local ?

* Clone the repository in your local 
* Run the ./Init.ps1 - This will install the necessary certs and adds the required hosts entries
* Populate the below details in the .env file

OrderCloudSettings_ApiUrl="https://yoursandbox-sandbox.ordercloud.io"
OrderCloudSettings_IncrementorPrefix="DB_TEST"
OrderCloudSettings_MarketplaceID=""
OrderCloudSettings_MarketplaceName=""
OrderCloudSettings_WebhookHashKey=""
OrderCloudSettings_MiddlewareClientID=""
OrderCloudSettings_MiddlewareClientSecret=""
OrderCloudSettings_ClientIDsWithAPIAccess=""

* And then run the 'docker-compose up -d'
* Wait for the containers to be up 
* This is the host name to access the buyer application - https://buyer.fruitstore.com
* End point of the middleware - https://api-middleware.fruitstore.com/ 

## About the containers

This sample solution has the following containers,

### A Middleware

This is a netcore API middleware and this is primarly to communicate with OrderCloud and all other integrations will be done here

### A Buyer App

* This is a React application for buyers. 
* For the UI, I am using bootstrap with this application


#### Note

* This is a sample POC to explore the different OrderCloud options in action
* I will be adding more functionalities on top of it 

## Demo

For now, only some very basic part is done and it will look like below,

![Redux](docs/images/Login.png?raw=true "Login")

## Stay Tuned and Happy Coding....!!!
