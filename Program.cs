using System.Diagnostics;

// The code equivalent of a one page TTRPG

Console.Title = "CPU Plays Pokemon";

Console.WriteLine("""
    CPU Plays Pokemon! 
    Technically, CPU Plays anything to do with mGBA.

    Uses mGBA-http and your CPU usage to control mGBA.
    
    A fun proof of concept for mGBA-http.

    """);

// 0 for GBA, 1 for GB
var platform = 0;
var platformModulo = platform switch
{
    0 => 10,
    1 => 8,
    _ => throw new Exception("No platform")
};

var httpClient = new HttpClient();

// Post Framework, this needs to be added via nuget package
var cpuPerformanceCounter = new PerformanceCounter("Processor Information", "% Processor Time", "_Total");
cpuPerformanceCounter.NextValue();

// The new way of timers like this
var timer = new PeriodicTimer(TimeSpan.FromSeconds(1));

while (await timer.WaitForNextTickAsync())
{
    var cpuPercent = cpuPerformanceCounter.NextValue();
    var valueToUse = (int)Math.Truncate(cpuPercent) + int.Parse(cpuPercent.ToString().Split(".")[^1]);
    var keyInt = valueToUse % platformModulo;

    Console.WriteLine($"CPU%: {cpuPercent,10} (using {valueToUse,7}). Modulo {platformModulo} = {keyInt}: {(KeysEnum)keyInt}");

    await httpClient.PostAsync($"http://localhost:5000/mgba-http/button?key={(KeysEnum)keyInt}", null);

    //await httpClient.PostAsJsonAsync($"http://localhost:5000/mgba-http/button", (KeysEnum)keyInt);

}


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