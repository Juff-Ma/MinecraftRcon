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
            settings = new System.Xml.Serialization.XmlSerializer(typeof(Settings)).Deserialize(new System.IO.StreamReader("./settings.xml")) as Settings;
            AvaloniaXamlLoader.Load(this);
        }

        public static App instance;
        public static Settings settings;

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