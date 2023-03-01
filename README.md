## Multiple Roblox Instances
This program will allow you to have mutliple instances of Roblox running at the same time. In other words, you can have 2 different Roblox accounts playing at the same time on the same computer!

[![](https://i.imgur.com/el2EOj2.png)](https://i.imgur.com/el2EOj2.png)


#### I just want to download it
There is more information including the download link [here.](https://github.com/MainDabRblx/MultipleRobloxInstances/releases/tag/v1.0 "here.")

#### How this works
You can see how this works in [program.cs](https://github.com/MainDabRblx/MultipleRobloxInstances/blob/main/Program.cs "program.cs"). 

It simply boils down to this :
```csharp
new Mutex(true, "ROBLOX_singletonMutex");
```
It is pretty self explanatory.

#### Can I use this in my program?
You are free to go downloading the source and using the code. Use it as you wish. You do not need to include credits for me since this is so basic.
