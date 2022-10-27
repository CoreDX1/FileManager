using FileExploreProject.Interfaces;
using System.IO;

namespace FileExploreProject.Services
{
    public class IMyFiles : InterfaceFiles
    {
        public string Listar()
        {
            string[] files = Directory.GetDirectories(@"C:\Users\chism\OneDrive\Desktop\MyFiles");
            string result = string.Empty;
            for(int i = 0; i < files.Length; i++)
            {
                result += files[i];
            }
            return result;
        }
    }
}
