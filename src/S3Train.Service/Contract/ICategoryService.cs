using S3Train.Domain;
using System.Collections.Generic;


namespace S3Train.Contract
{
    public interface ICategoryService: IGenenicServiceBase<Category>
    {
        IList<Category> GetCategoryItems();
    }
}
