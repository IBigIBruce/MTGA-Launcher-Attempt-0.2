using.system.IO;
using System;
using System.IO;

namespace MTGA_Launcher_Attempt_0._2.LauncherData
{
    class GamePaths
    {
        public string ExecutatbleFile;
        public string GamesDirectory;
        public string GameVersionFile;
        public GamePaths(string Version)
        {
            GameDirectory = Path.Combine(Environment.CurrentDirectory, "Versions");
            GameVersionFile = Path.Combine(GamesDirectory, $"ver{Version}");
            ExecutatbleFile = Path.Combine(GamesVersionFile, $"Build({Version})", "Test.exe";
        }
    }
}
