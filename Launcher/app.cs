
public class AppInfo
{
    public string Name { get; set; }
    public string Path { get; set; }
}

public class AppInfo
{
    public string Name { get; set; }
    public string Path { get; set; }
}

public MainWindow()
{
    InitializeComponent();

    List<AppInfo> apps = new List<AppInfo>();

    string programFiles = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);

    foreach (string dir in Directory.GetDirectories(programFiles))
    {
        string appName = new DirectoryInfo(dir).Name;
        string appExePath = Path.Combine(dir, appName + ".exe");

        if (File.Exists(appExePath))
        {
            apps.Add(new AppInfo { Name = appName, Path = appExePath });
        }
    }

    appList.ItemsSource = apps;
}

private void launchButton_Click(object sender, RoutedEventArgs e)
{
    AppInfo selectedApp = (AppInfo)appList.SelectedItem;

    if (selectedApp != null)
    {
        Process.Start(selectedApp.Path);
    }
}
