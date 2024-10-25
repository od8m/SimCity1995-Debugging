# SIMCITY.exe Debugging and Registration Bypass

This guide will walk you through debugging SIMCITY.exe and bypassing the registration check to get the game running.

**Note:** The version of SimCity used in this guide is available at [https://archive.org/details/sc2000_win95](https://archive.org/details/sc2000_win95). 

The keygen will only work if the `win95` folder is located on your desktop.

## Initial Message Box Error

Upon launching `SIMCITY.exe`, we encounter the following error message indicating that the game hasn't been registered with the system.

![Error Message](https://github.com/user-attachments/assets/717fc6bb-0b3a-4130-94b9-f64e03481554)

### Debugging with x32dbg

To investigate, we'll set a breakpoint inside `user32.dll` for `MessageBoxA` using x32dbg.

![x32dbg MessageBoxA Breakpoint](https://github.com/user-attachments/assets/802876a2-4d26-432a-b6f7-5cf65183c158)

After running the executable, we hit the breakpoint.

![Breakpoint Hit](https://github.com/user-attachments/assets/76d3fc6b-39f6-47e4-91e6-8ac65a5a4773)

### Examining in IDA

Next, let's copy the offset and inspect the code in IDA. We find this snippet:

![IDA Disassembly](https://github.com/user-attachments/assets/a01170b1-3458-43b2-aaa3-5eebf29d00e6)


This section checks if the `0x400` bit is set in `result`. If true, it sets `this[0x1A]` to `0xFFFFFFFF`, which is likely responsible for triggering the message box.

### Tracing the Call Stack

By tracing the call stack, we find additional clues:

![Call Stack Trace](https://github.com/user-attachments/assets/ebd56d1d-2e11-4b77-a2dc-02ddd6893889)


At this point, it's clear that the executable is checking the registry for a registration key. We can now use ProcMon to track what the game is trying to access.

## Tracking Registry Access with ProcMon

In ProcMon, we see that SIMCITY.exe is trying to load a mayor name, but we haven't created one yet.

![ProcMon Trace](https://github.com/user-attachments/assets/eb5f25bd-4faa-44c7-b56e-e4b6034deaa8)

### Creating a Mayor Name

We’ll quickly create a mayor name using `regedit`.

![Registry Entry for Mayor Name](https://github.com/user-attachments/assets/acf1301e-d024-4ae9-8467-688351a01a48)


With this step completed, new folders appear in the registry.

![New Registry Folders](https://github.com/user-attachments/assets/674616dd-e715-4cdd-bce3-804613714f85)

## Handling the New Error: Missing `DATA_usa.DAT`

After creating the mayor name, we hit a new error, this time about `DATA_usa.DAT`.

![New Error](https://github.com/user-attachments/assets/3dca13b1-8915-472a-9b4f-c573838e0a99)

In ProcMon, we see the game trying to load this specific file.

![ProcMon Trying to Load DATA_usa.DAT](https://github.com/user-attachments/assets/16f538ee-49da-40eb-9749-5e1f201f9fc4)

### Fixing the Issue

To resolve this, we need to add the `DATA_usa.DAT` file to the newly created folder.

![Adding DATA_usa.DAT](https://github.com/user-attachments/assets/253a562a-83b7-4d8a-9758-f44882a92ade)

## Finally, the Menu Appears!

After resolving the missing file, we finally reach the game menu with our new mayor name.

![Game Menu](https://github.com/user-attachments/assets/4cd53a96-aef8-44e1-be88-b03e193b1b3a)
![Load City](https://github.com/user-attachments/assets/d6030e76-6c86-45b4-a671-dbda44d17112)

## Fixing the Graphics Issues

Upon loading a game, the colors are completely off. Let's dive deeper to understand why.

![Color Issues](https://github.com/user-attachments/assets/7d8c4b7f-88de-4db7-8483-d4b29f6702c9)

### Investigating Graphics Settings in IDA

In IDA, by examining the strings and xrefing `GRAPHICS`, then pressing F5 to view the pseudocode, we can see that the function `sub_402c11` loads both `GRAPHICS` and `pal_mstr.bmp`.

![IDA Pseudocode for Graphics](https://github.com/user-attachments/assets/1188eca2-cc6e-4abc-8438-dd280482ac62)

### Setting the Graphics Path in the Registry

We’ll copy the correct path to the `bitmaps` folder and create a new key in `regedit` for the graphics.

![Registry Key for Graphics](https://github.com/user-attachments/assets/7dbba36b-ef17-485a-90a9-4d55794e30f3)

## Success! Colors Restored

Finally, with the correct graphics settings, we restore the game’s color.

![Colors Restored](https://github.com/user-attachments/assets/8ff3d8d2-d559-47ee-87e0-df34e0c233fe)

Copyright (C) 2019 - 2024 Casper <od8m@users.noreply.github.com>

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program.  If not, see <https://www.gnu.org/licenses/>.


## Now for the Keygen
[Short Youtube Video](https://www.youtube.com/watch?v=zjqOULzycig)
