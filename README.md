# CocomoCalculator
## What is Cocomo?

**Cocomo** (_Constructive Cost Model_) is a method for estimating the cost of software development developed by Barry Boehm.

This project include four version of the COCOMO calculator:
  1. **Basic Cocomo** (_BasicCocomoCalculator class_) - Cocomo's basic model assumes that effort only depends on the number of lines of code and some constants evaluated according to different software systems. However, in reality, no effort and system schedule can be calculated solely on the basis of lines of code;
  2. **Imtermediate Cocomo** (_ImtermediateCocomoCalculator class_) - In the intermediate model, to refine the calculation, in addition to the basic attributes, 15 more factors are used to estimate costs;
  3. **Cocomo II** - Cocomo 2 is a revised version of the original Cocomo (_Constructional Value Model_) developed at the University of Southern California. This model calculates development time and effort as the sum of the estimates of all individual subsystems. In this model, all software is divided into different modules. Examples of projects based on this model are spreadsheets and a report generator. The program implements two stages of project evaluation: a **preliminary evaluation** (_EarlyDesignCocomoCalculator class_) at the initial stage and a **detailed evaluation** (_PostArchitectureCocomoCalculator class_) after the development of the architecture.;

## About project
The project is completely written in C# using Windows Forms. The project used the Model-View-Presenter pattern (_CocomoCalculator-MainViewer-MainPresenter classes_). External data stores in the form of csv extension files are also used to work with tabular data (_FileManager class_).
