## Task 1

- Analyze the given code snippet to find memory issues using Visual Studio's Diagnostic Tool.
- Identify optimization techniques to fix the memory problem.

### Code
```csharp
public void Allocate()
{
    while(true)
    {
        memalloc.Add(new int[1000]);
        Thread.Sleep(100);  
    }
}
```

### Observations
- The method `Allocate` uses an infinite `while(true)` loop.
- In each loop, it adds a new integer array of size 1000 to the list `memalloc`.
- After each addition, the method pauses for 0.1 second using `Thread.Sleep(100)`.

### Issue
- The loop never ends, so arrays keep getting added to `memalloc` without stopping.
- Memory usage keeps increasing as more arrays are added.
- Eventually, this can cause the application to run out of memory, leading to a memory leak.
- No mechanism exists to release or clear the memory used by the list.