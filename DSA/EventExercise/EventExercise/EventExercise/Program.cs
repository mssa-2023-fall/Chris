﻿using System.IO;
using System.Threading.Channels;
using System.Timers;

//TimerSample();
FileSystemWatcherSample();

void FileSystemWatcherSample()
{
    // create instance of FSW, supply directory to watch
    // 
    using var watcher = new FileSystemWatcher(@"C:\test");
    // configure watch to notify on changes of the following attributes
    // | is a bitwise or to combine the properties to monitor for changes
    watcher.NotifyFilter = NotifyFilters.Attributes
                         | NotifyFilters.CreationTime
                         | NotifyFilters.DirectoryName
                         | NotifyFilters.FileName
                         | NotifyFilters.Size;
    // connect event handler to the events raised by the FSW
    watcher.Changed += (s, arg) => Console.WriteLine($"{arg.Name} modified");
    watcher.Created += (s, arg) => Console.WriteLine($"{arg.Name} created");
    watcher.Deleted += (s, arg) => Console.WriteLine($"{arg.Name} deleted");
    watcher.Renamed += (s, arg) => Console.WriteLine($"{arg.Name} renamed");
    watcher.EnableRaisingEvents = true;
    Console.WriteLine("Press enter to stop the program");
    Console.ReadLine();
}

void Handler(object s, ElapsedEventArgs arg)
{
    Console.WriteLine($"Timer with following interval:{(s as System.Timers.Timer).Interval}-{arg.SignalTime}");
}

void TimerSample()
{
    System.Timers.Timer aTimer = new System.Timers.Timer();
    aTimer.Interval = 2000;

    // Hook up the Elapsed event for the timer. 
    aTimer.Elapsed += (s, arg) => Console.WriteLine($"Timer is enabled:{(s as System.Timers.Timer).Enabled} last fired at:{arg.SignalTime} ");
    aTimer.Elapsed += Handler;
    //this is also referred to as callback in javascript
    // Have the timer fire repeated events (true is the default)
    aTimer.AutoReset = true;

    // Start the timer
    aTimer.Enabled = true;

    Console.WriteLine("Press the Enter key to remove Handler from Elaped Delegate");
    Console.ReadLine();
    aTimer.Elapsed -= Handler;

    Console.WriteLine("Press the Enter key to end the program");
    Console.ReadLine();
}