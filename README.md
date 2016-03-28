# XML-to-CSV

Description
-----------

This project aims to convert a specific task in xml format file to an organzied csv file. The input and output format
can be found from the __sample_data.xml__ and __sample_data.csv__, respectively.

The requirement of this task are:
* Outputs the data in a CSV (comma separated values) format.
* The program should take the input (XML) and output (CSV) file names as arguments.
* In C# language
* Program must compile and execute with no errors.

Thought
----

1. The sample_data might be in scale of gigabytes or terabytes, so the conversion have to be done at least
in a streaming tranform method.
A distributed solution with hadoop on C# might be a better solution for a large document.
2. Future conversion task maybe use different formats for different problems, the code should be developed in a manner of easy to extent.

