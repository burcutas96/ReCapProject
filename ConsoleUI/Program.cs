
using Business.Concrete;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

Car car1 = new Car();
car1.Id = 8;
car1.BrandId = 7;
car1.ColorId = 3;
car1.ModelYear = "2020";
car1.DailyPrice = 87000;
car1.Description = "Porche Cayenne";

Car car2 = new Car();
car2.Id = 5;
car2.BrandId = 8;
car2.ColorId = 2;
car2.ModelYear = "2022";
car2.DailyPrice = 90000;
car2.Description = "Togg";

CarManager carManager = new CarManager(new InMemoryCarDal());
foreach (var car in carManager.GetAll())
{
    Console.WriteLine(car.Description);
}

carManager.Add(car1);

carManager.Update(car2);

carManager.Delete(new Car { Id = 3 });

carManager.GetById(new Car { Id = 1 });