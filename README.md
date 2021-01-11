# PhoneBookSPA

The PhoneBook single page application will display all the information about the contacts including the name , phone number and the address. The Single plage application is comprises of React based app for the UI and Asp.net 5.0 is the backend api used to reterive the data from external api and pass the data to UI. The .Net app uses design pattern to make the changes unit testable and make it loosely coupled. 

## UI/View - React 

The react changes are placed under the same solution within the folder "ClientApp"

Follow the below steps to setup the envrionment


1. npm install
2. npm start

## Controller - API

The Project structure of the API in SPA is,

- PhoneBookSPA
- PhoneBookSPA.Entities
- PhoneBookSPA.Interface
- PhoneBookSPA.Services
- PhoneBookSPA.UnitTest

### PhoneBookSPA

This project holds the View (clientApp) and the core API controllers

### PhoneBookSPA.Entities

This project holds the entity class for holding the data for usage with the services and the controllers

### PhoneBookSPA.Interface

The interface project shows the singature of the services which are consumed in the conrollers

### PhoneBookSPA.Services

The Services project implements the interface and consumes the external api for getting the data.

### PhoneBookSPA.UnitTest

Project used the unit the controllers/services functions using nunit

## Steps to run

1. dotnet build
2. dotnet test
3. dotnet run

