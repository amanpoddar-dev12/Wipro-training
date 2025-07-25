// // See https://aka.ms/new-console-template for more information
// using System.Collections;
// class NonGenericExample
// {

//     static void Main()
//     {
//         // int num = 45;
//         // object boxedvalue = num; //Boxing

//         // Console.WriteLine(boxedvalue.GetType());

//         ArrayList arrayList = new ArrayList();  // It will store the values in object
//         int value = 20;

//         arrayList.Add(value); // Boxing
//         Console.WriteLine(arrayList.GetType());

//         int unboxingvalue = (int)arrayList[0]; // Unboxing

//         Console.WriteLine("The value after unboxing " + unboxingvalue);

//         //Generic one
//         List<int> intList = new List<int>();
//         intList.Add(value); // No Boxing is required
//          double value2 = intList[0]; // No unBoxing is required
//           Console.WriteLine("The value after unboxing " + value2);
//     }


// }
