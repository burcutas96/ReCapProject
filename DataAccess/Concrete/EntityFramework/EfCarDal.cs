using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, SouthwindContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (SouthwindContext context = new SouthwindContext())
            {
                var result = from car in context.Cars
                             join brand in context.Brands
                             on car.BrandId equals brand.Id
                             join color in context.Colors
                             on car.ColorId equals color.Id
                             select new CarDetailDto 
                             { 
                                 CarId = car.Id, CarName = car.Description, BrandName = brand.Name, ColorName = color.Name, DailyPrice = car.DailyPrice 
                             };

                return result.ToList();      
            }
        }
    }
}
