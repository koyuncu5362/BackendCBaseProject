using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.Aspects.Serilog.Logger;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class _Manager : I_Service
    {
        I_Dal _productDal;
        public _Manager(I_Dal productDal)
        {
            _productDal = productDal;
        }

        [SecuredOperation("product.add,admin")]
        [LogAspect]
        [ValidationAspect(typeof(_Validator))]
        //[CacheRemoveAspect("IProductService.Get")]
        public IResult Add(_ product)
        {
            CheckIfProductCountOfCategoryCorrect(product.CategoryId);
            _productDal.Add(product);
            return new SuccessResult(Messages.Example);
        }

        [ValidationAspect(typeof(_Validator))]
       // [CacheRemoveAspect("IProductService.Get")]
        public IResult Update(_ product)
        {
            _productDal.Add(product);
            return new SuccessResult(Messages.Example);
        }

        [CacheAspect]
        public IDataResult<List<_>> GetAll()
        {

            return new SuccessDataResult<List<_>>(_productDal.GetAll(),Messages.Example) ;
        }

        public IDataResult<List<_>> GetAllByCategory(int categoryId)
        {
            return new SuccessDataResult<List<_>>(_productDal.GetAll(p => p.CategoryId == categoryId)) ;
        }
        //[PerformanceAspect(5)]//If cant run in 5 second give error
        [CacheAspect]
        public IDataResult<_> GetById(int id)
        {
            return new SuccessDataResult<_>(_productDal.Get(p => p.ProductId == id)) ;
        }

        public IDataResult<List<_>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<_>>(_productDal.GetAll(p => p.UnitPrice > min && p.UnitPrice < max));
        }

        public IDataResult<List<_Dto>> GetProductDetails()
        {
            return new SuccessDataResult<List<_Dto>>(_productDal.Get_Details()) ;
        }

        private IResult CheckIfProductCountOfCategoryCorrect(int categoryId)
        {
            var result = _productDal.GetAll(p => p.CategoryId == categoryId).Count;
            if (result >= 10)
            {
                return new ErrorResult(Messages.Example);
            }
            return new SuccessResult();
        }
        private IResult CheckIfProductNameExists(string productName)
        {
            var result = _productDal.GetAll(p => p.ProductName == productName).Any();
            if (result)
            {
                return new ErrorResult(Messages.Example);
            }
            return new SuccessResult();
        }
        [TransactionScopeAspect]
        public IResult AddTransactionalTest(_ product)
        {
            throw new NotImplementedException();
        }
    }
}
