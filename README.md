## Eau Claire's Salon Stylist and Client Management System

By Hannah Young

A simple web application to allow a salon owner to manage stylists and their clients.

### Technologies Used

- C#
- .NET
- ASP.NET Core MVC
- MySQL

### Description

This is a web application that showcases my ability to develop a robust ASP.NET Core MVC backend attached to a MySQL database. 

### Setup

#### Requirements

* [git](https://git-scm.com)
* [.NET](https://dotnet.microsoft.com/en-us/)
* [MySQL](https://www.mysql.com/)
* [MySQL Workbench](https://www.mysql.com/products/workbench/)

#### To Run Web Application

1. Download and install the [.NET 5.0 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/5.0) as required for your system. Be sure to add the .NET sdk to your PATH
2. Use terminal to navigate to desired parent directory and use `git clone https://github.com/Corgibyte/hair-salon.git HairSalon.Solution`
3. Navigate into the project directory nested inside the .Solution directory: `cd HairSalon.Solution/HairSalon`
4. Create an appsettings.json file: `touch appsettings.json`
5. Edit the new appsettings.json file and add the following, making sure to replace the indicated sections with your MySQL user ID and password:
```
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Port=3306;database=hannah_young;uid=[YOUR MYSQL USER ID];pwd=[YOUR PASSWORD];"
  }
}
```
6. Open MySQL Workbench and log into your server
7. Find the _Navigator_ pane and select the _Administration_ tab.
8. Click on _Data Import/Restore_
9. Select _Import from Self-Contained File_ and choose the `hannah_young.sql` file in the root project directory
10. Under _Default Schema to be Imported To_ select _New..._
11. Name the new schema and click _OK_
12. Click _Start Import_
13. Back in the terminal, in the HairSalon directory build the project: `dotnet restore`
14. Run project: `dotnet run`
15. Use browser to navigate to `localhost:5000`

### Known bugs:

None at current time

### License

[Hippocratic License 2.1](https://github.com/Corgibyte/vendor-manager/blob/main/LICENSE.md), Copyright 2021 Hannah Young.
