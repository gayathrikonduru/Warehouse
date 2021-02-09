

##Preferred Browser
 Chrome, Microsoft Edge

##How to Run
1. First run the Warehouse.API project 
    RightClick on Warehouse.API Project -> Debug -> Start new instance
    Check whether the API instance has started

2. Set Warehouse.UI project as startup and run
     Home page should be displayed.

## Operations that can be handled via UI

1. Import Products and Articles Data
     
     Test files has been added to the resources folder - Test files which is given as part of assignment has been modified. please use the test files that is attached in the solution to get desired results. 

     Articles need to be imported first before products, since the mapping is required.

     The data is stored in SQL Server Database. 

2. Products Stock -- 
      Products data has to be imported to use this functionality.

      Displays all the products that are availble.

      Product can be deleted by clicking on Trash icon. 


## Warehouse.API supported actions
  All API actions can be tested in Postman

  1. GetAllProducts -[HttpGet] - https://localhost:44393/api/products
      
      Returns list of products that are available with used articles data

  2. GetProductById - [HttpGet] - https://localhost:44393/api/products/1

      Returns product deatils of given productId.

  3. AddNewProduct - [HttpPost] - https://localhost:44393/api/products
  
      Adds new product to the product table
  
  4. UpdateProduct - [HttpPut] -  https://localhost:44393/api/products
      
      Update given product by productId

  5. DeleteProduct -[HttpDelete] - https://localhost:44393/api/products/1
      
      Delete product by productId


      
   
