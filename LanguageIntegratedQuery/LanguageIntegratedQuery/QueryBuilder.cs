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
        List<Func<T, bool>> FilterQueries = new List<Func<T, bool>>();
        List<Func<T, object>> SortQueries = new List<Func<T, object>>();
        Func<T, Supplier, bool> joinQuery;
        public IEnumerable<Supplier> Suppliers { get; set; }
        IEnumerable<T> dataList { get; set; }
        public IEnumerable<T> queryResult { get; set; }
        public QueryBuilder(IEnumerable<T> products, List<Supplier> suppliers)
        {
            Suppliers = suppliers;
            dataList = products;
        }

        public QueryBuilder<T> Filter(Func<T, bool> func)
        {
            FilterQueries.Add(func);
            return this;
        }

        public QueryBuilder<T> SortBy<TKey>(Func<T, TKey> keySelector)
        {
            SortQueries.Add(x=>keySelector(x));
            return this;
        }

        public QueryBuilder<T> Join(Func<T, Supplier, bool> joinFunc)
        {
            joinQuery = joinFunc;
            return this;
        }

        public IEnumerable<object> Execute()
        {
            queryResult = dataList;
            foreach (var filterQuery in FilterQueries)
            {
                queryResult = queryResult.Where(filterQuery);
            }
            foreach(var sortQuery in SortQueries)
            {
                queryResult =  queryResult.OrderBy(sortQuery);
            }
            if(joinQuery is not null)
            {
                var joinResult = (from source in queryResult
                              from supplier in Suppliers
                              where (joinQuery(source, supplier))
                              select new Tuple<T, string>(source, supplier.SupplierName)).ToList();
                joinQuery = null;
                return joinResult;
            }
            FilterQueries.Clear();
            SortQueries.Clear();
            return queryResult.Cast<object>();
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
