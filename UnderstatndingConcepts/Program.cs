namespace UnderstatndingConcepts
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //int[] arr = new int[] { 1, 2, 3 };
            //DefaultArray(arr);
            //Console.WriteLine(arr[0]);
            string a = "hello";
            string b = new string ("hello");
            Console.WriteLine(ReferenceEquals(a,b));
        }
        static void DefaultArray(int[] a)
        {
            a = new int[] { 10, 20, 30 };
        }
    }
}
