using Avalonia;
using Avalonia.Themes.Fluent;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;

namespace MinecraftRcon
{
    public partial class App : Application
    {
        public override void Initialize()
        {
            instance = this;
            var stream = new System.IO.StreamReader("./settings.xml");
            settingsField = new System.Xml.Serialization.XmlSerializer(typeof(Settings)).Deserialize(stream) as Settings;
            stream.Close();
            stream.Dispose();
            Methods.WriteLine("| console for commands and logs |");
            AvaloniaXamlLoader.Load(this);
        }

        public static bool exitGotCatched = false;

        public static App instance;
        private static Settings settingsField;
        public static Settings settings
        {
            get
            {

                System.IO.StreamWriter writer = new("./settings.xml");
                new System.Xml.Serialization.XmlSerializer(typeof(Settings)).Serialize(writer, settingsField);
                writer.Flush();
                writer.Close();
                writer.Dispose(); 
                return settingsField;
            }
            set
            {
                System.IO.StreamWriter writer = new("./settings.xml");
                new System.Xml.Serialization.XmlSerializer(typeof(Settings)).Serialize(writer, value);
                writer.Flush();
                writer.Close();
                writer.Dispose();
                settingsField = value;
            }
        }

        public static FluentThemeMode colorMode { get
            {
                return (instance.Styles[0] as FluentTheme).Mode;
            }
            set
            {
                (instance.Styles[0] as FluentTheme).Mode = value;
            } }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = new MainWindow();
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}