In the stack, I changed the EntityFramewor to NHibernate. There is no migration because by NHibernate way the same functionality is provided by "SchemaExport" and "SchemaUpdate".

Saving the request of the company for a statistic porpose is saved in 3 status: found, not fount, invalid predicate (numbers to search).

Before running the application, please add a connection string in Common/Infrastructure/Persistence/SessionFactory.cs and create the database by run command dotnet run in DatabaseSeed.

The best way to run the functional tests is to run it in console/terminal by run command dotnet test. Don,t forget to run the application first by type dotnet run in the Bootstrap folder.
