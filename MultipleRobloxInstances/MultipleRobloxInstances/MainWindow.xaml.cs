using MultipleRobloxInstances.Resources;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.IO;
using System.Management;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;

namespace MultipleRobloxInstances
{
    public partial class MainWindow : Window
    {
        // --------------- //
        // ** VARIABLES ** //
        // --------------- //
        public readonly string Version = "2.0"; // of app
        public readonly string RobloxPath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Roblox");
        public bool LastTaskIsRoblox = false; // 2nd log is the real one
        public FileInfo Last;
        public Mutex RobloxLock;
        public Mutex OtherRobloxLock;
        public FileStream RobloxCookieLock;
        public readonly string WindowsUser = Environment.UserDomainName + "\\" + Environment.UserName;

        // ----------------------- //
        // ** GENERAL FUNCTIONS ** //
        // ----------------------- //
        public int RobloxInstancesOpen()
        {
            Process[] pname = Process.GetProcessesByName("RobloxPlayerBeta");
            return pname.Length;
        }

        // to simplify
        public FileInfo MostRecentRobloxLogFile()
        {
            DirectoryInfo Directory = new DirectoryInfo(System.IO.Path.Combine(RobloxPath, "logs"));
            FileInfo[] FileInf = Directory.GetFiles();

            // Find the most recently edited file
            FileInfo MostRecent = FileInf.OrderByDescending(file => file.LastWriteTime).FirstOrDefault();

            if (MostRecent != null)
            {
                Console.WriteLine("Most recently edited file:");
                Console.WriteLine($"Name: {MostRecent.Name}");
                Console.WriteLine($"Last Write Time: {MostRecent.LastWriteTime}");
                return MostRecent;
            }
            else
            {
                Console.WriteLine("No files found in the directory.");
                return null;
            }
        }

        public string[] ReadViaShadowCopy(string filePath)
        {
            string tempPath = System.IO.Path.GetTempFileName();

            try
            {
                File.Copy(filePath, tempPath, overwrite: true);
                return File.ReadAllLines(tempPath);
            }
            finally
            {
                if (File.Exists(tempPath))
                    File.Delete(tempPath);
            }
        }

        public bool CheckIfProcessExists(int PID)
        {
            return Process.GetProcesses().Any(
                Proc => Proc.Id == PID
            );
        }

        public Dictionary<string, string> GetRobloxDetails(string[] Lines)
        {
            foreach (string line in Lines)
            {
                if (line.Contains("game_join_loadtime"))
                {
                    // Use a regex to extract universeid and userid
                    var match = Regex.Match(line, @"universeid:(\d+),.*userid:(\d+)");
                    if (match.Success)
                    {
                        string universeId = match.Groups[1].Value;
                        string userId = match.Groups[2].Value;

                 
                        Dictionary<string, string> Data = new()
                        {
                            { "Universe", universeId },
                            { "UserID", userId }
                        };
                        return Data;
                    }
                }       
            }
            return null;
        }

        // UI animations taken from MainDab
        public void Fade(DependencyObject ElementName, double Start, double End, double Time)
        {
            DoubleAnimation Anims = new DoubleAnimation()
            {
                From = Start,
                To = End,
                Duration = TimeSpan.FromSeconds(Time),
                EasingFunction = new QuarticEase { EasingMode = EasingMode.EaseInOut }
            };
            Storyboard.SetTarget(Anims, ElementName);
            Storyboard.SetTargetProperty(Anims, new PropertyPath(OpacityProperty));
            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(Anims);
            storyboard.Begin();
        }

        public void Move(DependencyObject ElementName, Thickness Origin, Thickness Location, double Time)
        {
            ThicknessAnimation Anims = new ThicknessAnimation()
            {
                From = Origin,
                To = Location,
                Duration = TimeSpan.FromSeconds(Time),
                EasingFunction = new QuarticEase { EasingMode = EasingMode.EaseInOut }
            };
            Storyboard.SetTarget(Anims, ElementName);
            Storyboard.SetTargetProperty(Anims, new PropertyPath(MarginProperty));
            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(Anims);
            storyboard.Begin();
        }
        public void Scaling(DependencyObject ElementName, double Before, double After, double Time)
        {
            DoubleAnimation ScalingX = new DoubleAnimation()
            {
                From = Before,
                To = After,
                Duration = TimeSpan.FromSeconds(Time),
                EasingFunction = new QuarticEase { EasingMode = EasingMode.EaseInOut }
            };

            Storyboard.SetTarget(ScalingX, ElementName);
            Storyboard.SetTargetProperty(ScalingX, new PropertyPath("RenderTransform.Children[0].ScaleX"));
            Storyboard StoryboardX = new Storyboard();
            StoryboardX.Children.Add(ScalingX);

            DoubleAnimation ScalingY = new DoubleAnimation()
            {
                From = Before,
                To = After,
                Duration = TimeSpan.FromSeconds(Time),
                EasingFunction = new QuarticEase { EasingMode = EasingMode.EaseInOut }
            };

            Storyboard.SetTarget(ScalingY, ElementName);
            Storyboard.SetTargetProperty(ScalingY, new PropertyPath("RenderTransform.Children[0].ScaleY"));
            Storyboard StoryboardY = new Storyboard();
            StoryboardY.Children.Add(ScalingY);

            StoryboardX.Begin();
            StoryboardY.Begin();
        }

        // ---------------- //
        // ** MAIN LOGIC ** //
        // ---------------- //

        // When Roblox new instance
        void ProcessWatch()
        {
            ManagementEventWatcher StartWatch = new ManagementEventWatcher(new WqlEventQuery("SELECT * FROM Win32_ProcessStartTrace"));
            StartWatch.EventArrived += new EventArrivedEventHandler(ProcessWatchEvent);
            StartWatch.Start();
        }

        // When Roblox detected
        public bool Debounce = false;
        public void ProcessWatchEvent(object sender, EventArrivedEventArgs e)
        {
            // 2nd task is valid Roblox
            Console.WriteLine("Process started: {0}", e.NewEvent.Properties["ProcessName"].Value);

            if ((string)e.NewEvent.Properties["ProcessName"].Value == "RobloxPlayerBeta.exe")
            {
                if (Debounce)
                {
                    Debounce = false;
                    Console.WriteLine("Roblox started");

                    // check for newest next Roblox log file
                    Console.WriteLine(Convert.ToInt32(e.NewEvent.Properties["ProcessID"].Value));

                    Task.Run(() =>
                    {
                        // is this correct?
                        CheckMoitorLog(Convert.ToInt32(e.NewEvent.Properties["ProcessID"].Value));
                    });
                }
                else
                {
                    Debounce = true;
                }
            }
            else
            {
            }
        }
        public async Task CheckMoitorLog(int RobloxProcessID)
        { 
            // for first time: we already ran MostRecentRobloxLogFile(); before roblox start.
            for (int i = 0; i < 30; i++) // 15 seconds allowance
            {
                // new file detect
                FileInfo MostRecent = MostRecentRobloxLogFile();
                if (MostRecent.FullName != Last.FullName)
                {
                    Console.WriteLine("CheckMonitorLog found Roblox file: " + MostRecent.FullName);
                    Last = MostRecentRobloxLogFile();
                    _ = ReadFromLog(MostRecent.FullName, RobloxProcessID);
                    break;
                }
                Thread.Sleep(500);
            }
        }

        public async Task ReadFromLog(string File, int RobloxProcessID)
        {
            string GameName = "Failed to obtain";
            string DisplayName = "Failed to obtain";
            string RobloxUsername = "Failed to obtain";
            string RobloxAvatarUrl = "Failed";
            bool RobloxIsClose = false;
            bool ObtainedRobloxDetails = false;
            int UIIndex = 900000; // all the way at the top

            while (!RobloxIsClose)
            {
                if (CheckIfProcessExists(RobloxProcessID))
                {
                    Console.WriteLine("Reading " + File);

                    string[] Data = ReadViaShadowCopy(File);

                    if (!ObtainedRobloxDetails)
                    {
                        try
                        {
                            Dictionary<string, string> RobloxDetails = GetRobloxDetails(Data);

                            if (RobloxDetails != null)
                            {
                                string UniverseID = RobloxDetails["Universe"];
                                string RobloxID = RobloxDetails["UserID"];

                                HttpClient RobloxAPI = new();

                                // universe -> place name
                                try
                                {
                                    HttpResponseMessage UniverseRes = await RobloxAPI.GetAsync($"https://games.roblox.com/v1/games?universeIds={UniverseID}");
                                    string UniverseResString = await UniverseRes.Content.ReadAsStringAsync();
                                    JObject UniverseJson = JObject.Parse(UniverseResString);
                                    Console.WriteLine(UniverseResString);
                                    GameName = UniverseJson["data"][0]["name"].ToString();
                                }
                                catch (Exception ex){ Console.WriteLine($"Error when using Roblox API for place name: {ex}"); }

                                // user id -> username
                                try
                                {
                                    HttpResponseMessage UsernameRes = await RobloxAPI.GetAsync($"https://users.roblox.com/v1/users/{RobloxID}");
                                    string UsernameResString = await UsernameRes.Content.ReadAsStringAsync();
                                    JObject UsernameJson = JObject.Parse(UsernameResString);
                                    DisplayName = UsernameJson["displayName"].ToString();
                                    RobloxUsername = UsernameJson["name"].ToString();
                                }
                                catch (Exception ex) { Console.WriteLine($"Error when using Roblox API for username: {ex}"); }

                                // user id -> avatar img
                                try
                                {
                                    HttpResponseMessage AvatarRes = await RobloxAPI.GetAsync($"https://thumbnails.roblox.com/v1/users/avatar-headshot?size=150x150&format=png&userIds={RobloxID}");
                                    string AvatarResString = await AvatarRes.Content.ReadAsStringAsync();
                                    JObject AvatarJson = JObject.Parse(AvatarResString);
                                    RobloxAvatarUrl = AvatarJson["data"][0]["imageUrl"].ToString();
                                }
                                catch (Exception ex) { Console.WriteLine($"Error when using Roblox API for avatar: {ex}"); }

                                Console.WriteLine($"Final detail: game name {GameName} display {DisplayName} username {RobloxUsername} avatar {RobloxAvatarUrl}");

                                this.Dispatcher.Invoke(() =>
                                {
                                    Console.WriteLine("*** NOW ADDING TO UI ***");

                                    // remove any previous

                                    // add to UI
                                    RobloxInstance NewInstance = new RobloxInstance();
                                    this.WP1.Children.Add(NewInstance);
                                    UIIndex = WP1.Children.IndexOf(NewInstance);

                                    // button
                                    void KillRoblox()
                                    {
                                        Console.WriteLine("Killing process " + RobloxProcessID);
                                        try
                                        {
                                            Process Rblx = Process.GetProcessById(RobloxProcessID);
                                            Rblx.Kill();
                                        }
                                        catch (Exception ex) { Console.WriteLine(ex); this.WP1.Children.Remove(NewInstance); }
                                    }

                                    NewInstance.KilInstance.Click += (_, _) => KillRoblox();

                                    NewInstance.DisplayName.Content = DisplayName;
                                    NewInstance.FullUsername.Content = RobloxUsername;
                                    NewInstance.GameName.Content = GameName;

                                    try
                                    {
                                        BitmapImage bitmap = new BitmapImage();
                                        bitmap.BeginInit();
                                        bitmap.UriSource = new Uri(@RobloxAvatarUrl, UriKind.Absolute);
                                        bitmap.EndInit();
                                        NewInstance.PFP.Source = bitmap;
                                    }
                                    catch { }

                                    Fade(NewInstance.PFP, 1, 0, 0);
                                    Fade(NewInstance.DisplayName, 1, 0, 0);
                                    Fade(NewInstance.FullUsername, 1, 0, 0);
                                    Fade(NewInstance.GameName, 1, 0, 0);
                                    Fade(NewInstance.KilInstance, 1, 0, 0);

                                    Task.Delay(100);
                                    Fade(NewInstance.PFP, 0, 1, 0.5);
                                    Move(NewInstance.PFP, new Thickness(NewInstance.PFP.Margin.Left, NewInstance.PFP.Margin.Top - 20, NewInstance.PFP.Margin.Right, NewInstance.PFP.Margin.Bottom), NewInstance.PFP.Margin, 0.75);
                                     Task.Delay(100);
                                    Fade(NewInstance.DisplayName, 0, 1, 0.5);
                                    Move(NewInstance.DisplayName, new Thickness(NewInstance.DisplayName.Margin.Left, NewInstance.DisplayName.Margin.Top - 20, NewInstance.DisplayName.Margin.Right, NewInstance.DisplayName.Margin.Bottom), NewInstance.DisplayName.Margin, 0.75);
                                     Task.Delay(100);
                                    Fade(NewInstance.FullUsername, 0, 1, 0.5);
                                    Move(NewInstance.FullUsername, new Thickness(NewInstance.FullUsername.Margin.Left, NewInstance.FullUsername.Margin.Top - 20, NewInstance.FullUsername.Margin.Right, NewInstance.FullUsername.Margin.Bottom), NewInstance.FullUsername.Margin, 0.75);
                                     Task.Delay(100);
                                    Fade(NewInstance.GameName, 0, 1, 0.5);
                                    Move(NewInstance.GameName, new Thickness(NewInstance.GameName.Margin.Left, NewInstance.GameName.Margin.Top - 20, NewInstance.GameName.Margin.Right, NewInstance.GameName.Margin.Bottom), NewInstance.GameName.Margin, 0.75);
                                     Task.Delay(100);
                                    Fade(NewInstance.KilInstance, 0, 1, 0.5);
                                    Move(NewInstance.KilInstance, new Thickness(NewInstance.KilInstance.Margin.Left, NewInstance.KilInstance.Margin.Top - 20, NewInstance.KilInstance.Margin.Right, NewInstance.KilInstance.Margin.Bottom), NewInstance.KilInstance.Margin, 0.75);

                                    Console.WriteLine("*** ADDED TO UI! ***");


                                });

                                ObtainedRobloxDetails = true;
                            }
                            else
                            {
                                Console.WriteLine("Unable to find string in log");
                            }
                        }
                        catch(Exception ex)
                        {
                            Console.WriteLine("Error attempting to get Roblox API data: " + ex);
                        }
                    }
                }
                else
                {
                    RobloxIsClose = true;
                }

                Thread.Sleep(1000);
            }

            Console.WriteLine("Roblox process closed");

            this.Dispatcher.Invoke(() =>
            {
                try{ this.WP1.Children.RemoveAt(UIIndex); }
                catch { }
            });
        }

        public MainWindow()
        {
            InitializeComponent();

            Last = MostRecentRobloxLogFile();

            // make sure Roblox is installed
            if (!Directory.Exists(RobloxPath))
            {

                MessageBox.Show("Roblox does not exist / Roblox cannot be found", "Roblox needs to be installed in C:\\Users\\[YourWindowsUsername]\\AppData\\Local\\Roblox. Multiple Roblox Instances could not find this folder. Make you are using the Roblox downloaded from Roblox (not from Microsoft Store).\n\nMultiple Roblox Instances will now close.");
                Process.Start("https://www.roblox.com/download");
                Environment.Exit(0);
            }

            // check and see if roblox is open
            if (RobloxInstancesOpen() > 0){               
                MessageBoxResult result = MessageBox.Show("Multiple Roblox Instances needs to close Roblox.", "Roblox needs to be closed before Multiple Roblox Instances starts.\n\nShould Multiple Roblox Instances close all instances of Roblox [Yes]? If [No]. Multiple Roblox Instances will close, allowing you to close Roblox manually.\n\nWARNING: If you have any unsaved data in Roblox, click [No], save your data, and close Roblox. Make sure to open Multiple Roblox Instances before starting Roblox.", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    try { foreach (Process proc in Process.GetProcessesByName("RobloxPlayerBeta")) { proc.Kill(); } }
                    catch { }
                }
                else
                {
                    Environment.Exit(0);
                }
            }

            WebClient WebStuff = new WebClient();
            string VersionGet = WebStuff.DownloadString("https://raw.githubusercontent.com/Avaluate/MultipleRobloxInstances/refs/heads/main/UpdateAssets/Version");
            WebStuff.Dispose();

            // github adds an extra line for some reason
            string OnlineVersion = VersionGet.Split(new[] { '\r', '\n' }).FirstOrDefault();
            if (OnlineVersion != Version)
            {
                UpdateAvailable.Text = "Update Available: Version " + OnlineVersion;
                UpdateAvailable.Visibility = Visibility.Visible;
            }

            
            // start watching for rblx
            ProcessWatch();

            // remove previous locks first & make again
            // ROBLOX_singletonEvent is also locked 
            try { Mutex.OpenExisting("ROBLOX_singletonMutex").Close(); Mutex.OpenExisting("ROBLOX_singletonEvent").Close(); Console.WriteLine("Roblox mutex found, closing"); }
            catch{ }

            // double lock seems to work well
            RobloxLock = new Mutex(true, "ROBLOX_singletonMutex");
            OtherRobloxLock = new Mutex(true, "ROBLOX_singletonEvent");

            /*
             Voidstrap deals with error 773 using an ingenius method by making RobloxCookies.dat write-only, however we can lock the file to achieve the same result
             (so thank you Voidstrap for this idea)
             https://github.com/voidstrap/Voidstrap/blob/main/Bloxstrap/Utilities.cs
            */
            try
            {
                RobloxCookieLock = new FileStream(System.IO.Path.Combine(RobloxPath, "LocalStorage", "RobloxCookies.dat"), FileMode.Open, FileAccess.Read, FileShare.None);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to apply Error 773 fix: {ex}. You may not be able to teleport between places.");
            }
        }

        // ------------- //
        // ** TOP BAR ** //
        // ------------- //
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void UpdateAvailable_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Process.Start(new ProcessStartInfo { FileName = "https://github.com/Avaluate/MultipleRobloxInstances/releases/", UseShellExecute = true });
        }

        private void Minimise_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            // close locks
            try { RobloxLock.Close(); OtherRobloxLock.Close(); }
            catch { }
            Environment.Exit(0);
        }

        // ---------------- //
        // ** STATUS BAR ** //
        // ---------------- //
        private void WebsiteIcon_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Process.Start(new ProcessStartInfo { FileName = "https://github.com/Avaluate/MultipleRobloxInstances/wiki", UseShellExecute = true });
        }

        private void TelegramIcon_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Process.Start(new ProcessStartInfo { FileName = "https://t.me/maindabnow", UseShellExecute = true });
        }

        private void DiscordIcon_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Process.Start(new ProcessStartInfo { FileName = "https://discord.org/maindab", UseShellExecute = true });
        }

        private void GitHubIcon_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Process.Start(new ProcessStartInfo { FileName = "https://github.com/Avaluate/MultipleRobloxInstances", UseShellExecute = true });
        }

        // Handling startup anim
        private async void Border_Loaded(object sender, RoutedEventArgs e)
        {
            // make all components transparent at first
            Fade(MW, 1, 0, 0);
            Fade(Title, 1, 0, 0);
            Fade(VersionBorder, 1, 0, 0);
            Fade(VersionText, 1, 0, 0);
            Fade(Minimise, 1, 0, 0);
            Fade(Close, 1, 0, 0);
            Fade(StatusText, 1, 0, 0);
            Fade(WebsiteIcon, 1, 0, 0);
            Fade(TelegramIcon, 1, 0, 0);
            Fade(DiscordIcon, 1, 0, 0);
            Fade(GitHubIcon, 1, 0, 0);

            await Task.Delay(100);
            Fade(MW, 0, 1, 1);
            await Task.Delay(100);
            Fade(Title, 0, 1, 0.5);
            Move(Title, new Thickness(Title.Margin.Left, Title.Margin.Top - 30, Title.Margin.Right, Title.Margin.Bottom), Title.Margin, 0.75);
            await Task.Delay(100);
            Fade(VersionBorder, 0, 1, 0.5);
            Move(VersionBorder, new Thickness(VersionBorder.Margin.Left, VersionBorder.Margin.Top - 30, VersionBorder.Margin.Right, VersionBorder.Margin.Bottom), VersionBorder.Margin, 0.75);
            Fade(VersionText, 0, 1, 0.5);
            Move(VersionText, new Thickness(VersionText.Margin.Left, VersionText.Margin.Top - 30, VersionText.Margin.Right, VersionText.Margin.Bottom), VersionText.Margin, 0.75);
            await Task.Delay(100);
            Fade(Minimise, 0, 1, 0.5);
            Move(Minimise, new Thickness(Minimise.Margin.Left, Minimise.Margin.Top - 30, Minimise.Margin.Right, Minimise.Margin.Bottom), Minimise.Margin, 0.75);
            await Task.Delay(100);
            Fade(Close, 0, 1, 0.5);
            Move(Close, new Thickness(Close.Margin.Left, Close.Margin.Top - 30, Close.Margin.Right, Close.Margin.Bottom), Close.Margin, 0.75);
            await Task.Delay(100);
            Fade(StatusText, 0, 1, 0.5);
            Move(StatusText, new Thickness(StatusText.Margin.Left, StatusText.Margin.Top + 17, StatusText.Margin.Right, StatusText.Margin.Bottom), StatusText.Margin, 0.75);
            await Task.Delay(100);
            Fade(WebsiteIcon, 0, 1, 0.5);
            Move(WebsiteIcon, new Thickness(WebsiteIcon.Margin.Left, WebsiteIcon.Margin.Top + 17, WebsiteIcon.Margin.Right, WebsiteIcon.Margin.Bottom), WebsiteIcon.Margin, 0.75);
            await Task.Delay(100);
            Fade(TelegramIcon, 0, 1, 0.5);
            Move(TelegramIcon, new Thickness(TelegramIcon.Margin.Left, TelegramIcon.Margin.Top + 17, TelegramIcon.Margin.Right, TelegramIcon.Margin.Bottom), TelegramIcon.Margin, 0.75);
            await Task.Delay(100);
            Fade(DiscordIcon, 0, 1, 0.5);
            Move(DiscordIcon, new Thickness(DiscordIcon.Margin.Left, DiscordIcon.Margin.Top + 17, DiscordIcon.Margin.Right, DiscordIcon.Margin.Bottom), DiscordIcon.Margin, 0.75);
            await Task.Delay(100);
            Fade(GitHubIcon, 0, 1, 0.5);
            Move(GitHubIcon, new Thickness(GitHubIcon.Margin.Left, GitHubIcon.Margin.Top + 17, GitHubIcon.Margin.Right, GitHubIcon.Margin.Bottom), GitHubIcon.Margin, 0.75);
        }
    }
}