//using S3Train.Domain;
//using S3Train.Service;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace S3Train.Contract
{
    public interface IUserService
    {
        IList<ApplicationUser> GetUserItems(string Id);
    }
}
