using Core.Entities;
using Core.Entities.Abstract;
using Microsoft.AspNetCore.Http;

namespace Entities.Concrete
{
    public class CarImage : IEntity
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public string? ImagePath { get; set; }
        public DateTime Date { get; set; }
    }
}
