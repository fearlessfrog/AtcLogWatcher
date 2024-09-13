---

# ARCHIVED - See BATC for released VR Toolbar

---

# ATC Log Watcher

![MSFS ATC Log Watcher](https://i.imgur.com/mI7TMuu.jpeg)

Simple companion app for [MSFS Toolbar ATC Log Viewer](https://github.com/fearlessfrog/msfs2020-toolbar-atclogviewer)

## Features

Temporary solution to supply ATC log entries in real time as they are written to the log file. For use with the MSFS Toolbar ATC Log Viewer.

## Overview

```
┌──────────────────┐                ┌──────────────────────┐
│                  │                │                      │
│   A Log File     │                │     MSFS Toolbar     │
│                  │                │                      │
└────────┬─────────┘                └──────────▲───────────┘
         │                                     │
         │                                     │
┌────────▼─────────┐                ┌──────────┴───────────┐
│                  │                │                      │
│  ATC Log Watcher ├────────────────►     ATC Log Viewer   │
│                  │                │                      │
└──────────────────┘                └──────────────────────┘
```

## FAQ

Q - What is this for?

A - The original need is that [Beyond ATC](https://www.beyondatc.net/) (BATC) doesn't show an in-sim toolbar making it hard to use in VR. [Pilot2ATC](https://pilot2atc.com/) had a 'conversation log' that could be used to get around this, so it's sort of the same idea. It shows the ATC conversation in native MSFS UI, so you can see it in VR.

Q - So this is a hack?

A - Yes, very much so. The [most voted feature](https://beyondatc.nolt.io/12) to be added to the early access version of BATC is the in-game toolbar. So not only is this a hack, but it's *temporary* until that comes along. This is not endorsed, approved, acknowledged by Beyond ATC's Skirmish Mode Games in any way. BATC will probably change their log files over time and this might break. A log file is not a publicly supported interface. If this breaks and it is still useful then I might fix it up, or just check out if you can do so yourself in the supplied filters.txt. 

Q - Should I use this?

A - Probably not. Here's other ways to do this:

a. Check out VSR for VATSIM that now includes an early BATC message log support. VSR is great if you want to use VATSIM and BATC, or want to eventually do that. It combines the two, useful when real life controllers aren't around. Check it out here - [VSR for VATSIM](https://vsr.readthedocs.io/en/latest/).

b. Show the BATC window in VR. A free way to do this is [OpenKneeboard](https://openkneeboard.com/). This relays the 2D window into a VR tablet view. There is no input, and positioning it can be tricky but it works well. There are other paid apps like [FSDesktop](https://fsdesktop.com/) etc that offer similar things. Plus of course your native VR ability to view desktops/windows in VR.

Q - So I shouldn't use this, huh?

A - It's super simple and if you don't want to use the above then you're welcome to this. It was the fruits of about 4 hours effort on a Sunday morning when because it was raining I convinced myself that I shouldn't go for a run.

Q - I have a support issue!

A - Don't we all.

## Usage

See `filter.txt` for filtered out entries or just use the Clear button in the toolbar. Update filters as needed over time.
Create a `logfile_location.txt` file to point to a new logfile location, but a default one is assumed under your userprofile.
Use the ATCLogWatcher/AtcLogWatcher.exe to run the watcher app. Close/re-open toolbar in the sim to refresh.
Requires [.NET 7.0 runtime](https://dotnet.microsoft.com/en-us/download/dotnet/7.0), which you probably already have, but if anything doesn't work then that's probably it.

## Installation

Latest release is available in the [Releases](https://github.com/fearlessfrog/AtcLogWatcher/releases/).
Place the extracted release zip contents into your MSFS Community folder location. If you're not sure what or where that is then this might not be the temporary solution for you.
To uninstall everything, just remove the folder from the Community folder.

## License

MIT License, no warranty, use at your own risk. See [License](https://github.com/fearlessfrog/AtcLogWatcher/blob/main/LICENSE) for details.

## Build

Install the .NET 7.0 SDK.
Use `dotrun run` or see `publish.cmd` for release building.
For ATC Log Viewer toolbar, see `build.bat`, requires MSFS SDK installed.

Copyright (c) 2024 fearlessfrog
