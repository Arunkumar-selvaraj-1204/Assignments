namespace ShapeHierarchy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ShapeGenerator generator = new ShapeGenerator();
            bool isExit = false;
            Console.WriteLine("1. Create rectangle \n2. Create circle \n3. Exit");
            int userChoice = InputManager.GetChoice();
            while (!isExit)
            {
                switch (userChoice)
                {
                    case 1:
                        generator.CreateRectangle();
                        break;
                    case 2:
                        generator.CreateCircle();
                        break;
                    case 3:
                        isExit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid Input!!");
                        break;
                }
            }
        }
    }
}
