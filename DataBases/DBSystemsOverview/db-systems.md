## Database Systems - Overview
### _Homework_

#### Answer following questions in Markdown format (`.md` file)

1.  What database models do you know?
    - relational
    - NoSQL

1.  Which are the main functions performed by a Relational Database Management System (RDBMS)?
    - data integrity
    - data storage
    - security
    - [more info](http://databasemanagement.wikia.com/wiki/DBMS_Functions)

1.  Define what is "table" in database terms.
    - a set of data elements

1.  Explain the difference between a primary and a foreign key.
    - primary keys provide uniqueness to each element ( row )
    - foreign keys provide a link to elemnt(s) in another table

1.  Explain the different kinds of relationships between tables in relational databases.
    - one-to-one - the foreign key is the primary key, one table extends the other in a way, describing the same element
    - one-to-many - one table contains a reference ( realtion ) to another table.
    - many-to-many - junction table with a composite primary key, has one-to-many relationships with the two tables

1.  When is a certain database schema normalized?
    - [3NF](https://en.wikipedia.org/wiki/Third_normal_form) - lots of stuff

    * What are the advantages of normalized databases?
      - decreases redundancy of data ( unwanted duplicate data )
      - increase data integrity

1.  What are database integrity constraints and when are they used?
    - data types
    - primary / foreign keys
    - unique
    - allow null values

1.  Point out the pros and cons of using indexes in a database.
    - indexes provide fast search at the cost of slow inserts ( due to rebalancing of the underlying data structure providing the fast search. There was a binary tree homework assignemnt a couple of months ago demonstrating this. )

1.  What's the main purpose of the SQL language?
    - SQL = Structured Query Language - designed for managing data held in a relational database management system (RDBMS), or for stream processing in a relational data stream management system

1.  What are transactions used for?
    - Ensure the entire operation ( transaction ) is has been completed correctly it its entirety
    * Give an example.
      - bank transfers - it's either fully completed or fully canceled

1.  What is a NoSQL database?
    - Not Only SQL - uses different data structures - key-value, wide column, graph, or document
    - Scales easier 
    - Faster
    - not ACID compliant
    - [more info](https://en.wikipedia.org/wiki/NoSQL)

1.  Explain the classical non-relational data models.
    - [more info](https://arxiv.org/ftp/arxiv/papers/1307/1307.0191.pdf)
    - key-value - hashtable, super fast, often used in memory bds
    - document - xml/ json/ bson - MongoDB (bson)- stores "documents"
    - wide-column - large scale, versioned data
    - graph - realtionships between data

1.  Give few examples of NoSQL databases and their pros and cons.
    - voldemort, redis, mongo, cassandra