OreoJam
A Lightweight .NET Package for CRUD(Create,Read,Update,Delete) methods against a DbContext Database

[Installation]
->The Package can be found in Nuget Manager.
->Install-Package OreoJam

[Summary]
-------
-The main class that implements the CRUD Methods is called DevRepo

-One can perform batch or atomic operations against your Db as seen fit


NB
-If lazy loading is enabled.Subsequent tables will be retrieved.

Initialization
--------------
-Create an instance of the class and pass it your Database in the parameters.

-DevRepo<"Your DbContext Class"> dataRepo = new DevRepo<"Your DbContext Class">(new ""Your DbContext Class"");

[Usage]
-------
Adding Item(s)
---------------
-dataRepo.AddItem("item you want to add.This corresponds to a table in the Db")

-dataRepo.AddItems("items you want to add.This corresponds to a table in the Db").This is a batch operation

Delete an Item
--------------
-dataRepo.DeleteItem("item you want to delete.This corresponds to a table in the Db")

Update an Item
---------------
-dataRepo.UpdateItem("item you want to Update.This corresponds to a table in the Db")

Retrieving Item(s) From The Db
------------------------------
--dataRepo.GetItem<"Item/Table you want to retrieve">("The lambda expression/Criteria for retrieval i.e (x=>x.id ==1)").It retrieves a single item(i.e. one row from the Table based on the criteria you have given it)

--dataRepo.GetItems<"Item/Table you want to retrieve">("The lambda expression/Criteria for retrieval i.e (x=>x.id ==1)").It retrieves many items/Rows(i.e. many rows from the Table based on the criteria you have given it)