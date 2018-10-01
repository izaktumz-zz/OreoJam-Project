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

-All the Changes take effect after calling the dataRepo.CommitChanges()/dataRepo.CommitChangesAsync() method.

# Initialization
-Create an instance of the class and pass it your Database in the parameters.


-DevRepo<"Your DbContext Class"> dataRepo = new DevRepo<"Your DbContext Class">(new ""Your DbContext Class"");

# Usage
# Adding Item(s)
-dataRepo.AddItem("contains the no of item/table(s) you want to add to the database")

-dataRepo.AddItem("new Table1(),new Table2(),new Table3(){}..up to 7")

-Maximum no of tables that can be added at once is 7.At the  moment minimum is 1.

-Once done call dataRepo.CommitChanges() or dataRepo.CommitChangesAsync()

# Delete/Update an Item(s)
-dataRepo.Update("Item you want to update","status for the update i.e. d for delete and m for  modify")

-dataRepo.UpdateChanges("List of Items you want to update","status for the update i.e. d for delete and m for  modify")

-Once done call dataRepo.CommitChanges() or dataRepo.CommitChangesAsync()

# Retrieving Item(s) From The Db
--dataRepo.GetItem<"Item/Table you want to retrieve">("The lambda expression/Criteria for retrieval i.e (x=>x.id ==1)").It retrieves a single item(i.e. one row from the Table based on the criteria you have given it)

--dataRepo.GetItems<"Item/Table you want to retrieve">("The lambda expression/Criteria for retrieval i.e (x=>x.id >1 && x.status !='D' )").It retrieves many items/Rows(i.e. many rows from the Table based on the criteria you have given it)

# Commit Changes to The Db.

-dataRepo.CommitChanges()-commits all your changes to the DB Synchronously.

-dataRepo.CommitChangesAsync()-commits all your changes to the DB ASynchronously.

