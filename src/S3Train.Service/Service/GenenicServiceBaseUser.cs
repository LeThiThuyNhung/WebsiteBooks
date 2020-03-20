//using System;
//using System.Collections.Generic;
//using System.Data.Entity;
//using System.Linq;
//using System.Linq.Expressions;
//using System.Text;
//using System.Threading.Tasks;
//using S3Train.Domain;


//namespace S3Train.Service
//{
//    public abstract class GenenicServiceBaseUser<T> : IGenenicServiceBaseUser<T>
//    {
//        protected readonly ApplicationDbContext DbContext;

//        protected GenenicServiceBaseUser(ApplicationDbContext dbContext)
//        {
//            DbContext = dbContext;
//        }

//        /// <summary>
//        /// Select all data
//        /// </summary>
//        /// <returns></returns>
      
//        /// <summary>
//        /// Get entity by Id, return null if not found
//        /// </summary>
//        /// <param name="id">The identifier.</param>
//        public T GetById(string id)
//        {
//            return DbContext.Users.SingleOrDefault(x => x.Id == id);
//        }

//    }
//}
//}
