using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Text;

namespace MTGA_Launcher_Attempt_0._2.LauncherData
{
    //NeedLinkOfSomeKind? https://cerberusgaming.org/
    class VersionManager
    {
        public Dictionary<string, string> VersionLinkPairs;

        private MainWindow WindowClass;
        public VersionManager(MainWindow WindowClass)
        {
            this.WindowClass = WindowClass;

            WindowClass.PlayButton.IsEnabled = true;
            WindowClass.VersionSelector.IsEnabled = true;

            Init();

        }

        private void Init()
        {
            WebClient c = new WebClient();
            c.DownloadStringCompleted += C_DownloadStringCompleted;
            c.DownloadStringAsync(new Uri("https://cerberusgaming.org/")); 
        }
        private void C_DownlaodStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            string temp = e.Result;
            string[] VersionLinks = temp.Split(Environment.NewLine);

            ObservableCollection<string> VersionstoDisplay = new ObservableCollection<string>();
            for(int i = 0; i < VersionLinks.Length; i++)
            {
                string[] Version_Link = VersionLinks[i].Split(' ');
                VersionLinkPairs.Add(Version_Link[0], Version_Link[1]);
                VersionstoDisplay.Add(Version_Link[0]);
            }
            
            WindowClass.VersionSelector.ItemsSource = VersionstoDisplay;
            WindowClass.VesersionSelector.Items.refresh();

            WindowClass.PlayButton.IsEnabled = true;
            WindowClass.VersionSelector.IsEnabled = true;
        }
    }
}
