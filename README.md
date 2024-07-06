## Multiple Roblox Instances
This program allows you to run 2 or more different Roblox accounts at the same time. This is not against the Roblox ToS and applications such as Bloxstrap have similar functionality.

[![](https://i.imgur.com/el2EOj2.png)](https://i.imgur.com/el2EOj2.png)

#### I just want to download it
There is more information including the download link [here](https://github.com/Avaluate/MultipleRobloxInstances/releases/tag/V1 "here"). Usage instructions are included on the release page.

#### I need help
My Discord username is `avaluate` if you need help. 

MainDab (now called [Echolyth on Discord](https://dsc.gg/echolyth)) no longer discusses any form of Roblox utility, but you can still join to contact me.

#### How this works
You can see how this works in [program.cs](https://github.com/MainDabRblx/MultipleRobloxInstances/blob/main/Program.cs "program.cs"). 

It boils down to this :
```csharp
new Mutex(true, "ROBLOX_singletonMutex");
```

#### Can I use this in my program?
You are free to go downloading the source and using the code. Use it as you wish. You do not need to include credits for me since this is a really simple program.

#### Brief history
I had originally made this for [MainDab](https://github.com/Avaluate/MainDab "MainDab"), a keyless Roblox exploit. I recently (6 July 2024) unarchived this project to improve upon it.
