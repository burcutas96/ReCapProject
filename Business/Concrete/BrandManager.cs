using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.CrossCuttingConcern.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public IResult Add(Brand brand)
        {
            ValidationTool.Validate(new BrandValidator(), brand);

            brand.Id = 0;
            _brandDal.Add(brand);
            return new SuccesResult(Messages.BrandAdded);

        }

        public IResult Delete(Brand brand)
        {
            _brandDal.Delete(brand);
            return new SuccesResult(Messages.BrandDeleted);
        }

        public IDataResult<Brand> Get(Brand brand)
        {
            return new SuccesDataResult<Brand>(_brandDal.Get(b => b.Id == brand.Id));
        }

        public IDataResult<List<Brand>> GetAll()
        {
            if (DateTime.Now.Hour == 18)
            {
                return new ErrorDataResult<List<Brand>>(Messages.MaintenanceTime);
            }
            else
            {
                return new SuccesDataResult<List<Brand>>(_brandDal.GetAll());
            }

        }

        public IDataResult<Brand> GetById(int id)
        {
            return new SuccesDataResult<Brand>(_brandDal.Get(b => b.Id == id));
        }

        public IResult Update(Brand brand)
        {
            _brandDal.Update(brand);
            return new SuccesResult(Messages.BrandUpdated);
        }
    }
}
