
# Architecture Test Demo 

This project if for demo purposes, mainly to try some Architecture Test features and how to run different scenarios. 

Intended to use simple architecture to stay focused on the test itself, however rules applied here could be used in any other architecture.


## Project Architecture

- Presenation Layer (API)
- Business Layer 
- Data Layer 



## Components 
- ProductController (Entry Point) 
    - Some crud operations
    - Use Business layer 'IProductService' to handle requests 


- ProductService 
    - Doing some mapping (dto to domain)
    - Call Data layer by using 'IProductRepository'  

- ProductRepository
    - Perform crud actions on DB, using ApplicationDbContext  


## Installation

no need to run this code, this code is written only to be tested, you can simply build and run tests to try everything.


```bash
  dotnet build
  dotnet test
```

or through visual studio, by Test Explorer > run all tests   

