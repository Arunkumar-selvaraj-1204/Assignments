using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LanguageIntegratedQuery.ApplicationEnums;

namespace LanguageIntegratedQuery
{
    internal class QueryBuilder<T>
    {
        private List<Product> _products;
        private List<Supplier> _suppliers;

        List <(object, QueryOperation)> queryList = new List<(object, QueryOperation)> ();
        public IEnumerable<object> queryResult { get; set; }
        public QueryBuilder(List<Product> products, List<Supplier> suppliers)
        {
            _products = products;
            _suppliers = suppliers;
            queryResult = products;
        }

        public QueryBuilder<T> Filter(Func<T, bool> func)
        {
            queryList.Add(new (func, QueryOperation.Filter));
            return this;
        }

        public QueryBuilder<T> SortBy(Func<T, decimal> func)
        {
            queryList.Add(new(func, QueryOperation.SortBy));
            return this;
        }

        public QueryBuilder<T> Join(Func<T, Supplier, bool> func)
        {
            queryList.Add(new(func, QueryOperation.Join));
            return this;
        }

        public IEnumerable<object> Execute()
        {
            foreach (var query in queryList)
            {
                var source = (IEnumerable<Product>)queryResult;
                if (query.Item2 == QueryOperation.Filter)
                {
                    queryResult = source.Where((Func<Product, bool>)query.Item1).ToList();
                }
                else if(query.Item2 == QueryOperation.SortBy)
                {
                    
                    queryResult = source.OrderBy((Func<Product, decimal>)query.Item1).ToList();
                }
                else
                {
                    queryResult = from product in source
                                  from supplier in _suppliers
                                  where ((Func<Product, Supplier, bool>) query.Item1)(product, supplier)
                                  select new Tuple<int, string, string, decimal> ( product.ProductId, product.ProductName, supplier.SupplierName, product.ProductPrice );
                }
            }
            queryList.Clear();
            var result = queryResult;
            queryResult = _products;
            return result;
        }
    }
    static class ApplicationEnums
    {
        public enum QueryOperation
        {
            Filter,
            SortBy,
            Join,
        }
    }
}
