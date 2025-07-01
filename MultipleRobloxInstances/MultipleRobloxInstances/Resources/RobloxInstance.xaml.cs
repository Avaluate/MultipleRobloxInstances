using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace MultipleRobloxInstances.Resources
{
    public partial class RobloxInstance : UserControl
    {
        public FileSystemWatcher Watcher = new FileSystemWatcher();
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

        public RobloxInstance()
        {
            InitializeComponent();
        }
    }
}
