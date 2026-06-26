# Miside Zero Dialogue Override
A system of tools that will allow you to let characters say anything you want.

## Features
 - Allows you to use the currently unused Voiceover system!

 - Change text, expressions, chirp sounds, and more!

 - Features a graphical dialogue pack editor to make creating packs easy!

 - Preview how dialogue will sound directly in the editor, without ever opeing the game.

![Image showing funny dialogue haha](https://i.imgur.com/WLjs765.jpeg)

The editor has multiple themes. The light theme is the most stable (it is the normal win32 look), but the acrylic theme looks best imo

![](https://i.imgur.com/ZPPtScT.png)
## Installation

### Install the mod

1. Install Melonloader

2. Download the latest release of the override mod

3. Drag everything inside the "Mods" folder from the .zip into your game's Mods folder

4. Drag everything from the "UserLibs" folder from the .zip into your game's "UserLibs" folder

5. Inside your game's Mods folder, create a new folder called "mszdlg".
   
   > This folder is created automatically on game startup

6. Drag your .mszdlg file into this folder. 
   
   > You should ony put one dialogue pack. If you put more, the mod will just load the first one it finds. I might add a GUI to load the one you want in the future

### Install the GUI

Download MSZDialogueManager.zip from Releases, extract it, and run the exe. There is no installer. Don't keep it in your downloads folder ideally, since if you need to move it later file association behaior might be unexpected.

### For mod developers

You can use this mod to load your own packs. In `OnInitializeMelon`, set `Core.UserPacksEnabled` to false. This will prevent it from loading packs from the mszdlg folder. 

> Custom dialogue pack loading runs in `OnLateInitializeMelon`, so it is ok to disable it in `OnInitializeMelon`. Note that any loaded packs will not unload retroactively when you set `UserPacksEnabled` to false.

To load your own, call `Mod.LoadMszdlg()`:

```csharp
Mod.LoadMszdlg("your path here.mszdlg")
```

The mod will then use this pack like it would with any other.

If your mod interacts heavily with dialogue, you can use the included `DialogueEvents.OnNodePlayed` event instead of using Harmony.

```csharp
public static System.Action<DialogueNode> OnNodePlayed;
```

This is invoked every time `DialogueTree.PlayNode()` is called (on any DialogueTree). 

There are some other events in `DialogueEvents` that may be useful to you:

 - `OnPackLoaded`
 - `OnDialoguePatched`

## Building

1. Clone this repo

2. For any projects that use external references, you need to go into their csproj and change GamePath to match the root of where you installed your game. All game assemblies are relative to GamePath.

3. Build

4. Put the built dlls into your Mods folder

5. Put base.dll in Userlibs, or download it from https://www.un4seen.com/
   
   > If you're downloading it, click the win32 button on the top of the page. Inside bass24.zip you want the dll from the x64 folder.

# Original repositories
This repo is composed of serveral repositores that were merged together under the same solution. Here they are:

- https://github.com/Gameknight963/MSZDialogueManager

- https://github.com/Gameknight963/Miside-Zero-Dialogue-Override

- https://github.com/Gameknight963/MSZDialogueMapper
