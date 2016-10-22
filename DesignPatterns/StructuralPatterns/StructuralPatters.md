# Structural Patterns Homework

*   Select 3 structural design patterns
    *   Write a short description (about half page) for each of them
        *   Describe their motivation, intent, applicability, known uses, implementation, participants, consequences, structure, related patterns, etc.
        *   Use [Markdown](https://help.github.com/articles/github-flavored-markdown/) for the description (`.md` files) and upload it on your own GitHub
        *   Prefer Bulgarian language
    *   Provide your own C# examples for their use
    *   Provide a UML diagram or image of the pattern

## Composite

A composite object would compose a collection of objects implementing the same abstraction.
It would serve as an intermediary between a client and the collection of objects. 
The client will be unaware of the amount objects contained in the collection of the composed object.
The same call would be relayed to each of the objects in the composition.

A composite object allows a client, which can use a single instance of a worker, 
to use multiple instances of workers implementing the same abstraction.

See StructuralPatterns solution for examples.

## Decorator

A decorator extends the logic of an existing type. 
A decorator implements the same abstraction as the type it is decorating and contains an instance of that type.
It reuses the existing logic through the instance it contains and adds additional logic.

It is the preferred method of extending existing types over inneritance in order to avoid deep inheritance hierarchies.

See StructuralPatterns solution for examples.

## Facades

Unifies a number of objects performing different parts of a single unit of work. 
Simplifies a complicated operation/ algorithm by exposing a simpler api and 
implementing various subsystems doing their single resposibility work.

See StructuralPatterns solution for examples.