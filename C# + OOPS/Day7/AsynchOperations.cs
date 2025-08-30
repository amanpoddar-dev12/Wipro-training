//using System;
//using System.Collections.Generic; // IAsyncEnumerable  --  await foreach()
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks; //  second class meant for returning multiple taks

//namespace ConsoleApp2
//{
//    //synch  -- when one task is fully completed or generated then the second task will execute 
//    //asynch --- when you order  -- you will be getting parallely notification , messages
//    //internal class AsynchOperations
//    //{


//    //    static async IAsyncEnumerable<int> Generate()
//    //    {

//    //        for (int i = 0; i < 5; i++)
//    //        {

//    //            await Task.Delay(1000); // Simulation
//    //            Console.WriteLine("Generated the value :" + i);
//    //            yield return i;

//    //        }



//    //    }

//    //    static async Task Main()
//    //    {

//    //        await foreach (var num in Generate())
//    //            Console.WriteLine("Received by the customer :" + num);

//    //    }
//    //}


//    internal class SynchOperations
//    {


//        static async Task<List<int>> GenerateAll()   
//        {

//            var result = new List<int>();

//            for (int i = 0; i < 5; i++)
//            {

//                await Task.Delay(1000); // Simulation
//                Console.WriteLine("Generated the value :" + i);
//                result.Add(i);

//            }
//            return result;



//        }

//        static async Task Main()
//        {
//            var allnumbers = await GenerateAll(); // waits until all 5 task are generated

//            foreach (var num in allnumbers)

//            {
//                Console.WriteLine("Received by the customer :" + num); // It will prints after all tasks are generated
//            }

//            //Syntax of Lambda Expression

//            var numbers = new[] { 3, 4, 5, 6 };
//           var even =  numbers.Where(x => x % 2 == 0);

//            Console.WriteLine("Even no's are " + even);


//            //New version of switch Case
//            string GetDayName(int day) => day switch
//            {

//                1 => "Monday",
//                2 => "Tuesday",
//                3 => "Tuesday",
//                _ => "Unknown"

//            };

//            Console.WriteLine(GetDayName(2));
//        }
//    }
//}


