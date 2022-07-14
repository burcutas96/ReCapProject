using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Linq.Expressions;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{ Id = 1, BrandId = 1, ColorId = 1, ModelYear = "2017", DailyPrice = 80000, Description = "Mercedes AMG" },
                new Car{ Id = 2, BrandId = 3, ColorId = 3, ModelYear = "2010", DailyPrice = 65000, Description = "Peugeot 3008"},
                new Car{ Id = 3, BrandId = 5, ColorId = 2, ModelYear = "2012", DailyPrice = 73000, Description = "Bmw M4"},
                new Car{ Id = 4, BrandId = 2, ColorId = 3, ModelYear = "2007", DailyPrice = 60000, Description = "Fiat 500X"},
                new Car{ Id = 5, BrandId = 6, ColorId = 1, ModelYear = "2018", DailyPrice = 78000, Description = "Kia Sorento"},
                new Car{ Id = 6, BrandId = 4, ColorId = 2, ModelYear = "2008", DailyPrice = 53000, Description = "Toyota Auris"}
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public void GetById(Car car)
        {
            Car carToBrought = _cars.SingleOrDefault(c => c.Id == car.Id);

            if (carToBrought == null)
            {
                Console.WriteLine("Seçtiğiniz id'ye göre araba bulunamadı.");
            }
            else
            {
                Console.WriteLine("{0} isimli araba getirildi.", carToBrought.Description);
            }
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);

            if (carToUpdate == null)
            {
                Console.WriteLine("Güncellemek istediğiniz araba bulunamadı!");
            }
            else
            {
                carToUpdate.BrandId = car.BrandId;
                carToUpdate.ColorId = car.ColorId;
                carToUpdate.ModelYear = car.ModelYear;
                carToUpdate.DailyPrice = car.DailyPrice;
                carToUpdate.Description = car.Description;
            }

        }
    }
}
