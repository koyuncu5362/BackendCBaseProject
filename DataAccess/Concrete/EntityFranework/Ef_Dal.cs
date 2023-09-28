
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFranework
{
    public class Ef_Dal : EfEntityRepositoryBase<_, _Context>, I_Dal
    {
        public List<_Dto> Get_Details()
        {
            using (_Context context = new _Context())
            {
                var result = from _ in context._
                             select 
                             new _Dto 
                             {ProductId= _.ProductId,ProductName= _.ProductName,
                                UnitsInStock = _.UnitsInStock };
                return result.ToList();
            }
            
        }
    }
}
