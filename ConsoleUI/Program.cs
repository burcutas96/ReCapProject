using Business.Concrete;
using Core.Entities.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

//RentalManager();
//UserManager();
//CustomerManager();
//GetCarDetail();
//ColorManager();
//BrandManager();
//CarManager();


static void RentalManager()
{
    RentalManager rentalManager = new RentalManager(new EfRentalDal());

    Rental rental1 = new Rental();
    rental1.CarId = 21;
    rental1.CustomerId = 25;
    rental1.RentDate = new DateTime(2022, 4, 18);
    rental1.ReturnDate = new DateTime(2022, 4, 20);

    Rental rental2 = new Rental();
    rental2.Id = 2;
    rental2.CarId = 21;
    rental2.CustomerId = 25;
    rental2.RentDate = new DateTime(2022, 6, 12);
    rental2.ReturnDate = new DateTime(2022, 6, 14);

    Console.WriteLine(rentalManager.Add(rental1).Message);
    Console.WriteLine(rentalManager.Delete(rental1).Message);
    Console.WriteLine(rentalManager.Update(rental2).Message);

    Console.WriteLine("Kiralanma tarihi: " + rentalManager.GetById(6).Data.RentDate);

    var result = rentalManager.GetAll();

    if (result.Success)
    {
        foreach (var rental in result.Data)
        {
            Console.WriteLine(rental.RentDate.ToString() + " " + rental.ReturnDate.ToString());
        }
    }
    else
    {
        Console.WriteLine(result.Message);
    }

}




static void UserManager()
{
    UserManager userManager = new UserManager(new EfUserDal());

    User user1 = new User();
    user1.FirstName = "Sema";
    user1.LastName = "Güneş";
    user1.Email = "semagunes@gmail.com";

    User user2 = new User();
    user2.Id = 17;
    user2.FirstName = "Sezer";
    user2.LastName = "Kanmaz";
    user2.Email = "duygudeniz@hotmail.com";

    userManager.Add(user1);

}





static void CustomerManager()
{
    CustomerManager customerManager = new CustomerManager(new EfCustomerDal());

    Customer customer1 = new Customer();
    customer1.UserId = 6;
    customer1.CompanyName = "Bor";

    Customer customer2 = new Customer();
    customer2.Id = 15;
    customer2.UserId = 27;
    customer2.CompanyName = "Elna";

    customerManager.Add(customer1);
    customerManager.Delete(customer1);
    customerManager.Update(customer2);

    var result = customerManager.GetAll();

    if (result.Success)
    {
        foreach (var customer in result.Data)
        {
            Console.WriteLine(customer.CompanyName);
        }
    }
    else
    {
        Console.WriteLine(result.Message);
    }

    Console.WriteLine(customerManager.GetById(12).Data.CompanyName);

}




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
