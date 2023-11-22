# Gilded Rose starting position in Csharp Core

## Project Structure

### GildedRose
Contains the business logic in a class library project

The "Constants" repository groups all static classes that expose constant value to avoid using magic strings/values

### GildedRoseTests
The "GildedRoseTests.cs" file contains all written unit tests.
*After completing the exercice, I realised that I have missed some test cases*
*Unfortunately, I couldn't make TextTest works to tests the final result

## Build the project

Use your normal build tools. 

## Run the project

The project is a class library project. It cannot be run as is. To make it run, you can either use it in unit tests or write an application (console, web...) and use
the GildedRose project as a dependency

## Run the unit tests

Unit tests are written with NUnit framework. 

- Use your favorite IDE to run GildedRoseTest.cs to execute the unit tests. 
- Use nunit3-console.exe in a command line tool to execute the unit tests. https://docs.nunit.org/articles/nunit/running-tests/Console-Runner.html

## Run the TextTest fixture from the Command-Line
*This part was already written in the file. Even if I couldn't make it work on my side, I left it in the read me*

For e.g. 10 days:

```
GildedRoseTests/bin/Debug/net7.0/GildedRoseTests 10
```

You should make sure the command shown above works when you execute it in a terminal before trying to use TextTest (see below). If your tooling has placed the executable somewhere else, you will need to adjust the path above.


## Run the TextTest approval test that comes with this project

There are instructions in the [TextTest Readme](../texttests/README.md) for setting up TextTest. You will need to specify the GildedRoseTests executable and interpreter in [config.gr](../texttests/config.gr). Uncomment this line:

    executable:${TEXTTEST_HOME}/csharpcore/GildedRoseTests/bin/Debug/net7.0/GildedRoseTests


