# CQRSSample
For a more thorough discussion of the project refer  to:http://softwareunwound.com/2013/11/26/our-investigation-into-the-cqrs-pattern/#more-70

-	1) Install mongodb and get it up and running http://docs.mongodb.org/manual/tutorial/install-mongodb-on-windows/
-	2) Clone repo or download as zip
-	3) Right click on solution and choose to restore nuget packages
-	4) Build project
-	5) Launch SQL Server Management Services, point to your local Sql instance and run the scripts found at:
  https://github.com/softwareunwound/CQRSSample/tree/master/CqrsInvestigation/CqrsInvestigation/ModelSyncUtility/DataPopulationScripts
-	6) Ensure that Mongodb is running locally on your machine
-	7) Run the https://github.com/softwareunwound/CQRSSample/tree/master/CqrsInvestigation/CqrsInvestigation/ModelSyncUtility (This will populate mongo with the same data that is in your newly created DB from step 5.)

If you want to run SQL or Mongo remotely,  make sure to update the connection strings in https://github.com/softwareunwound/CQRSSample/blob/master/CqrsInvestigation/CqrsInvestigation/CqrsDal/ProductsRepository.cs
and https://github.com/softwareunwound/CQRSSample/blob/master/CqrsInvestigation/CqrsInvestigation/CqrsDal/MongoRepository.cs
