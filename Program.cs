using System.Diagnostics;

// The code equivalent of a one page TTRPG

Console.WriteLine("""
    CPU Plays Pokemon! 
    Technically, CPU Plays anything to do with mGBA.

    Uses mGBA-http and your CPU usage to control mGBA.
    
    A fun proof of concept for mGBA-http.

    """);

var percentagePart = PercentagePart.Fraction;
var platform = 1;
var platformModulo = platform switch
{
    0 => 10,
    1 => 8,
    _ => throw new Exception("No platform")
};

// Post Framework, this needs to be added via nuget package
var cpuPerformanceCounter = new PerformanceCounter("Processor Information", "% Processor Time", "_Total");
cpuPerformanceCounter.NextValue();

// The new way of timers like this
var timer = new PeriodicTimer(TimeSpan.FromSeconds(1));

while (await timer.WaitForNextTickAsync())
{
    var cpuPercent = cpuPerformanceCounter.NextValue();
    var valueToUse = GetUsableCpuValue(percentagePart, cpuPercent);
    var keyInt = valueToUse % platformModulo;

    Console.WriteLine($"CPU%: {cpuPercent,9} (using {valueToUse,6}). Modulo {platformModulo} = {keyInt}: {(KeysEnum)keyInt}");
}

int GetUsableCpuValue(PercentagePart percentagePart, float cpuPercent) => percentagePart == PercentagePart.Whole 
    ? (int)Math.Truncate(cpuPercent) 
    : int.Parse(cpuPercent.ToString().Split(".")[^1]);

enum KeysEnum
{
    A,
    B,
    Select,
    Start,
    Right,
    Left,
    Up,
    Down,
    R,
    L
}

enum PercentagePart
{
    Whole,
    Fraction
}
