using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Car CarToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(CarToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public void GetById(Car car)
        {
            Car CarToBrought = _cars.SingleOrDefault(c => c.Id == car.Id);

            if (CarToBrought == null)
            {
                Console.WriteLine("Seçtiğiniz id'ye göre araba bulunamadı.");
            }
            else
            {
                Console.WriteLine("{0} isimli araba getirildi.", CarToBrought.Description);
            }
        }

        public void Update(Car car)
        {
            Car CarToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);

            if (CarToUpdate == null)
            {
                Console.WriteLine("Güncellemek istediğiniz araba bulunamadı!");
            }
            else
            {
                CarToUpdate.BrandId = car.BrandId;
                CarToUpdate.ColorId = car.ColorId;
                CarToUpdate.ModelYear = car.ModelYear;
                CarToUpdate.DailyPrice = car.DailyPrice;
                CarToUpdate.Description = car.Description;
            }

        }
    }
}
