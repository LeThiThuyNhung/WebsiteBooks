using S3Train.Domain;
using System.Collections.Generic;

namespace S3Train.Contract
{
    public interface ISearchProductsForNameService : IGenenicServiceBase<Product>
    {
        IList<Product> GetProductsSearchForNameItems(string Name);
    }
}
