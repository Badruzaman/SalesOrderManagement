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
+ Order has building and state information as master data.
+ Order has product which is windows.
+ Product has different attributes like type and dimension.
+ Every product has quantity  

## Relationship
+ One state can have multiple building, one to many relationship. 
+ One product attribute can have one dimension, one to one relationship.
+ One product can  have multiple product attribute, one to many relationship.
+ Every sales order has one building and one state, one to one relationship among sales order with state and building.
+ Every sales order has one or more than one sales order detail and every order detail has one products, so one to many relationship between sales order and sales order details and one to one relationship beteween sales order details and products.

## Tools and Technology 
+ MS SQL SERVER 2022
+ Visual Studio 2022
+ Blazor WebAssembly
+ MS .Net Core Web Api
+ Core First Approach
+ Entity Framework
+ Linq

## User Interfaces

![SalesOrderEntry](./images/Version.JPG)








