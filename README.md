# fruitstore

## How to set this up in local ?

* Clone the repository in your local 
* Run the ./Init.ps1 
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

## About the containers

This sample solution has the following containers,

### A Middleware

This is a netcore API middleware and this is primarly to communicate with OrderCloud and all other integrations will be done here

### A Buyer App

This is a React application for buyers. 


#### Note

* This is a sample POC done by me 
* I will be keep adding improvement on top of it 



## Happy Coding....!!!
