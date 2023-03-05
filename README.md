# Sales Order Management
# Problem
Task Description 
Create a web app, for managing sales order data. 
Requirements 
1. Create new database tables Using Code First In Entity Framework. 
2. Blazor WebAssembly app with an interface to show data from DB. 
3. Make an ability to change and save data in the application: state, name, and dimensions. 
4. Add the ability to create and delete orders, windows and elements. 
5. Optional: Interface validations. DTO. Separated BLL and DAL projects. 

Provide source code with all necessary information to run and test the application. 
Test data for storing into the database: 

<pre>
&lt;Orders&gt;
 &lt;Order Name="New York Building 1" State="NY"&gt;
 &lt;Windows&gt;
 &lt;Window Name="A51" QuantityOfWindows="4" TotalSubElements="3"&gt;
 &lt;SubElements&gt;
 &lt;SubElement Element="1" Type="Doors" Width="1200" Height="1850" /&gt;
 &lt;SubElement Element="2" Type="Window" Width="800" Height="1850" /&gt;
 &lt;SubElement Element="3" Type="Window" Width="700" Height="1850" /&gt;
 &lt;/SubElements&gt;
 &lt;/Window&gt;
 &lt;Window Name="C Zone 5" QuantityOfWindows="2" TotalSubElements="1"&gt;
 &lt;SubElements&gt;
 &lt;SubElement Element="1" Type="Window" Width="1500" Height="2000" /&gt;
 &lt;/SubElements&gt;
 &lt;/Window&gt;
 &lt;/Windows&gt;
 &lt;/Order&gt;
 &lt;Order Name="California Hotel AJK" State="CA"&gt;
 &lt;Windows&gt;
 &lt;Window Name="GLB" QuantityOfWindows="3" TotalSubElements="2"&gt;
 &lt;SubElements&gt;
 &lt;SubElement Element="1" Type="Doors" Width="1400" Height="2200" /&gt;
 &lt;SubElement Element="2" Type="Window" Width="600" Height="2200" />
 
 &lt;/SubElements&gt;
 &lt;/Window&gt;
 &lt;Window Name="OHF" QuantityOfWindows="10" TotalSubElements="2"&gt;
 &lt;SubElements&gt;
 &lt;SubElement Element="1" Type="Window" Width="1500" Height="2000" /&gt;
 &lt;SubElement Element="1" Type="Window" Width="1500" Height="2000" /&gt;
 &lt;/SubElements&gt;
 &lt;/Window&gt;
 &lt;/Windows&gt;
 &lt;/Order&gt;
&lt;/Orders>
</pre>

# Solution
+ Each order contains master data for the building and state associated with the order.
+ Every order includes one or more windows as a product.
+ Each window has various attributes such as type and dimension.
+ Every window is associated with a quantity.  

## Relationship
+ Each state can have multiple buildings, representing a one-to-many relationship between states and buildings. 
+ Each product attribute can have one dimension, indicating a one-to-one relationship between product attributes and dimensions.
+ Each product can have multiple product attributes, resulting in a one-to-many relationship between products and product attributes.
+ Each sales order is associated with one building and one state, establishing a one-to-one relationship between sales orders and both buildings and states.
+ Each sales order has one or more sales order details, resulting in a one-to-many relationship between sales orders and sales order details, and each sales order       detail is associated with one product, and a one-to-one relationship between sales order details and products.

## Tools and Technology 
+ MS SQL SERVER 2022
+ Visual Studio 2022
+ Blazor WebAssembly
+ MS .Net Core Web Api
+ Core First Approach
+ Entity Framework
+ Linq

## Project Architecture 
I have developed three projects as part of this project: a web API, which serves as the intermediary between the database server and the other components of the application; a web client, which provides the user interface for interacting with the system; and a data transfer model, which defines the structure and format of the data exchanged between the API and the client.
![Architecture](/SalesOrderManagement.Web/images/Architecture.PNG)
![ProjectDescription](/SalesOrderManagement.Web/images/PorjectDescription.PNG)

## User Interfaces
### Order Entry
![SalesOrderEntry](/SalesOrderManagement.Web/images/SalesOrderEntry.png)
### Order List
![SalesOrderList](/SalesOrderManagement.Web/images/SalesOrderList.PNG)
### Update Order
![SalesOrderEdit](/SalesOrderManagement.Web/images/SalesOrderEdit.PNG)

## Project Configuration
+ Clone or download the repository 
+ Attach the database or run the SQL Script
+ ![backup](/SalesOrderManagement.Web/images/SalesOrderManagement.bak)
+ ![script](/SalesOrderManagement.Web/images/SalesOrderManagementSqlScript.sql)
+ Change the connection string

![DatabaseConnection](/SalesOrderManagement.Web/images/DBConnectionString.PNG)
+ Right-click on the solution explorer, go to the property, and make changes.

![MultiProject](/SalesOrderManagement.Web/images/MultipleProjectSelect.PNG)
+ Run the solution 
+ It runs two applications at the same time, picks up the web API URL, and put it in the client application's Program.cs file as the base URL

![ApiUrl](/SalesOrderManagement.Web/images/ClientSideConfig.PNG)
+ Pick up the client application URL and put it in the web api Program.cs file for Enabling Cross-Origin Requests.

![clientUrl](/SalesOrderManagement.Web/images/ServerSideConfig.PNG)
+ Code first approach for a new database.
+ delete the migration folder.
+ Make sure database connection.

![clientUrl](/SalesOrderManagement.Web/images/DeleteMigration.PNG) 
+ After successful migration, update the database
+ This generates errors. 

![Error](/SalesOrderManagement.Web/images/DbError.PNG) 
+ Make changes in initial.cs file

![correctionPlace](/SalesOrderManagement.Web/images/errorCorrectionPlace.PNG) 
![correction](/SalesOrderManagement.Web/images/MigrationCorrection.PNG) 
+ Try again




