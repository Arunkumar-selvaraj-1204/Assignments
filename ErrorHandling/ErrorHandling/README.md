# Error Handling

## Task1

&nbsp;&nbsp;The exception is handled by using try and except block. The try block is used to check the code for errors. The catch block is used to handle the error. If the code in the try block is error free, then the catch block will be skipped.In this ,The DivideByZeroException is handled when user input equals to zero.
<br>&nbsp;&nbsp; If divisor equals to zero, It will handle the exception.

## Task2

&nbsp;&nbsp;In Task2 , Another exception which is IndexOutOFRangeException is handled when the user input is out of range.
<br>&nbsp;&nbsp; If input is greater than array size while searching, It will handle the IndexOutOFRangeException,

## Task3

&nbsp;&nbsp;In Task3,An custom exception was created with class name "InvalidUserInputException" and it is used to handle when the user input is not a number.
<br>&nbsp;&nbsp; If user enters array length is less than or equals to zero, It will throw InvalidUserInputException.

## Task4

&nbsp;&nbsp;In Task4,A method with unhandled exception is written and uses the AppDomain's UnhandledException event to catch the unhandled exceptions globally.
<br>&nbsp;&nbsp; While find the index of the element, If user enters a non integer value such as string or char It will be handled by Global Exception handler.

## Task5

&nbsp;&nbsp;In Task5,The stack trace of the exception thrown was printed to the console

&nbsp;&nbsp;The stack trace message is given below:
"Unhandled exception caught : at ErrorHandling.IndexOutOfRange.GetIndex() in ..\ErrorHandling\IndexOutOfRange.cs:line 141
at ErrorHandling.IndexOutOfRange..ctor() in ..\ErrorHandling\IndexOutOfRange.cs:line 25
at ErrorHandling.Program.Main(String[] args) in ..\ErrorHandling\Program.cs:line 26"

&nbsp;&nbsp;This message shows that the initial call is from the creating an object for IndexOutOfRange and then it's constructor call the GetIndex function where the exception thrown in line 141.
