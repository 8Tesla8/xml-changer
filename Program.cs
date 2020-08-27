using System;
using System.IO;

namespace SettingsChanger
{
    class Program
    {
        static void Main(string[] args)
        {
            string currentFolder = Directory.GetCurrentDirectory();                         //give path with \bin\debug\netcoreapp
            string mainFolder = Path.GetFullPath(Path.Combine(currentFolder, @"..\..\..\"));  //go up for 3 folders


            var configPath = mainFolder + "App.config";

            var changer = new XMLChanger();
            changer.Change(configPath);
        }
    }
}
