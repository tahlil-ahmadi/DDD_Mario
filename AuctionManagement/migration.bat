dotnet fm migrate -p sqlserver -c "Data source=CLASS1\MSSQLSERVER1;Initial Catalog=Auction_DB;User Id=sa;password=123" -a ".\PartyManagement.DatabaseMigrations\bin\Debug\netcoreapp2.2\PartyManagement.DatabaseMigrations.dll"