<h1 align="center">
   <img src="https://cdn-icons-png.flaticon.com/512/1703/1703128.png" width="150" height="150">
    <img src="https://cdn-icons-png.flaticon.com/512/919/919825.png" width="150" height="150">
  <br>
  Plant Here Nodejs
</h1>

## Table of contents

- [Overview](#overview)
  - [Technology Used](#technology-used)
- [Getting Started](#getting-started)
  - [PlantHere Nodejs Run](#planthere-nodejs-run)
- [API Documentation](#api-documentation)
  - [Swagger](#swagger)
  - [REST Client](#rest-client)


# Overview

<div align="center">
  <br>
  <img src="../Documents/Diagram/NodejsPlantHere.png" >
  <br>
  <br>
  <h3>
    This API is a e-commerce API. It provides order creation, adding/deleting products to a cart, purchasing and product listing processes.
  </h3>
  <br>
</div>

## Technology Used

- Nodejs 
- MSSQL
- Swagger
- Express
- Sequelize
- Swagger

# Getting Started
  ## PlantHere Nodejs Run
  
  - Download Nodejs https://nodejs.org/en/download/

  ```bash
    cd .\Core\PlantHere.Aplication
    npm i
    cd ..
    cd ..

    cd .\Core\PlantHere.Domain
    npm i
    cd ..
    cd ..

    cd .\Infrastructure\PlantHere.Infrastructure
    npm i
    cd..
    cd..
    
    cd .\Infrastructure\PlantHere.Persistance
    npm i
    cd ..
    cd ..

    cd .\Presentation\PlantHere.WebAPI
    npm i
    npm start
  
  ```


# API Documentation

  ## Swagger

  - Swagger Document link http://localhost:4000/swagger/
  
  <img src="../Documents/Images/Swagger/4.png" >
  <img src="../Documents/Images/Swagger/5.png" >

  ## REST Client

  - Install REST Client 
  <img src="../Documents/Images/RESTClient/1.png" >

  - Collection path "**./RestFullRequests**"
  
  - You can now send a request to the PlantHere Nodejs API.
  
  <img src="../Documents/Images/RESTClient/2.png" >

  - Note : See Authserver/README.md for authentication and authorization.


  