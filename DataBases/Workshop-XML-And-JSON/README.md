# Steps for solving the "Cars" task

The description of the task can be found [here](/DESCRIPTION.md)

##  Task 1: Import cars from JSON

1.  Read the JSON
  - This is simple:
    - Since we need all the data, just read the whole file: `File.ReadAllText(jsonPath);`    
2.  Parse the JSON to `CarJsonModel`, a **new class**, that complies to the cars data from the JSON
  - The cars are represented differently in the JSON, than in the `Car` class
  - So, create a new `CarJsonModel` class that has properties: `Year (int)`, `TransmissionType (enum)`, `ManufacturerName(string)`, `Model (string)`, `Price(decimal)`, `Dealer(DealerJsonModel)`, etc...

3.  Convert each car from `CarJsonModel` to `Car`
  - Write a method to parse from `CarsJsonModel` to `Car`
    - Can be done as a `static` property of type `Func<CarJsoNModel, Car>` than does the parsing:

      ```cs
      class CarJsonModel {
        /* Other properties */
        public static Func<CarJsonModel, Car> FromJsonModel
        {
          get
          {
            return jsomModel => new Car
            {
              Model = jsomModel.Model,
              Dealer = new Dealer
              {
                Name = jsomModel.Dealer.Name,
                Cities = new List<City> { new City { Name = jsomModel.Dealer.City } }
              },
              Manufacturer = new Manufacturer
              {
                Name = jsomModel.ManufacturerName
              },
              Price = jsomModel.Price,
              TransmissionType = jsomModel.TransmissionType,
              Year = jsomModel.Year
            };
           }
       }
     }
      ```
    - And used as follows:

      ```cs
      IEnumerable<CarJsonModel> carJsonModels = LoadCarsFromJson(...);
      IEnumerable<Car> cars = carJsonModels.Select(CarJsonModel.FromJsonModel)
      ```

##  Task 2: Search cars with XML queries

1.  Read and parse the XML with the queries
  - You can use any XML parser, or manually (RegEx and searching of strings)
  - How to choose what to use?
    - Think of the requirements
      - Must work fast, can contain millions of queries
        - The DOM parser and LINQ-to-XML will be too slow
        - Here the `XmlReader` is the correct solution  
2.  Parse the queries
  - Two possible approaches: 1) Read and apply filter over the cars immediately, 2) Read the queries, parse them into objects, filter the cars
  - Use the 2nd approach, as it is easier for extension and testing
  - Create a class `XmlQuery`, having 3 properties: `Order (string)`, `OutputFile (string)` and `WhereClauses(IEnumerable<XmlWhereClause)>`
  - Fill the queries in `XmlQuery` objects  
3.  Filter the `cars` array with each query
  - Create a method to filter the queries
    - This can be done using many `switch-case` constructions
    - Not many cleaner solutions
  - Think of how that can be done more easily than `3x7` switch-cases  
4.  Save the filtered cars at the provided location
  -   You can use any parser:
    - The DOM parser is kind of hard
    - Use `XDocument` or `XmlWriter`
      - `XmlWriter` is faster      
