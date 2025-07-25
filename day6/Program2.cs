// using System.IO;


// class Program2
// {


//     static void Main()
//     {

//         string path = "file1.txt";
//         string message = "File data related to c#";

//         //To write using FileStream
//         // Garbage collector 
//         // Manually we have to close and open (we need not to write manually open / close /flush with using keyword it automatically does)
//         FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write);
        
//             byte[] data = System.Text.Encoding.UTF8.GetBytes(message);
                
//             fs.Write(data, 0, data.Length);

//         fs.Close();

//         FileStream fs1 = new FileStream(path, FileMode.Open, FileAccess.Read);
        
//             // To read the data it is important to use buffer 
//             byte[] buffer = new byte[fs1.Length];
//             fs1.Read(buffer, 0, buffer.Length);

//             string result = System.Text.Encoding.UTF8.GetString(buffer);
//             Console.WriteLine(result);
//             fs1.Close();
//     }
// }