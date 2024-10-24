# SIMCITY.exe Debugging and Registration Bypass

This guide will walk you through debugging SIMCITY.exe and bypassing the registration check to get the game running.

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

![Call Stack Trace](https://femboylover.com/arqqc7ix.png)

At this point, it's clear that the executable is checking the registry for a registration key. We can now use ProcMon to track what the game is trying to access.

## Tracking Registry Access with ProcMon

In ProcMon, we see that SIMCITY.exe is trying to load a mayor name, but we haven't created one yet.

![ProcMon Trace](https://femboylover.com/g5ms3924.png)

### Creating a Mayor Name

We’ll quickly create a mayor name using `regedit`.

![Registry Entry for Mayor Name](https://femboylover.com/pqziseyt.png)

With this step completed, new folders appear in the registry.

![New Registry Folders](https://femboylover.com/e3evt79h.png)

## Handling the New Error: Missing `DATA_usa.DAT`

After creating the mayor name, we hit a new error, this time about `DATA_usa.DAT`.

![New Error](https://femboylover.com/gfs6ikcg.png)

In ProcMon, we see the game trying to load this specific file.

![ProcMon Trying to Load DATA_usa.DAT](https://femboylover.com/2yv9ekth.png)

### Fixing the Issue

To resolve this, we need to add the `DATA_usa.DAT` file to the newly created folder.

![Adding DATA_usa.DAT](https://femboylover.com/phhkwixw.png)

## Finally, the Menu Appears!

After resolving the missing file, we finally reach the game menu with our new mayor name.

![Game Menu](https://femboylover.com/7bogvlgw.png)

## Fixing the Graphics Issues

Upon loading a game, the colors are completely off. Let's dive deeper to understand why.

![Color Issues](https://femboylover.com/fe4krvtf.png)

### Investigating Graphics Settings in IDA

By exploring the strings in IDA, we find a function that loads `GRAPHICS` and `pal_mstr.bmp`.

![IDA Pseudocode for Graphics](https://femboylover.com/btrh6cfa.png)

### Setting the Graphics Path in the Registry

We’ll copy the correct path to the `bitmaps` folder and create a new key in `regedit` for the graphics.

![Registry Key for Graphics](https://femboylover.com/9tltnald.png)

## Success! Colors Restored

Finally, with the correct graphics settings, we restore the game’s color.

![Colors Restored](https://femboylover.com/alm2bnji.png)
