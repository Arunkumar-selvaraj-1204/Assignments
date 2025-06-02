## TASK 3

- The goal is to explain why changes were made to the code for better optimization and how these changes solve the memory issue.

### Before Optimization

- The `Allocate` method used a `while` loop to keep adding integer arrays to a list.
- Execution was paused for 0.1 seconds in each loop iteration.
- There was no limit on how many arrays could be added, causing memory usage to keep increasing.
- The Visual Studio Diagnostic Tool showed continuous memory growth, leading to a memory leak.
- ![image](https://github.com/user-attachments/assets/5c3c0395-39fe-4196-b799-96ff42085050)

### Optimized Code Implementation

- The `while` loop was replaced with a `for` loop that runs for a set number of times.
- This ensures the loop will stop after adding a certain number of arrays to the list.
- Now, the code does not add arrays endlessly and memory usage is controlled.

### After Optimization

- Memory is no longer consumed without limit.
- The code prevents memory leaks by limiting the number of arrays added.
- The Diagnostic Tool now shows stable memory usage without continuous increase.
- ![image](https://github.com/user-attachments/assets/891a6681-579d-4fa9-b404-ae7db77639d4)