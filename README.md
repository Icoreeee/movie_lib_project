![image](https://user-images.githubusercontent.com/61603558/216688737-effb995c-5aa3-4685-a001-3b17a487c89a.png)

## Table of Contents
* [General info](#general-info)
* [Technologies](#technologies)
* [Setup](#setup)

## General-info

### Goal
Design and implement an object-oriented movie library management system. The basic assumptions are given below:
1. System should contain core objects:
* Film (describes the single film)
* Category (contains films from a specific category),
* Library (stores shop catalogue by category)
* Application (the main object that provides interaction with the user)

2. Inheritance: design descendant objects from the Film object.

3. Enable basic operations on Films, Categories, Library.  Basic operations include:
* Adding object/collection of objects
* Deleting object/collection of objects
* Displaying object/collection of objects
* Searching/Filtering object/collection of objects

4. Additional functions of the program (for a score above 4.0)
* Design and implement interfaces. Base the entire system on the interfaces principle
* Perform write and read to file(s) (data persistence)
* Use "Dependency Injection" mechanisms, e.g. Singleton, Factory, Decorator (e.g. decorators for implementing operators “and”/”or” when searching)

### My solution
I create an application which contains:
1. Objects:
   * Movie (movie) - Has such properties as: Title (user-defined), Year (user-defined), Genre (selectable from a list of genres), Quality (selectable from a list of quality types).
   * Collection(Category) - Represents a personal collection with a list of movies for the user. Each user can create a collection for himself and put all the movies he wants in it.
   * Library(static class) - A list of collections. Designed to be the only example class containing all collections.
   * Application(static class) - a class from which the user manipulates all other objects.
2. Functionality:
   * Adding object/collection of objects
   * Deleting object/collection of objects
   * Displaying object/collection of objects
   * Auto-sort films by year
3. Additional functions:
   * Implemented [IComparable](https://learn.microsoft.com/en-us/dotnet/api/system.icomparable-1?view=net-7.0) interface for sorting in [movies](https://github.com/Icoreeee/movie_lib_project/blob/master/movie_lib/Movie.cs)
   * Implemented write and read to file via [Newtonsoft JSON](https://www.newtonsoft.com/json). 
   Files are saving in project folder -> bin -> Debug -> JsonFiles
   * Singleton

## Technologies
* [.NET 4.7.2](https://dotnet.microsoft.com/en-us/download/dotnet-framework/net472)
* [Newtonsoft JSON](https://www.newtonsoft.com/json) (For serializing and deserializing objects)

## Setup

1. Clone this repository
git clone https://github.com/Icoreeee/movie_lib_project.git
2. Run [Program.cs](https://github.com/Icoreeee/movie_lib_project/blob/master/movie_lib/Program.cs) file via your IDE
3. Done =)
