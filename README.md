#### I just want to download it
See [this](https://github.com/Avaluate/MultipleRobloxInstances/releases/tag/V1 "here") or look at Releases. This works as of July 7 2024.

## Multiple Roblox Instances
This program allows you to run 2 or more different Roblox accounts at the same time. This is not against the Roblox ToS and applications such as Bloxstrap had similar functionality, however Bloxstrap removed it due to fears people were [using it to farm](https://github.com/pizzaboxer/bloxstrap/wiki/Plans-to-remove-multi%E2%80%90instance-launching-from-Bloxstrap) and that their implementation was a "hit or miss".

[![](https://i.imgur.com/el2EOj2.png)](https://i.imgur.com/el2EOj2.png)

#### Current problems
Teleports will not work with Multiple Roblox Instances. This issue has been around before and after Roblox's additional anti-tamper (combatting Roblox exploits) measures, so please do not make an issue about this.

#### I need help
My Discord username is `avaluate` if you need help. 

MainDab (now called [Echolyth on Discord](https://dsc.gg/echolyth)) no longer discusses any form of Roblox utility, but you can still join to contact me.

#### How this works
Note: although the program already states this, closing the program will close all but one of the Roblox windows.

You can see how this works in [program.cs](https://github.com/MainDabRblx/MultipleRobloxInstances/blob/main/Program.cs "program.cs"). 

It boils down to this :
```csharp
new Mutex(true, "ROBLOX_singletonMutex");
```

What this does is essentially locking the Roblox thread. Logically speaking because of this, Roblox isn't able to make a new mutex (or rather, because an existing one already exists). 

#### Can I use this in my program?
You are free to go downloading the source and using the code. Use it as you wish. You do not need to include credits for me since this is a really simple program.

#### Brief history
I had originally made this for [MainDab](https://github.com/Avaluate/MainDab "MainDab"), a keyless Roblox exploit. I recently (6 July 2024) unarchived this project to improve upon it.
