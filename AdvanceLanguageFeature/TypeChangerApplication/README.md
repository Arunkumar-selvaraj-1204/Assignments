# Difference Between `var` and `dynamic` Keyword in C#

## Overview

Both `var` and `dynamic` are keywords in C# that allow for flexible variable declaration, but they serve different purposes and behave differently at compile time and run time.

---

## `var` Keyword

- **Type Inference at Compile Time**:  
  When you use `var`, the compiler determines the variable's type at compile time based on the assigned value.

- **Strongly Typed**:  
  After the type is inferred, it becomes strongly typed, and you cannot assign a value of a different type later.

- **Requires Initialization**:  
  You must initialize a `var` variable at the time of declaration.

- **Compile-Time Checking**:  
  Errors are caught at compile time.

**Example:**
```csharp
var number = 10;           // int
var name = "Hello";        // string
number = "world";          // Compile-time error
```

---

## `dynamic` Keyword

- **Type Resolution at Run Time**:  
  `dynamic` tells the compiler to skip type checking at compile time. The type is resolved at run time.

- **Not Strongly Typed**:  
  You can assign any type of value to a `dynamic` variable, and its type can change during the program execution.

- **No Compile-Time Checking**:  
  Errors related to invalid operations will only appear at run time.

- **Useful for Interoperability**:  
  Often used when working with COM objects, dynamic languages, or reflection.

**Example:**
```csharp
dynamic value = 10;       // int at run time
value = "Hello";          // now string at run time
value.NonExistentMethod(); // Run-time error, not compile-time
```

---

## Key Differences Table

| Aspect                  | `var`                                  | `dynamic`                               |
|-------------------------|----------------------------------------|-----------------------------------------|
| Type determined at      | Compile time                           | Run time                                |
| Type safety             | Yes (strongly typed)                   | No (weakly typed)                       |
| IntelliSense Support    | Yes                                    | Limited                                 |
| Compile-time checking   | Yes                                    | No                                      |
| Run-time errors         | No (type errors caught at compile)     | Possible (type errors at run time)      |
| Use Cases               | Known types, LINQ queries, collections | Interop, reflection, dynamic languages  |
| Requires initialization | Yes                                    | No                                      |

---

## Summary

- Use `var` when the type is obvious or easily inferred and you want compile-time type safety.
- Use `dynamic` when you need maximum flexibility and are working with types not known until run time, but be cautious of run-time errors.