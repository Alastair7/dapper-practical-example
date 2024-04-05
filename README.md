# DAPPER PRACTICAL EXAMPLE
![Dapper](https://github.com/Alastair7/dapper-practical-example/assets/70861797/f0bd6d55-be38-4ae8-8b80-00b78e6ca844)
## Blazingly fast demo that shows how Dapper works


### Requirements
- .NET 6.0
- Visual Studio 2022 Community (Optional. It's the version used for this example)

## How to build and execute the project
1. Clone this repo.
2. Select IIS Server.
3. Click Run.

## How to create the DB and add data model with data

### Creating the DB
1. Install [SQL Server - Express ](https://www.microsoft.com/es-es/sql-server/sql-server-downloads)
2. Install Microsoft SQL Server Management Studio (MSSM).
3. Login to your localhost DB: 
	- Server Type: Database Engine
	- Server Name: [PC-NAME]\SQLEXPRESS
	- Authentication: Windows Authentication
4. Right Click on Databases folder ->> New Database ->> Set Database name (dapperdev for this practical example), then click OK.

### Adding data model and data
1. Right click on DB name (dapperdev) ->> New Query.
2. Copy-Paste [DapperDB.sql](DapperDB.sql) script.
3. Execute script.

