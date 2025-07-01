<p align="center">
  <a href="https://maindab.org/discord">
    <img src="https://raw.githubusercontent.com/Avaluate/MultipleRobloxInstances/refs/heads/main/Cover/Cover.png" alt="Logo" >
  </a>
</p>
<p align="center">
    <a title="Download MainDab" href="https://github.com/Avaluate/MultipleRobloxInstances/releases"><img alt="Download MainDab" src="https://raw.githubusercontent.com/Avaluate/MultipleRobloxInstances/refs/heads/main/Cover/Download.png" width=200 height=53></a>
    <a title="Instructions" href="https://github.com/Avaluate/MultipleRobloxInstances/wiki"><img alt="Insructions" src="https://raw.githubusercontent.com/Avaluate/MultipleRobloxInstances/refs/heads/main/Cover/Instructions.png" width=200 height=53></a>
    <a title="Discord" href="https://maindab.org/discord"><img alt="Discord" src="https://raw.githubusercontent.com/Avaluate/MultipleRobloxInstances/refs/heads/main/Cover/Discord.png" width=200 height=53></a>
    <a title="Telegram" href="https://t.me/maindabnow"><img alt="Telegram" src="https://raw.githubusercontent.com/Avaluate/MultipleRobloxInstances/refs/heads/main/Cover/Telegram.png" width=200 height=53></a>
  </p>

**Multiple Roblox Instances is a tool used to run multiple windows of Roblox on different accounts at the same time.** 

The V2 release of Multiple Roblox Instances:
* (attempts to) **fix Error 773 / error with teleports**
* more consistently locks the Roblox process
* has a basic process manager for seeing which account
## Is this a virus?
No.
## Does Roblox allow this?
This is not explicitly against the Roblox Terms of Service. Applications such as Bloxstrap had similar functionality. 

Bloxstrap removed the multiple Roblox instances feature due to fears people were [using it to farm](https://github.com/pizzaboxer/bloxstrap/wiki/Plans-to-remove-multi%E2%80%90instance-launching-from-Bloxstrap) and well as their implementation of multiple Roblox instances being a "hit or miss".
## How this work?
```csharp
new Mutex(true, "ROBLOX_singletonMutex");
```
## Brief history
I originally made this for [MainDab](https://github.com/Avaluate/MainDab), a keyless Roblox exploit. I unarchived this project to improve upon it.
