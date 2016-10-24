# Cars

##  Task 1: Import cars from JSON

Write a C# program to parse a number of JSON files with name format "data.number.json" holding a set of cars’ information in the format given below and load them into an array of cars:

```javascript
[
   {
      "Year":2014,
      "TransmissionType":0,
      "ManufacturerName":"Mazda",
      "Model":"6 Skyactiv",
      "Price":60000.0,
      "Dealer":{
         "Name":"Star Motors",
         "City":"Sofia"
      }
   },
   {
      "Year":2008,
      "TransmissionType":1,
      "ManufacturerName":"BMW",
      "Model":"320i Cabrio",
      "Price":30000.0,
      "Dealer":{
         "Name":"MM Auto",
         "City":"Sofia"
      }
   },
   {
      "Year":2003,
      "TransmissionType":0,
      "ManufacturerName":"Renaut",
      "Model":"Clio 1.4",
      "Price":5500.0,
      "Dealer":{
         "Name":"T Моторс",
         "City":"Sofia"
      }
   },
   {
      "Year":1997,
      "TransmissionType":0,
      "ManufacturerName":"Opel",
      "Model":"Tigra",
      "Price":5000.0,
      "Dealer":{
         "Name":"TA Моторс",
         "City":"Sofia"
      }
   }
]
```

- You are free to use a JSON parser by choice (or to parse the JSON without using a parser)

##  Task 2: Search cars with XML queries

###  Description

Implement a C# program for **searching for cars by given conditions**. It should be able to process a sequence of queries from the XML file queries.xml in the following format:

```xml
<?xml version="1.0"?>
<Queries xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
  <Query OutputFileName="Result0.xml">
    <OrderBy>Id</OrderBy>
    <WhereClauses>
      <WhereClause PropertyName="City" Type="Equals">Sofia</WhereClause>
      <WhereClause PropertyName="Year" Type="GreaterThan">1999</WhereClause>
    </WhereClauses>
  </Query>
</Queries>
```

- Each query has different output file, provided in the "OutputFileName" attribute.

- The queries can have two types of parameters - **ordering** and **where clauses**.
  - **Ordering** the results can be done by the following fields: `Id`, `Year`, `Model`, `Price`, `Manufacturer` (its name) and `Dealer` (its name).
  - **Where clauses** can be one or many
    - If many where clauses are provided, use "and" as logical operator between them
    - Where clauses have two attributes for defining the query – `PropertyName` and `Type`
      - `PropertyName` defines by which car property the search should be done
      - `Type` defines the type of comparer to use in the search
      - The following list gives you the available property types and comparers for each of them:
        - `Id` (number) -> **Equals**, **GreaterThan**, **LessThan**
        - `Year` (number) -> **Equals**, **GreaterThan**, **LessThan**
        - `Price` (floating point number) -> **Equals**, **GreaterThan**, **LessThan**
        - `Model` (text) -> **Equals**, **Contains**
        - `Manufacturer` (its name, text) -> **Equals**, **Contains**
        - `Dealer` (its name, text) -> **Equals**, **Contains**
        - `City` (its name) -> **Equals**
        - **GreaterThan** and **LessThan** does not include equal elements.

Write the results in the corresponding XML files in the following format:

```xml
<?xml version="1.0"?>
<Cars xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
  <Car Manufacturer="Mazda" Model="6 Skyactiv" Year="2014" Price="60000.00">
    <TransmissionType>manual</TransmissionType>
    <Dealer Name="Star Motors">
      <Cities>
        <City>Sofia</City>
      </Cities>
    </Dealer>
  </Car>
  <Car Manufacturer="BMW" Model="320i Cabrio" Year="2008" Price="30000.00">
    <TransmissionType>automatic</TransmissionType>
    <Dealer Name="MM Auto">
      <Cities>
        <City>Sofia</City>
      </Cities>
    </Dealer>
  </Car>
  <Car Manufacturer="Renaut" Model="Clio 1.4" Year="2003" Price="5500.00">
    <TransmissionType>manual</TransmissionType>
    <Dealer Name="TA Моторс">
      <Cities>
        <City>Sofia</City>
        <City>Kyustendil</City>
      </Cities>
    </Dealer>
  </Car>
</Cars>
```

Implement the search functionality correctly. Ensure it works fast enough for millions of records in the DB, and SQL injection is not possible.
- You are free to use XML parsers by choice, but take into account the performance.
