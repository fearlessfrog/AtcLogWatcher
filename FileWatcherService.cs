using System;
using System.IO;
using System.Timers;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.SignalR;

public class FileWatcherService
{
  private readonly IHubContext<MyHub> _hubContext;
  private string _filePath;
  private string _lastLineFilePath;
  private List<string> _filters;
  private System.Timers.Timer _timer;
  private bool _startLogging = false;
  private string _previousLine = null;
  private string _lastWrittenLine = null;
  private bool _debug = false; // Add a debug flag

  public FileWatcherService(IHubContext<MyHub> hubContext, string filePath, string lastLineFilePath, bool debug = false)
  {
    _hubContext = hubContext;
    _filePath = filePath;
    _lastLineFilePath = lastLineFilePath;
    _debug = debug;

    // Read filters from the config file
    _filters = new List<string>(File.ReadLines("filters.txt"));

    // Initialize the Timer
    _timer = new System.Timers.Timer(1000); // Set interval to 1 second
    _timer.Elapsed += OnTimedEvent;
    _timer.AutoReset = true;
    _timer.Enabled = true;
  }

  private void LogDebug(string message)
  {
    if (_debug)
    {
      Console.WriteLine(message);
    }
  }

  private async void OnTimedEvent(Object source, ElapsedEventArgs e)
  {
    //LogDebug("Timer event fired.");

    StreamReader reader = null;
    while (reader == null)
    {
      try
      {
        var fileStream = new FileStream(_filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
        reader = new StreamReader(fileStream);
      }
      catch (IOException ex)
      {
        LogDebug("File is being used by another process. Retrying..." + ex.Message);
        await Task.Delay(1000); // Wait and retry
      }
    }

    //LogDebug("Successfully opened file for reading.");

    var lines = await ReadLastLinesAsync(reader, 10); // Search the last 10 lines

    string line = lines.LastOrDefault(l => !_filters.Any(filter => l.Contains(filter)) || l.Contains("Speech Transcription Processed:"));

    if (line != null)
    {
      if (line.Contains("Speech Transcription Processed:"))
      {
        line = line.Replace("Speech Transcription Processed:", "").Trim();
        line = "> " + line;
      }
      if (line != _previousLine)
      {
        _previousLine = line;
        if (_previousLine != _lastWrittenLine)
        {
          await File.WriteAllTextAsync(_lastLineFilePath, _previousLine);
          await _hubContext.Clients.All.SendAsync("ReceiveUpdate", _previousLine);
          LogDebug($"Last line output: {_previousLine}");
          _lastWrittenLine = _previousLine;
        }
      }
    }
  }
  private async Task<List<string>> ReadLastLinesAsync(StreamReader reader, int lineCount)
  {
    var lines = new List<string>();
    string line;
    while ((line = await reader.ReadLineAsync()) != null)
    {
      lines.Add(line);
      if (lines.Count > lineCount)
      {
        lines.RemoveAt(0);
      }
    }
    return lines;
  }
}