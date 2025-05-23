using System.Threading.Tasks;
using CollectionAndGenerics.Task1;
using CollectionAndGenerics.Task2;
namespace CollectionAndGenerics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            WorkingWithList workingWithList = new WorkingWithList();
            workingWithList.ExecuteListOperations();

            Stacks stacks = new Stacks();
            stacks.ExecuteStackOperations();
        }
    }
}
