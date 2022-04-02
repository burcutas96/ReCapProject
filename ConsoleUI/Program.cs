using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;


RentalManager rentalManager = new RentalManager(new EfRentalDal());
//rentalManager.Delete(new Rental { Id = 10 });
//rentalManager.Delete(new Rental { Id = 11 });
//rentalManager.Delete(new Rental { Id = 14 });
//rentalManager.Delete(new Rental { Id = 21 });

//GetCarDetail();
//ColorManager();
//BrandManager();
//CarManager();


//var sonuc = rentalManager.Add(new Rental
//{
//    CarId = 21,
//    CustomerId = 25,
//    RentDate = new DateTime(2022, 3, 20),
//    ReturnDate = new DateTime(2022, 3, 23)
//});

//var sonuc1 = rentalManager.Add(new Rental
//{
//    CarId = 21,
//    CustomerId = 16,
//    RentDate = new DateTime(2022, 3, 21),
//    ReturnDate = new DateTime(2022, 3, 26)
//});

var sonuc2 = rentalManager.Add(new Rental
{
    CarId = 21,
    CustomerId = 18,
    RentDate = new DateTime(2022, 3, 17),
    ReturnDate = new DateTime(2022, 3, 19)
});

//var sonuc3 = rentalManager.Add(new Rental
//{
//    CarId = 21,
//    CustomerId = 17,
//    RentDate = new DateTime(2022, 4, 1),
//    ReturnDate = new DateTime(2022, 4, 5)
//});

//var sonuc4 = rentalManager.Add(new Rental
//{
//    CarId = 21,
//    CustomerId = 12,
//    RentDate = DateTime.Now
//});

//Console.WriteLine(sonuc.Message);
//Console.WriteLine(sonuc1.Message);
Console.WriteLine(sonuc2.Message);
//Console.WriteLine(sonuc3.Message);
//Console.WriteLine(sonuc4.Message);



static void GetCarDetail() 
{
    CarManager carManager = new CarManager(new EfCarDal());
    var result = carManager.GetCarDetails();

    if (result.Success)
    {
        foreach (var car in carManager.GetCarDetails().Data)
        {
            Console.WriteLine(car.CarName + " / " + car.BrandName + " / " + car.ColorName + " / " + car.DailyPrice);
        }
    }
    else
    {
        Console.WriteLine(result.Message);
    }
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

    var result = colorManager.GetAll();

    if (result.Success)
    {
        foreach (var color in colorManager.GetAll().Data)
        {
            Console.WriteLine(color.Name);
        }
    }
    else
    {
        Console.WriteLine(result.Message);
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

    var result = brandManager.GetAll();

    if (result.Success)
    {
        foreach (var brand in brandManager.GetAll().Data)
        {
            Console.WriteLine(brand.Name);
        }
    }
    else
    {
        Console.WriteLine(result.Message);
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

    var result = carManager.GetAll();

    if (result.Success)
    {
        foreach (var car in carManager.GetAll().Data)
        {
            Console.WriteLine(car.Description);
        }
    }
    else
    {
        Console.WriteLine(result.Message);
    }
}
