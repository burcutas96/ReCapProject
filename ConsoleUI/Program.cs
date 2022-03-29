using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

//ColorManager();
//BrandManager();
//CarManager();

CarManager carManager = new CarManager(new EfCarDal());
foreach (var car in carManager.GetCarDetails().Data)
{
    Console.WriteLine(car.CarName + " / " + car.BrandName + " / " + car.ColorName + " / " + car.DailyPrice);
}


static void ColorManager()
{
    ColorManager colorManager = new ColorManager(new EfColorDal());
    foreach (var color in colorManager.GetAll().Data)
    {
        Console.WriteLine(color.Name);
    }

    Color color1 = new Color();
    color1.Id = 7;
    color1.Name = "Yellow";

    Color color2 = new Color();
    color2.Id = 4;
    color2.Name = "Red";

    colorManager.Add(color1);
    colorManager.Delete(color1);
    colorManager.Update(color2);

    Console.WriteLine(colorManager.GetById(3).Data.Name);

    foreach (var color in colorManager.GetAll().Data)
    {
        Console.WriteLine(color.Name);
    }

}



static void BrandManager()
{
    BrandManager brandManager = new BrandManager(new EfBrandDal());
    foreach (var brand in brandManager.GetAll().Data)
    {
        Console.WriteLine(brand.Name);
    }

    Brand brand1 = new Brand();
    brand1.Id = 22;
    brand1.Name = "Bentley";

    Brand brand2 = new Brand();
    brand2.Id = 15;
    brand2.Name = "Honda";

    brandManager.Add(brand1);
    brandManager.Delete(brand1);
    brandManager.Update(brand2);

    Console.WriteLine(brandManager.GetById(8).Data.Name);

    foreach (var brand in brandManager.GetAll().Data)
    {
        Console.WriteLine(brand.Name);
    }
}



static void CarManager()
{
    Car car1 = new Car();
    car1.Id = 35;
    car1.BrandId = 20;
    car1.ColorId = 3;
    car1.ModelYear = "2020";
    car1.DailyPrice = 870;
    car1.Description = "Porche Cayenne";

    Car car2 = new Car();
    car2.Id = 10;
    car2.BrandId = 2;
    car2.ColorId = 2;
    car2.ModelYear = "2022";
    car2.DailyPrice = 900;
    car2.Description = "Togg";

    CarManager carManager = new CarManager(new EfCarDal());
    foreach (var car in carManager.GetAll().Data)
    {
        Console.WriteLine(car.Description);
    }

    Console.WriteLine(carManager.GetById(9).Data.Description);

    carManager.Add(car1);
    carManager.Delete(car1);
    carManager.Update(car2);

    foreach (var car in carManager.GetAll().Data)
    {
        Console.WriteLine(car.Description);
    }

}
