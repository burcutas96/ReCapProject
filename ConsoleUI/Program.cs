using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

Car car1 = new Car();
//car.Id'yi veritabanı ayarladığı için ben ayrıca id yazmadım. 
car1.BrandId = 20;
car1.ColorId = 3;
car1.ModelYear = "2020";
car1.DailyPrice = 870;
car1.Description = "Porche Cayenne";

Car car2 = new Car();
car2.Id = 11;
car2.BrandId = 2;
car2.ColorId = 2;
car2.ModelYear = "2022";
car2.DailyPrice = 900;
car2.Description = "Togg";

CarManager carManager = new CarManager(new EfCarDal());
foreach (var car in carManager.GetAll())
{
    Console.WriteLine(car.Description);
}

carManager.Add(car1);
carManager.Update(car2);
carManager.Delete(new Car { Id = 19 });

foreach (var car in carManager.GetCarsByBrandId(13))
{
    Console.WriteLine(car.Description);
}

foreach (var car in carManager.GetCarsByColorId(2))
{
    Console.WriteLine(car.Description);
}
