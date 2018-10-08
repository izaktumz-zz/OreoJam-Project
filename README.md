# OreoJam
A Lightweight .NET Package for CRUD(Create,Read,Update,Delete) methods against a DbContext Database.

# Installation
->The Package can be found in Nuget Manager.Search OreoJam

OR

->Install-Package OreoJam

# Summary
-The main class that implements the CRUD Methods is called DevRepo

-One can perform batch or atomic operations against your Db as seen fit


# NB
-If lazy loading is enabled.Subsequent tables will be retrieved.

# Initialization
-Create an instance of the class,pass it your Database in the parameters and you are ready to go.(Create,Add,Delete or Update any item in your database)

Var dataRepo = new DevRepo<"Your DbContext Class/DB">(new "Your DbContext Class/DB");

# Usage
# Adding Item(s)
-dataRepo.AddItem("Item you want to add to the database").

-dataRepo.AddItems("List of Items you want to add to the database").

# Delete/Update an Item(s)
-dataRepo.UpdateItem("Item you want to update")

-dataRepo.UpdateItems("List of Items you want to update")

-dataRepo.DeleteItem("Item you want to delete")

-dataRepo.DeleteItems("List of Items you want to delete")


# Retrieving Item(s) From The Db
--dataRepo.GetItem<"Item/Table you want to retrieve">("The lambda expression/Criteria for retrieval i.e (x=>x.id ==1)").It retrieves a single item(i.e. one row from the Table based on the criteria you have given it).Returns a List

--dataRepo.GetItems<"Item/Table you want to retrieve">("The lambda expression/Criteria for retrieval i.e (x=>x.id >1 && x.status !='D' )").It retrieves many items/Rows(i.e. many rows from the Table based on the criteria you have given it).Returns a List

---dataRepo.GetItemsIqueryable<"Item/Table you want to retrieve">("The lambda expression/Criteria for retrieval i.e (x=>x.id >1 && x.status !='D' )").It retrieves many items/Rows(i.e. many rows from the Table based on the criteria you have given it).Returns an IQueryable

# Commit Changes to The Db.

-Changes are committed to the database after you call a CRUD Method(Create,Read,Update,Delete).



