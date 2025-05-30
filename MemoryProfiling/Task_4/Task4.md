# Reflection on the Assignment

- The assignment gave practical experience with memory management.
- Learned to use Diagnostic Tools in Visual Studio for analyzing memory issues.

## Code Analysis

- The provided code had a class with a list of integer arrays.
- The `Allocate` method kept adding integer arrays to the list in an infinite loop.
- Execution paused for 0.1 second in each loop iteration.
- This caused memory usage to increase without limit, as shown by the Diagnostic Tool.
- The result was a memory leak.

## Memory Profiling

- Used Visual Studio's built-in Diagnostic Tools to analyze memory usage.
- Found that heap memory usage kept rising due to the endless loop.

## Optimized Code Implementation

- Changed the infinite `while` loop to a `for` loop with a set number of iterations.
- The new approach ensures the loop stops after a certain point.
- Prevents the list from growing without limit and keeps memory usage in check.

## After Optimization

- The code no longer consumes unlimited memory.
- Memory leaks are avoided.
- The Diagnostic Tool now shows stable memory usage without continuous increase.