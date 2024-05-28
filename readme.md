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

## Usage

See filter.txt for filtered out entries.
Use ATCLogWatcher.exe to run the app.
Requires .NET 7.0 runtime, which you probably already have.

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
