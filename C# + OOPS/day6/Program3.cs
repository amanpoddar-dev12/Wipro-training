// using System.IO;
// using System;
// class FileOperations
// {


//     static void Main()
//     {

//         string logFile = "logs.txt";
//         string backupFile = "logs_backup.txt";
//         string archiveFolder = "archieve";
//         string archivedFile = Path.Combine(archiveFolder, "logs_archived.txt");
//         // creating or overwriting the file
//         File.WriteAllText(logFile, "Log initiated :" + DateTime.Now);
//         Console.WriteLine("Log File created");

//         File.AppendAllText(logFile, " User has logged in ");
//         File.AppendAllText(logFile, " User has uploaded a file ");
//         Console.WriteLine("The data is appended");

//         string[] lines = File.ReadAllLines(logFile);
//         foreach (var line in lines)
//         {
//             Console.WriteLine(line);
//         }

//         File.Copy(logFile, backupFile, true);
//         Console.WriteLine("BackUp of Log file is created: ");

//         if (!Directory.Exists(archiveFolder))
//             Directory.CreateDirectory(archiveFolder);
//         if (File.Exists(archivedFile)) 
//             File.Delete(archivedFile);

//         File.Move(logFile, archivedFile);
//         Console.WriteLine("The log file is moved to archive folder");

//         if (File.Exists(backupFile))
//         {
//             File.Delete(backupFile);
//             Console.WriteLine("Back Up File is deleted");
//         }
        

//     }
// }