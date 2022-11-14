using System;
using System.IO;
using System.IO.Compression;
using System.Windows;
using System.Windows.Controls;
using MTGA_Launcher_Attempt_0._2.LauncherData;

namespace MTGA_Launcher_Attempt_0._2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public string VersionToDownload;

        public Button PlayButton;
        public ComboBox VersionSelectorProfileSelector;
        public WebBrowser UpdateBoard;

        private VersionManager _versionManager;
        public MainWindow()
        {
            InitializeComponent();
            _VersionManager = new VersionManager(this);
        }

        private void Window_ContentRendered(object sender, EventArgs e) {   }

        private void Button_Initialized(object sender, EventArgs e) { PlayButton = (Button)sender; }
        private void ComboBox_Initialized(object sender, EventArgs e) { VersionSelectorProfileSelector = (ComboBox)sender; }
        private void WebBrowser_Initialized(object sender, EventArgs e) 
        { 
            UpdateBoard = (WebBrowser)sender; 
        }
        private GamePaths paths;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                paths = new GamePaths(VersionToDownload);
                FileDownloader downloader = new FileDownloader();

                if (_versionManager.VersionLinkPairs.TryGetValue(VersionToDownload, out string temp))
                {
                    downloader.DownloadFileCompleted += Downloader_DownloadFileCompleted;
                    downloader.DownloadFileAsync(temp, $@"{ paths.GamesVersionFile}\Build({VersionToDownload}) .zip");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void Downloader_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            try
            {
                ZipFile.ExtractToDirectory()
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            VersionToDownload = VersionSelector.SelectedItem.ToString();
        }
    public GamePaths(string Version)
        {
            GamesDirectory = Path.Combine(Environment.CurrentDirectory, "Versions");
            GameVersionFile = Path.Combine(GamesDirectory, $"ver{Version}");
            ExecutableFile = paths.Combine(GameVersionFile, $"Build({Version})", "Test.exe");

            if (!Directory.Exists(GameDirectory)) Directory.CreateDirectory(GameDirectory);
            if (!Directory.Exists(GameVersionFile)) Directory.CreateDirectory(GameVersionFile);
        }
    }
 }
