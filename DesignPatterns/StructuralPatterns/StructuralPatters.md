# Structural Patterns Homework

*   Select 3 structural design patterns
    *   Write a short description (about half page) for each of them
        *   Describe their motivation, intent, applicability, known uses, implementation, participants, consequences, structure, related patterns, etc.
        *   Use [Markdown](https://help.github.com/articles/github-flavored-markdown/) for the description (`.md` files) and upload it on your own GitHub
        *   Prefer Bulgarian language
    *   Provide your own C# examples for their use
    *   Provide a UML diagram or image of the pattern

## Composite

An object implementing an interface, containing a collection of objects implementing the same interface. The client manages a single object without being aware of the collection of objects behind.

## Decorator

A decorator extends the functionality of an existing type. It takes an instance of a type implementing the same interface, extends the functionality and reuses the the existing implementation.

## Facades

Unifies a number of objects performing different parts of a single unit of work. Simplifies a complicated operation/ algorithm by exposing a simpler api and implementing various subsystems doing their single resposibility work.