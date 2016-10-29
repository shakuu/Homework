# Strategy

The strategy pattern refers to a unit of work who would delegate a part of its task to a dependency. 
The dependency will produce the same type of result,
but a different implementation of it. 
Say you want to fill a matrix, you can have one strategy filling it left to right, top to bottom, 
another strategy filling it as a spiral, a third strategy fill it with prime numbers only.
The end result is always of the same type ( a filled matrix ), but different implementations.
At the same time the consuming class is only aware that the matrix has been filled.

Can be implemented as a method parameter or a type dependency. 

I think this pattern embodies the benefits of the SOLID Principles, Di and OOP in general. 

[Diagram](http://www.dofactory.com/net/strategy-design-pattern)