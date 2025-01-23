#### I just want to download it
See [this](https://github.com/Avaluate/MultipleRobloxInstances/releases/tag/V1 "here") or look at Releases. This works as of 14 July 2024.

## Multiple Roblox Instances
This program allows you to run 2 or more different Roblox accounts at the same time.

This is not explicitly against the Roblox Terms of Service. Applications such as Bloxstrap had similar functionality. 

Bloxstrap removed the multiple Roblox instances feature due to fears people were [using it to farm](https://github.com/pizzaboxer/bloxstrap/wiki/Plans-to-remove-multi%E2%80%90instance-launching-from-Bloxstrap) and well as their implementation of multiple Roblox instances being a "hit or miss".

[![](https://i.imgur.com/el2EOj2.png)](https://i.imgur.com/el2EOj2.png)

#### Current problems
- Teleporting between places in a universe (for example, between different worlds in a game, or joining a lobby) won't work
- However, teleporting between different games still works

#### How this works
Note: although the program already states this, closing the program will close all but one of the Roblox windows.

You can see how this works in [program.cs](https://github.com/MainDabRblx/MultipleRobloxInstances/blob/main/Program.cs "program.cs"). 

It boils down to this :
```csharp
new Mutex(true, "ROBLOX_singletonMutex");
```

What this does is essentially locking the Roblox thread. Logically speaking because of this, Roblox isn't able to make a new mutex (or rather, because an existing one already exists). 

#### Can I use this in my program?
Yes.

#### Brief history
I had originally made this for [MainDab](https://github.com/Avaluate/MainDab "MainDab"), a keyless Roblox exploit. I recently (6 July 2024) unarchived this project to improve upon it.
