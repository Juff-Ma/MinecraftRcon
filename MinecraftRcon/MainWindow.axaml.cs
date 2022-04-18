using Avalonia.Controls;
using System.Threading.Tasks;
using Avalonia.Themes.Fluent;
using Avalonia.Media;
using System;

namespace MinecraftRcon
{
    public partial class MainWindow : Window
    {
        private string ThemeButtonText { get
            {
                return App.settings.Theme == "light" ? "☾" : "☼";
            } }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ThemeButtonClick(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            theme = theme == "light" ? "dark" : "light";
            (sender as Button).Content = ThemeButtonText;
            Scroll.MaxHeight = this.Height - TopBar.Bounds.Height;
        }

        private void Sessions_Loaded(object? sender, Avalonia.VisualTreeAttachmentEventArgs e)
        {
            foreach(Session session in App.settings.Sessions.Session)
            {
                addSessionToList(session.Host, session.Port);
            }
        }

        public override void Show()
        {
            theme = App.settings.Theme;
            this.PropertyChanged += Window_PropertyChanged;
            base.Show();
        }

        private void Window_PropertyChanged(object? sender, Avalonia.AvaloniaPropertyChangedEventArgs e)
        {
            Scroll.MaxHeight = this.Height - TopBar.Bounds.Height;
        }

        public void addSessionToList(string host, int port)
        {

        }

        public string theme {get {
                return App.settings.Theme; 
            }
            set
            {
                if (value == "light")
                {
                    App.colorMode = FluentThemeMode.Light; acryl.Material.TintColor = Colors.White; Console.BackgroundColor = ConsoleColor.White; Console.ForegroundColor = ConsoleColor.Black; Console.Clear();
                    Console.WriteLine("| Console for Rcon connections and logging |");
                    App.settings.Theme = value;
                }
                else if (value == "dark")
                {
                    App.colorMode = FluentThemeMode.Dark; acryl.Material.TintColor = Colors.Black; Console.BackgroundColor = ConsoleColor.Black; Console.ForegroundColor = ConsoleColor.White; Console.Clear();
                    Console.WriteLine("| Console for Rcon connections and logging |");
                    App.settings.Theme = value;
                }
                else { throw new System.Xml.XmlException("bad theme descriptor"); }
            } }
    }
}