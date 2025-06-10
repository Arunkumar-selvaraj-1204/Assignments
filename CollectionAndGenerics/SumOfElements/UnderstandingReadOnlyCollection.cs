using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionAndGenerics.Task6
{
    /// <summary>
    /// Class to understand the ReadOnlyCollections
    /// </summary>
    public class UnderstandingReadOnlyCollection
    {
        /// <summary>
        /// Invoke all the methods
        /// </summary>
        public void ExecuteReadOnlyCollectionOperations()
        {
            Console.WriteLine("ReadOnly Collection understanding");
            Console.WriteLine("______________________");
            PrintDictionary(GenerateDictionary());
            ModifyDictionary();
            Console.WriteLine("***********************");
        }

        /// <summary>
        /// Create dictionary with two values
        /// </summary>
        /// <returns>Returns the dictionary as IReadOnlyDictionary</returns>
        public IReadOnlyDictionary<string, int> GenerateDictionary()
        {
            Dictionary<string, int> dictionary = new Dictionary<string, int>();
            dictionary.Add("Arunkumar", 21);
            dictionary.Add("Pirai", 20);

            return dictionary;
        }

        /// <summary>
        /// Display all the key and value  in the dictionary
        /// </summary>
        /// <param name="readonlyDictionary">ReadOnlyDictionary to display</param>
        public void PrintDictionary(IReadOnlyDictionary<string, int> readonlyDictionary)
        {
            foreach (var key in readonlyDictionary)
            {
                Console.WriteLine($"Key :{key} Value : {key.Value} ");
            }
        }

        /// <summary>
        /// Modify the value of key in the dictionary
        /// </summary>
        public void ModifyDictionary()
        {
            IReadOnlyDictionary<string, int> dictionary = GenerateDictionary();
            //dictionary["Arunkumar"] = 10; //  Throw an error because IReadOnlyDictionary is immutable 
        }
    }
}
