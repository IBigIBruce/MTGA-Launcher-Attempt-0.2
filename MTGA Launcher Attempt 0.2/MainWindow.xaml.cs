using System;
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            VersionToDownload = VersionSelector.SelectedItem.ToString();
        }
    }
    }
}
