using Business.Abstract;
using Business.Constants.Messages;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }


        [ValidationAspect(typeof(BrandValidator))]
        public IResult Add(Brand brand)
        {

            brand.Id = 0;
            _brandDal.Add(brand);
            return new SuccesResult(BrandMessages.BrandAdded);

        }

        public IResult Delete(Brand brand)
        {
            _brandDal.Delete(brand);
            return new SuccesResult(BrandMessages.BrandDeleted);
        }

        public IDataResult<Brand> Get(Brand brand)
        {
            return new SuccesDataResult<Brand>(_brandDal.Get(b => b.Id == brand.Id));
        }

        public IDataResult<List<Brand>> GetAll()
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<Brand>>(AppMessages.MaintenanceTime);
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
            return new SuccesResult(BrandMessages.BrandUpdated);
        }
    }
}
