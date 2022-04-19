using Avalonia.Controls;
using Avalonia.Themes.Fluent;
using Avalonia.Media;
using Avalonia.Layout;
using System;
using Avalonia;
using Avalonia.Platform;
using MessageBox;
using MessageBox.Avalonia;
using MessageBox.Avalonia.DTO;
using MessageBox.Avalonia.Enums;
using MessageBox.Avalonia.Models;


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
            reloadSessions();
        }

        private void reloadSessions()
        {
            Sessions.Children.Clear();
            foreach (Session session in App.settings.Sessions.Session)
            {
                addSessionToList(session);
            }
        }

        public override void Show()
        {
            try
            {
                theme = App.settings.Theme;
                this.PropertyChanged += Window_PropertyChanged;
                throw new IndexOutOfRangeException();
                base.Show();
            }
            catch (IndexOutOfRangeException e)
            {
                App.exitGotCatched = true;
                Console.Clear();
                Console.Write("Exception: " + e.GetType() +
                    "   got from: " + e.Source + "\n" +
                    "   with message: " + e.Message + "\n" +
                    "   while method: " + e.TargetSite + "\n" +
                    "   with error: " + e.StackTrace +"\n"+ getInnerExceptions(e));
                    
                MessageBoxManager.GetMessageBoxCustomWindow(
                new MessageBoxCustomParamsWithImage
                {
                    ButtonDefinitions = new[] {
                        new ButtonDefinition {Name = "Ok", IsDefault = true}
                    },
                    ContentTitle = "Error",
                    ContentHeader = "Error in List counting",
                    ContentMessage = "got "+e.GetType()+", view console for more info",
                    WindowIcon = new WindowIcon("./Ressources/icon.ico"),
                    WindowStartupLocation = WindowStartupLocation.CenterOwner,
                    Icon = new Avalonia.Media.Imaging.Bitmap("./Ressources/Error.ico")
                }).Show();
            }
            catch (InvalidOperationException e)
            {
                App.exitGotCatched = true;
                Console.Clear();
                Console.Write("Exception: " + e.GetType() +
                    "   got from: " + e.Source + "\n" +
                    "   with message: " + e.Message + "\n" +
                    "   while method: " + e.TargetSite + "\n" +
                    "   with error: " + e.StackTrace + "\n" + getInnerExceptions(e));

                MessageBoxManager.GetMessageBoxCustomWindow(
                new MessageBoxCustomParamsWithImage
                {
                    ButtonDefinitions = new[] {
                        new ButtonDefinition {Name = "Ok", IsDefault = true}
                    },
                    ContentTitle = "Error",
                    ContentHeader = "Error in List counting",
                    ContentMessage = "got " + e.GetType() + ", view console for more info",
                    WindowIcon = new WindowIcon("./Ressources/icon.ico"),
                    WindowStartupLocation = WindowStartupLocation.CenterOwner,
                    Icon = new Avalonia.Media.Imaging.Bitmap("./Ressources/Error.ico")
                }).Show();
            }
            catch (System.IO.IOException e)
            {
                App.exitGotCatched = true;
                Console.Clear();
                Console.Write("Exception: " + e.GetType() +
                    "   got from: " + e.Source + "\n" +
                    "   with message: " + e.Message + "\n" +
                    "   while method: " + e.TargetSite + "\n" +
                    "   with error: " + e.StackTrace + "\n" + getInnerExceptions(e));

                MessageBoxManager.GetMessageBoxCustomWindow(
                new MessageBoxCustomParamsWithImage
                {
                    ButtonDefinitions = new[] {
                        new ButtonDefinition {Name = "Ok", IsDefault = true}
                    },
                    ContentTitle = "Error",
                    ContentHeader = "Error in List counting",
                    ContentMessage = "got " + e.GetType() + ", view console for more info",
                    WindowIcon = new WindowIcon("./Ressources/icon.ico"),
                    WindowStartupLocation = WindowStartupLocation.CenterOwner,
                    Icon = new Avalonia.Media.Imaging.Bitmap("./Ressources/Error.ico")
                }).Show();
            }
            catch (InvalidCastException e)
            {
                App.exitGotCatched = true;
                Console.Clear();
                Console.Write("Exception: " + e.GetType() +
                    "   got from: " + e.Source + "\n" +
                    "   with message: " + e.Message + "\n" +
                    "   while method: " + e.TargetSite + "\n" +
                    "   with error: " + e.StackTrace + "\n" + getInnerExceptions(e));

                MessageBoxManager.GetMessageBoxCustomWindow(
                new MessageBoxCustomParamsWithImage
                {
                    ButtonDefinitions = new[] {
                        new ButtonDefinition {Name = "Ok", IsDefault = true}
                    },
                    ContentTitle = "Error",
                    ContentHeader = "Error in List counting",
                    ContentMessage = "got " + e.GetType() + ", view console for more info",
                    WindowIcon = new WindowIcon("./Ressources/icon.ico"),
                    WindowStartupLocation = WindowStartupLocation.CenterOwner,
                    Icon = new Avalonia.Media.Imaging.Bitmap("./Ressources/Error.ico")
                }).Show();
            }
        }

        private string getInnerExceptions(Exception e)
        {
            string getTabs(int c) { string back = ""; foreach (short s in new short[c]) { back += "   "; } return back; }
            string text = "";
            int count = 1;
            while (e.InnerException != null)
            {
                e = e.InnerException;
                text += getTabs(count) + "with inner Exception: " + e.GetType + "\n"; 
                count++;
                string tabs = getTabs(count);
                text += tabs + "got from: " + e.Source + "\n" +
                        tabs + "with message: " + e.Message + "\n" +
                        tabs + "while method: " + e.TargetSite + "\n" +
                        tabs + "with error: " + e.StackTrace + "\n";
            }
            return text;
        }

        private void Window_PropertyChanged(object? sender, Avalonia.AvaloniaPropertyChangedEventArgs e)
        {
            Scroll.MaxHeight = this.Height - TopBar.Bounds.Height - 10;
            Scroll.MinHeight = this.Height - TopBar.Bounds.Height - 10;
        }

        public class SessionPanel : StackPanel
        {
            public Session session { get; set; }
        }

        
        private void LoadButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            Session session = ((sender as Button).Parent.Parent.Parent as SessionPanel).session;
        }

        
        private void DeleteButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            Session session = ((sender as Button).Parent.Parent.Parent as SessionPanel).session;
            App.settings.Sessions.Session.Remove(session);
            reloadSessions();
        }

        

        public void addSessionToList(Session session)
        {
            var loadButton = new Button() { Content = "Load",  Margin = new Avalonia.Thickness(0,0,2,0), CornerRadius = new Avalonia.CornerRadius(5)};
            loadButton.Click += LoadButton_Click;

            var deleteButton = new Button() { Content = "Delete" , CornerRadius = new Avalonia.CornerRadius(5)};
            deleteButton.Click += DeleteButton_Click;
            Sessions.Children.Add(new SessionPanel()
            {
                session = session,
                Margin = new Avalonia.Thickness(2, 5, 2, 8),
                Children =
                {
                    new DockPanel(){Children = {new Label()
                    {
                        Content = session.Host,
                        VerticalAlignment = VerticalAlignment.Top,
                        HorizontalAlignment = HorizontalAlignment.Left,
                        VerticalContentAlignment = VerticalAlignment.Center,
                        HorizontalContentAlignment = HorizontalAlignment.Center,
                        Margin = new Avalonia.Thickness(0,0,1,0)
                    },
                    new Label()
                    {
                        Content = session.Port.ToString(),
                        VerticalAlignment = VerticalAlignment.Top,
                        HorizontalAlignment = HorizontalAlignment.Right,
                        VerticalContentAlignment = VerticalAlignment.Center,
                        HorizontalContentAlignment = HorizontalAlignment.Center,
                        Margin = new Avalonia.Thickness(1,0,0,0)
                    } } },
                    new StackPanel()
                    {
                        Orientation = Orientation.Horizontal,
                        HorizontalAlignment = HorizontalAlignment.Center,
                        Children =
                        {
                            new LimeHover(){CornerRadius = new Avalonia.CornerRadius(5), Margin = new Avalonia.Thickness(0,0,5,0), Child = loadButton },
                            new RedHover(){CornerRadius = new Avalonia.CornerRadius(5), Margin = new Avalonia.Thickness(5,0,0,0), Child = deleteButton }
                        }
                    },
                    new Panel()
                    {
                        Background = Brushes.Gray,
                        Margin = new Avalonia.Thickness(5,7,5,0),
                        HorizontalAlignment = HorizontalAlignment.Stretch,
                        Height = 2
                    }
                }
            }) ;
        }


        public string theme {get {
                return App.settings.Theme; 
            }
            set
            {
                if (value == "light")
                {
                    App.colorMode = FluentThemeMode.Light; acryl.Material.TintColor = Colors.White; Console.BackgroundColor = ConsoleColor.White; Console.ForegroundColor = ConsoleColor.Black; Console.Clear();
                    Methods.printLog();
                    App.settings.Theme = value;
                }
                else if (value == "dark")
                {
                    App.colorMode = FluentThemeMode.Dark; acryl.Material.TintColor = Colors.Black; Console.BackgroundColor = ConsoleColor.Black; Console.ForegroundColor = ConsoleColor.White; Console.Clear();
                    Methods.printLog();
                    App.settings.Theme = value;
                }
                else { throw new System.Xml.XmlException("bad theme descriptor"); }
            } }
    }
}