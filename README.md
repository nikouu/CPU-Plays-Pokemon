# CPU Plays Pokemon

A fun little proof of concept for [mGBA-http](https://github.com/nikouu/mGBA-http) where it takes in your CPU usage as what button to press. 

https://github.com/nikouu/CPU-Plays-Pokemon/assets/983351/3ca74ae2-1c7c-41e4-a104-7cd4c9fa328c

_Video is sped up._

## How it works

Every second:
1. The CPU usage is checked
2. Some maths then the usage is mapped to a key
3. The key is sent to mGBA-http and onwards to mGBA

## How to run
1. Have mGBA up and running
1. Get and setup [mGBA-http](https://github.com/nikouu/mGBA-http)
1. Get this project
2. Run this project (either in Visual Studio/your IDE of choice, or with `dotnet run`)

## Interesting bits
- Uses the new [`PeriodicTimer`](https://learn.microsoft.com/en-us/dotnet/api/system.threading.periodictimer?view=net-8.0) object
- The maths for the value to modulo is a mixture of both the whole and fraction because:
  - If just the whole value is used, then there may not be enough variation in CPU usage to modulo for all the keys
  - If it's just the fraction, the trailing zero is cut off, meaning we never get the A key
- [`PerformanceCounter`](https://learn.microsoft.com/en-us/dotnet/api/system.diagnostics.performancecounter?view=dotnet-plat-ext-8.0) is now a NuGet package

## Timelapse

The following is a whole hour of "playing" and "progress":


https://github.com/nikouu/CPU-Plays-Pokemon/assets/983351/8ae1b4fe-04d7-4f05-8ae6-890ae5ef0213
