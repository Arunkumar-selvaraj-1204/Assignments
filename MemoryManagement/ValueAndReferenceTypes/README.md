## Assignment 11 - Memory Management in C#
 
### Task 1 - Understanding and using Value Types and Reference Types in C#
Created a class Person with the fields name and age. In the Program class created a method "IncrementByOne" that takes an integer, and an object of the Person class as parameters and increments the value of the number and the person's age by one. In the Main method, created an integer, an object of Person and called the method by passing the parameters. The value of the integer was unchanged even though it's value was incremented in the method. The value of the person's age was different after the function call. 
The integer is a value type. Every time we access the integer, we access its value. For instance, if the value passed to the function is 5 and it is incremented to 6, the changes are only local to the method. Once the scope is out of the method, the change in the value is not reflected.
The person object is of reference type. We access the object through its address. The reference(address) of the object is passed to the method. As a result, any changes made to the object inside the method will be reflected out of the method as well.
 
### Task 2 - Working with the Stack and the Heap
Created two methods - SumOfIntegers() and SumOfArrayElements(). SumOfIntegers method prompts the user to enter the count n, n numbers and then computes the sum of the entered numbers. SumOfArrayElements method prompts the user for the size of an array, the array elements and then computes the sum of the array elements. When the performance of the program is analyzed using the Visual Studio Diagnostic Tool, as the size of the array increases, the heap size also increases, which shows that the reference types are allocated memory in the heap.
 
&emsp; &emsp; &emsp; &emsp; &emsp; &emsp; &emsp; &emsp; &emsp; Sample table of GC Heap size (in MiB)
 
| S.No | Array Size | Minimum | Maximum |
| ---- | ---------- | ------- | ------- |
|   1  |     5      |  1.21   |  1.28   |
|   2  |    10      |  1.21   |  1.39   |
|   3  |    50      |  1.21   |  1.47   |
|   4  |   150      |  1.21   |  1.73   |
|   5  |   200      |  1.21   |  1.93   |
|   6  |   500      |  1.21   |  2.52   |
 
 
### Task 3 - Using Garbage Collection and Understanding its Impact on Performance
In a loop, created a person object and called a function that increments the person's age, and then set the object to null, to make it eligible for garbage collection. Analyzed the memory usage in Visual Studio Diagnostic Tools and Performance Profiler. Then called the GC.Collect method to trigger garbage collection. After Garbage Collection, the memory usage drops and becomes consistent.
 
&emsp; &emsp; &emsp; &emsp; &emsp; &emsp; &emsp; &emsp; &emsp; Sample table of Total Memory
 
| Iteration | Before Object Creation | After Object Creation | After Garbage Collection |
| --------- | ---------------------- | --------------------- | ------------------------ |
|     1     |        1126312         |       1174920         |            458616        |
|     2     |         459096         |        508400         |            515208        |
|     3     |         523432         |        580920         |            518456        |
|     4     |         522488         |        563608         |            550096        |
|     5     |         562352         |        660104         |            614840        |
|     6     |         627096         |        659968         |            646864        |
|     7     |         659120         |        691992         |            678864        |
|     8     |         691120         |        723992         |            710864        |
|     9     |         723120         |        895312         |            809000        |
|    10     |         821256         |        854128         |            841312        |
 
 
### Task 4 - Implementing and Understanding the IDisposable Interface and the 'using' statement.
Created a class FileOperation implementing the Dispose method of the IDisposable interface. In the Main method, opened the file in the using block to ensure that the object is released after its use. After the using block, accessed the file for reading to ensure that it was properly released.