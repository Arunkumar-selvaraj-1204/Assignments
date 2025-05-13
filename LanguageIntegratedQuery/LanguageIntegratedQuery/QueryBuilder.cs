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
        public IEnumerable<object> QueryResult { get; set; }
        public QueryBuilder(List<Product> products, List<Supplier> suppliers)
        {
            _products = products;
            _suppliers = suppliers;
            QueryResult = (IEnumerable<object>)products;
        }

        public QueryBuilder<T> Filter(Func<T, bool> predic)
        {
            queryList.Add(new (predic, QueryOperation.Filter));
            return this;
        }

        public QueryBuilder<T> SortBy(Func<T, decimal> func)
        {
            queryList.Add(new(func, QueryOperation.SortBy));
            return this;
        }

        public QueryBuilder<T> Join(Func<T, T, bool> func)
        {
            queryList.Add(new(func, QueryOperation.Join));
            return this;
        }

        public IEnumerable<T> Execute()
        {
            foreach (var query in queryList)
            {
                if(query.Item2 == QueryOperation.Filter)
                {
                    QueryResult = QueryResult.Where((Func<object, bool>)query.Item1).ToList();
                }
                else if(query.Item2 == QueryOperation.SortBy)
                {
                    QueryResult = QueryResult.OrderBy((Func<object, decimal>)query.Item1).ToList();
                }
                else
                {
                    QueryResult = from product in _products
                                  from supplier in _suppliers
                                  where ((Func<object, object, bool>) query.Item1)(product, supplier) select new {product.ProductId, product.ProductName, supplier.SupplierName, product.ProductPrice};
                }
            }
            queryList.Clear();
            var result = QueryResult;
            QueryResult = _products;
            return (IEnumerable<T>)result;
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
