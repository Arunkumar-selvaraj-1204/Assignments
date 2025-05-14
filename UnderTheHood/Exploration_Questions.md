### Task 10 - Understanding the .NET platform 

1. Explain what the .NET platform is and its primary purpose.
<br> &emsp; The .NET platform is a development framework developed by Microsoft that provides the execution runtime (CLR) and the set of standard libraries that are required for the development of applications in C# and other .NET compatible languages such as F#, Visual Basic, Iron Python, etc.
 
2. What are the key components of the .NET platform? 
<br> &emsp; The key components of .NET platfrom are - CLR (Common Language Runtime) and FCL (Framework Class Library). 
<br> &emsp; CLR is the runtime environment for managing the exectuion of .NET applications. It is also responsible for performing various low-level tasks such as managing the memory, providing error handling, dealing with thread, and garbage collection. 
<br> &emsp; FCL contains various classes, interfaces and data types required to implement different functions and develop different types of applications such as desktop applications, web application, or mobile applications.
 
3. Differentiate between the Common Language Runtime (CLR) and the Common Type System (CTS) in .NET. 
<br> &emsp; CLR - Common Language Runtime is the runtime for executing the .NET programs. It performs the low-level tasks required by the program such as managing the memory, providing error handling, dealing with thread, and garbage collection.
<br> &emsp; CTS - Common Type System describes the set of data types that can be used by more than one language in common and how they are declared, used and stored in the runtime. The basic category of data types are: Value types, and Reference types. For example, C# has the data type int, VB.NET has the data type Integer, both of which uses the Int32 structure of CTS, thus they can interact with each other.
 
4. What is the role of the Global Assembly Cache (GAC) in .NET? 
<br> &emsp; In C#, an assembly is the set of code, the data and other resources required for the execution of a functionality. It can either be a Dynamic Link Library (DLL) or an executable file. If an assembly is used by more than one application, it is known as a shared assembly. Global Assembly Cache is the memory where the shared assemblies are stored. The assemblies stored in GAC are available globally to all the applications present in the machine.  
 
5. Explain the difference between value types and reference types in C#. 
<br> Value Types 
<br> &emsp; They follow value semantics. The only way to modify the value of a variableis through the variable itself.
<br> &emsp; The values stored in the variable are independent of other variables.
<br> &emsp; They are derived from the System.ValueType class.
<br> &emsp; Value types are stored in the stack.
<br> &emsp; Example of value types in C# are all built-in types such as int, decimal, bool, DateTime, etc and all structs.
<br> Reference Types
<br> &emsp; They follow reference semantics. The variables of this type stores an identity of some object, called the reference and not a value.
<br> &emsp; The values stored in the varibale is dependent on other variable.
<br> &emsp; They are derived from the System.Object class.
<br> &emsp; For reference type varibles, the reference is stored in stack and the variable values are stored in heap.
<br> &emsp; Examples of reference types in C# are List, array, strings, etc and all classes.
 
6. Describe the concept of garbage collection on .NET and its advantages. 
<br> &emsp; Garbage collection in .NET is the process of managing memory and automatically freeing up memory that is no longer used by the application. Garbage collector scans the application memory from time to time and removes the objects that are not in use. 
<br> &emsp; Garbage collection in .NET has three phases - Marking phase, Relocating Phase and Compacting Phase. 
<br> &emsp; &emsp;In Marking phase, the live objects that are used by the application are marked and the objects that are no more in use are deleted from the memory. 
<br> &emsp; &emsp; In relocating phase, the references to live objects are updated to point the locations the live object will be present in after the garbage collection. 
<br> &emsp; &emsp; In Compacting phase, the memory of deleted objects is freed and the live objects are moved to an end of the heap.   
 
7. What is the purpose of the Globalization and Localization features in .NET? 
<br> &emsp; Globalization in .NET is the process of developing application that can be used uniformly across regions, languages and cultures without having to change the code everytime. Localization is about developing applications that are specific to the needs of a particular region or culture. 
<br> &emsp; The different features of .NET that support Globalization and Localization are the availability of methods to handle different date and time formats, number systems and calendars, and the use of Resource files that can help provide services on the user's language settings.
<br> &emsp; The purpose of globalization and localization is to develop applications that are adaptable to different regions and cultures easily without requiring large changes to the code.
 
8. Explain the role of the Common Intermediate Language (CIL) and Just-In-Time (JIT) compilation in the .NET framework. 
<br> Common Intermediate Language
<br> &emsp; CIL represents the set of instructions generated by compiling the source code of a .NET language such as C#, VB.NET, etc. 
<br> &emsp; The CIL code is then converted to binary code during runtime for program execution.
<br> Just-In-Time Compilation
<br> &emsp; Compiles CIL code to binary code at runtime.
<br> &emsp; Generates code that is specific to the machine on which the code is to be run. 
<br> The process of program execution from the source code is as follows:
<br> &emsp; Source code is converted into CIL by the source language compiler.
<br> &emsp; The CIL code is passed to the JIT compiler during the runtime.
<br> &emsp; JIT converts the CIL code to binary code compatible with the machine and the program is executed.
 