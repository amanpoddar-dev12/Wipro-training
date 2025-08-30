using System.IO;
namespace SolidPrinciples.Services {
    public class ReportSaver {
        public void SaveToFile(string content, string path) {
            File.WriteAllText(path, content);
        }
    }
}