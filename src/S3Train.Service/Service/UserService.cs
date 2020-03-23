using S3Train.Contract;
using S3Train.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S3Train.Service
{
    public class UserService : GenenicServiceBaseUser<ApplicationUser>, IUserService
    {
        public UserService(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public IList<ApplicationUser> GetUserItems(string Id)
        {
            var user = DbContext.Users.Where(x => x.Id == Id).ToList();
            return user;
        }
    }
}
