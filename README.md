# CPU Plays Pokemon

A fun little proof of concept for [mGBA-http](https://github.com/nikouu/mGBA-http) where it takes in your CPU usage as what button to press. 

https://github.com/nikouu/CPU-Plays-Pokemon/assets/983351/131ef1bb-1faf-4561-ad57-7fa482602e1c

_Video is sped up._

## How it works

Every second:
1. The CPU usage is checked
2. Some maths then the usage is mapped to a key
3. The key is sent to mGBA-http and onwards to mGBA

## Interesting bits
- Uses the new [`PeriodicTimer`](https://learn.microsoft.com/en-us/dotnet/api/system.threading.periodictimer?view=net-8.0) object
- The maths for the value to modulo is a mixture of both the whole and fraction because:
  - If just the whole value is used, then there may not be enough variation in CPU usage to modulo for all the keys
  - If it's just the fraction, the trailing zero is cut off, meaning we never get the A key

## Timelapse

The following is a whole hour of "playing" and "progress":

https://github.com/nikouu/CPU-Plays-Pokemon/assets/983351/fd20772f-a8d0-4de0-ac47-2375ba6562d4
