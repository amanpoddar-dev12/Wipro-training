//-------------------------------------------------------
        int vCount = 0;
        int cCount = 0;
        int splCharCount = 0;
        int numCount = 0;
        int spaceCount = 0;

        string givenData = "Hello! Team, submit the Project 23-07-2005.";
        char[] vowels = ['a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U'];
        foreach (char c in givenData)
        {
            if (vowels.Contains(c))
            {
                vCount++;
            }
            else
            {
                if (!char.IsLetterOrDigit(c) && !char.IsWhiteSpace(c))
                {
                    splCharCount++;
                }
                else if (char.IsLetter(c))
                {
                    cCount++;
                }
                else if (char.IsDigit(c))
                {
                    numCount++;
                }
                else if (char.IsWhiteSpace(c))
                {
                    spaceCount++;
                }
            }
        }
        Console.WriteLine("Vowels : " + vCount);
        Console.WriteLine("Consonants : " + cCount);
        Console.WriteLine("special : " + splCharCount);
        Console.WriteLine("Numeric : " + numCount);
        Console.WriteLine("Spaces : " + spaceCount);
        //--------------------------------------------------------
    