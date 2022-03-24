using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void Add(Car car)
        {
            if (car.Description.Length >= 2 && car.DailyPrice > 0)
            {
                //car.Id sıfır yaptık çünkü veritabanında car.Id otomatik artırılarak ayarlandı. Eğer kullanıcı id girmeye çalışırsa onunla eklemeye çalışmasın,
                //bilgisayarın kendi yaptığı id ile ekleme yapılsın.
                car.Id = 0;
                _carDal.Add(car);
            }
            else
            {
                Console.WriteLine("Araba eklenemedi!");
            }
        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
        }

        public List<Car> GetAll()
        {
            Console.WriteLine("------Tüm arabalar------");
            return _carDal.GetAll();
        }

        public List<Car> GetById(Car car)
        {
            return _carDal.GetAll(p => p.Id == car.Id);
        }

        public List<Car> GetCarsByBrandId(int id)
        {
            return _carDal.GetAll(p => p.BrandId == id);
        }

        public List<Car> GetCarsByColorId(int id)
        {
            return _carDal.GetAll(p => p.ColorId == id);
        }

        public void Update(Car car)
        {
            _carDal.Update(car);
        }
    }
}
