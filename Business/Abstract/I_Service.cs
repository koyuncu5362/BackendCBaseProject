using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface I_Service
    {
        IDataResult<List<_>> GetAll();
        IDataResult<List<_>> GetAllByCategory(int categoryId);
        IDataResult<List<_>> GetByUnitPrice(decimal min,decimal max);
        IDataResult<List<_Dto>> GetProductDetails();
        IResult Add(_ product);
        IResult Update(_ product);
        IDataResult<_> GetById(int id);
        IResult AddTransactionalTest(_ product);
    }
}
