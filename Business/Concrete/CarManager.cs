using Business.Abstract;
using Business.Aspects.Autofac;
using Business.Constants.Messages;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }


        [SecuredOperation("car.add,admin")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Add(Car car)
        {
            //car.Id sıfır yaptık çünkü veritabanında car.Id otomatik artırılarak
            //ayarlandı. Eğer kullanıcı id girmeye çalışırsa onunla eklemeye çalışmasın,
            //bilgisayarın kendi yaptığı id ile ekleme yapılsın.
            car.Id = 0;
            _carDal.Add(car);
            return new SuccesResult(CarMessages.CarAdded);

        }


        [CacheRemoveAspect("ICarService.Get")]
        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccesResult(CarMessages.CarDeleted);
        }


        [CacheAspect]
        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour == 4)
            {
                return new ErrorDataResult<List<Car>>(AppMessages.MaintenanceTime);
            }
            else
            {
                Console.WriteLine("------Tüm arabalar------");
                return new SuccesDataResult<List<Car>>(_carDal.GetAll(), CarMessages.CarsListed);
            }
        }

        public IDataResult<Car> Get(Car car)
        {
            return new SuccesDataResult<Car>(_carDal.Get(c => c.Id == car.Id));
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return new SuccesDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == id));
        }

        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            return new SuccesDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == id));
        }


        [CacheRemoveAspect("ICarService.Get")]
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccesResult(CarMessages.CarUpdated);
        }


        [CacheAspect]
        public IDataResult<Car> GetById(int id)
        {
            return new SuccesDataResult<Car>(_carDal.Get(c => c.Id == id));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccesDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }
    }
}
