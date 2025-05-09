namespace ErrorHandling
{
    internal class IndexOutOfRange
    {
        private int[] _numbers;
        public IndexOutOfRange() {
            
            try
            {
                _numbers = GenerateArray();
                GetArrayElements();
                GetElementByIndex();

            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                
            }
            finally
            {
                Utils.PressKeyToContinue();       
            }
            GetIndex();
        }

        /// <summary>
        /// Generates an integer array by prompting the user to input its length.
        /// </summary>
        /// <returns>An integer array of the specified length.</returns>
        public int[] GenerateArray()
        {
            Console.Write("Enter array length: ");
            int length = GetArrayLength();
            return new int[length];
        }

        /// <summary>
        /// Gets the length of the array from the user.
        /// Ensures the input is a positive integer.
        /// </summary>
        /// <returns>The length of the array.</returns>
        /// <exception cref="InvalidUserInputException">Thrown if the input length is zero or negative.</exception>

        public int GetArrayLength()
        {
            string userInput = Console.ReadLine();
            int length;
            while (!int.TryParse(userInput, out length))
            {
                Console.WriteLine("Invalid number! Enter an integer");
                Console.Write("Enter array length: ");
                userInput = Console.ReadLine();
            }
            
            if (length <= 0)
            {
                throw new InvalidUserInputException("Array length should be a positive integer."); //Task 3
            }
            return length;
        }

        /// <summary>
        /// Gets elements of the array.
        /// </summary>
        public void GetArrayElements()
        {
            for(int i = 0; i< _numbers.Length; i++)
            {
                Console.Write($"Enter number {i}: ");
                string userInput = Console.ReadLine();
                int number;
                while (!int.TryParse(userInput, out number))
                {
                    Console.WriteLine("Invalid number! Enter an integer");
                    Console.Write($"Enter number {i}: ");
                }
                _numbers[i] = number;
            }
        }


        /// <summary>
        /// Retrieves an array element at a specified index provided by the user.
        /// Handles index out-of-range errors.
        /// </summary>
        /// <exception cref="Exception">Thrown if the index is out of range.</exception>
        public void GetElementByIndex()
        {
            Console.Write("Enter index to search element: ");
            string userInput = Console.ReadLine();
            int index;
            while (!int.TryParse(userInput, out index))
            {
                Console.WriteLine("Invalid number! Enter an integer");
                Console.Write("Enter array length: ");
                userInput = Console.ReadLine();
            }
            try
            {
                Console.WriteLine($"The element is {_numbers[index]}");
            }
            catch (IndexOutOfRangeException e)
            {
                throw new Exception($"Array index out of range. Array length is {_numbers.Length}"); //Task 2
            }

        }


        /// <summary>
        /// Finds the index of a specified number in the array provided by the user.
        /// Throws an unhandled exception if element is not an integer.
        /// </summary>
        /// <exception cref="Exception">Purposefully thrown to simulate global unhandled exception handling.</exception>
        public void GetIndex()
        {
            Console.Write("Enter number to find index: ");
            string userInput = Console.ReadLine();

            // Task 4
            try
            {
                int element = int.Parse(userInput);
                for (int i = 0; i < _numbers.Length; i++)
                {
                    if (_numbers[i] == element)
                    {
                        Console.WriteLine($"Index of the element {i}");
                        return;
                    }
                }
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                throw new Exception(); //Throws the exception purposefully to caught by global unhandled exception
            }
        }
    }
}
