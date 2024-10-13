# Business Card Assignment

This project is a business card management system implemented using .NET and Angular. It follows design principles such as SOLID, Domain-Driven Design (DDD), Clean Architecture, CQRS, Fluent Validation, Middleware handling, and more.
![alt text](https://github.com/Lanaya97/Business-Card-Assignment/blob/master/1.png?raw=true)
![alt text](https://github.com/Lanaya97/Business-Card-Assignment/blob/master/2.png?raw=true)
![alt text](https://github.com/Lanaya97/Business-Card-Assignment/blob/master/3.png?raw=true)

## Table of Contents
- [Technologies Used](#technologies-used)
- [Getting Started](#getting-started)
- [Database](#database)
- [Design Principles](#design-principles)
- [Data Import Formats](#data-import-formats)
- [Project Structure](#project-structure)

## Technologies Used
- **Front-End:** Angular 18.2.7, Node 22.0.0, npm 10.5.1 -  Bootstrap
- **Back-End:** .NET 7, CQRS, Fluent Validation
- **Database:** MySQL - Entity Framework Core (Code-First approach)
- **Other Concepts:** Clean Architecture, Domain-Driven Design (DDD), SOLID Principles

## Getting Started
Prerequisites
Ensure you have the following installed on your system:

Node.js and npm
Angular CLI
.NET 7 SDK
Running the Front-End
To run the front-end Angular application, follow these steps:

Open your terminal or command prompt and navigate to the front-end directory.
Run the following command to install the necessary dependencies:
bash
Copy code
npm install
Once the installation is complete, start the development server using:
bash
Copy code
ng serve
Open your browser and go to http://localhost:4200 to view the application.
Running the Back-End
Navigate to the back-end project directory.
Open the appsettings.json file to configure the database connection string if needed.
Run the back-end server using:
bash
Copy code
dotnet run
The database will be automatically created when the back-end server runs, and temporary data will be seeded into the database.

## Database
MySQL, The database connection string can be found in the appsettings.json file in the back-end project. The database is automatically created upon running the server and seeds with temporary data, so no manual setup is required.
## Design Principles
This project follows several design principles and patterns to ensure clean, scalable, and maintainable code, including:

SOLID Principles
Domain-Driven Design (DDD)
Clean Architecture
CQRS (Command Query Responsibility Segregation)
Fluent Validation
Middleware Handling

## Data Import Formats

The application supports data imports in the following formats:

- **CSV:** `.csv`
- **XML:** `.xml`
- **QR Code Images:** `.png`, `.jpg`, `.jpeg`, `.pdf`, `.gif`, `.bmp`

The upload method automatically detects the format and processes the data accordingly.

### CSV Format
The CSV file should have the headers in the first row. Here's an example:

```csv
Name,Gender,DateOfBirth,Email,CountryCode,Number,Street,City,ZipCode
John Doe,Male,1990-01-01,john.doe@example.com,+1,1234567890,123 Elm Street,Springfield,12345
```
### XML Format
Here is an example of the XML format:

```xml
<ArrayOfCreateBusinessCardRequestDto xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
  <CreateBusinessCardRequestDto>
    <Name>Abed Ajarmeh</Name>
    <Gender>Male</Gender>
    <DateOfBirth>1997-03-16T22:00:00</DateOfBirth>
    <Email>test123@hotmail.com</Email>
    <CountryCode>+962</CountryCode>
    <Number>790524409</Number>
    <Street>Mecca St</Street>
    <City>Amman</City>
    <ZipCode>11981</ZipCode>
     />
  </CreateBusinessCardRequestDto>
  <!-- Additional Business Card Entries Here -->
</ArrayOfCreateBusinessCardRequestDto>
```
### QR Code Json Format
For QR code image uploads, the JSON data embedded within the QR code should follow this format:

```QR Code
For QR code image uploads, the JSON data embedded within the QR code should follow this format:
{
  "name": "John Doe",
  "gender": "Male",
  "dateOfBirth": "1990-01-01",
  "email": "john.doe@example.com",
  "countryCode": "+1",
  "number": "1234567890",
  "street": "123 Elm Street",
  "city": "Springfield",
  "zipCode": "12345",
}
```
## Project Structure

### Front-End

```plaintext
Front-End
├── index.html
├── main.ts
├── proxy.conf.js
├── styles.scss
├── app
│   ├── app-routing.module.ts
│   ├── app.component.css
│   ├── app.component.html
│   ├── app.component.ts
│   ├── app.module.ts
│   ├── card
│   │   ├── card-list
│   │   │   ├── card-list.component.css
│   │   │   ├── card-list.component.html
│   │   │   ├── card-list.component.ts
│   ├── dialogs
│   │   ├── import-dialog
│   │   │   ├── import-dialog.component.css
│   │   │   ├── import-dialog.component.html
│   │   │   ├── import-dialog.component.ts
├── helpers
│   ├── utils
│   ├── common
├── enums
```
### Back-End

```Back-End
├── BusinessCard.API
│   ├── appsettings.Development.json
│   ├── appsettings.json
│   ├── Controllers
│   ├── JsonConverters
│   ├── Middleware
├── BusinessCard.Application
├── BusinessCard.Domain
├── BusinessCard.Infrastructure
```

