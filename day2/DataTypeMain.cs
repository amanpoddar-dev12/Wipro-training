class DataTypeExample

{

    static void Main()
    {


                //              short System.Int16
                //              int - 4bytes ,IL will not understand the int System.Int32 -- CLR
                    //               long - 8 bytes , system.Int64
                    //               float -4 bytes ,
                //               double - 8 bytes ,
                //               bool - 1 byte , 
                //               char - 2bytes ,
                //               string - 2bytes per character

                short number1 = 45;
                System.Int16 number2 =34;

                int x =40;
                System.Int32 x1 =45;

             //   Console.WriteLine(x.GetType());

                // You will get int or uint

            // uint is not a CLS-compliant because it may lead to compatibility issues  23+34    , -23+34 
                // uint will take a positive integers only starts with 0
                // public int AddOperation(int a  , int b)
                // {

                // int result = a+b;
                // return result; 
                // }
            // when we use int.Parse(String s) or if you are Convert.ToInt32()
            // strictly it will throw an exception if your string value is 
            // null or not a number
            // string val = "123";
            // int number = int.Parse(val);

            //     string str1 = null;
            // int value1 = int.Parse(str1);

            // string str2 = "abc";
            // int number3 = int.Parse(str2);

     // parse will be used when strict string parsing 
             string val = "123";
            int number = Convert.ToInt32(val);

                string str1 = null;
            int value1 = Convert.ToInt32(str1);

            object str2 = true;
            int number3 = Convert.ToInt32(str2);

            string datainput = "234";
            int result;

            bool boolresult  = int.TryParse(datainput , out result);

            //int.parse  is used when input is sure or guaranteed to be valid
            // Convert.ToInt32 is used when there will be a chances for optional inputs like null
            // int.TryParse(string ,out int) is used for user input

    }

    
}
