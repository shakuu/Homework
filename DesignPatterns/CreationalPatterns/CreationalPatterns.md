# Creational Patterns Homework

*   Select 3 creational design patterns
    *   Write a short description (about half page) for each of them
        *   Describe their motivation, intent, applicability, known uses, implementation, participants, consequences, structure, related patterns, etc.
        *   Use [Markdown](https://help.github.com/articles/github-flavored-markdown/) for the description (`.md` files) and upload it on your own GitHub
        *   Prefer Bulgarian language
    *   Provide your own C# examples for their use
    *   Provide a UML diagram or image of the pattern

# Singleton

A class with a private or protected constructor and a static field and/ or property providing an instance of the said class.

The goal is to ensure the existence of a single instance in case that's a requirement or to communicate clearly the intent of using a single instance, in case having multiple ones is acceptable, but not necessary.

Downside - it's static. 

# Factory Method

An abstract / virtual method in a base class. Lets subclasses initialize the their own specific dependencies.

Creates parallel inheritence hierarchies. 

# Abstract Factory


