using Avalonia.Controls;
using Avalonia.Themes.Fluent;
using Avalonia.Media;
using System;

namespace MinecraftRcon
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public override void Show()
        {
            if (App.settings.Theme == "light") { App.colorMode = FluentThemeMode.Light; acryl.Material.TintColor = Colors.White; Console.BackgroundColor = ConsoleColor.White; Console.ForegroundColor = ConsoleColor.Black; Console.Clear();
                Console.WriteLine("| Console for Rcon connections and logging |");
            } 
            else if(App.settings.Theme == "dark") { App.colorMode = FluentThemeMode.Dark; acryl.Material.TintColor = Colors.Black; Console.BackgroundColor = ConsoleColor.Black; Console.ForegroundColor = ConsoleColor.White; Console.Clear();
                Console.WriteLine("| Console for Rcon connections and logging |");
            } 
            else { throw new System.Xml.XmlException("bad theme descriptor"); }
            base.Show();
            
            
        }
    }
}