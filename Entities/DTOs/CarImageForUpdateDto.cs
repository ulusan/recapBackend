using Core.Entities;

namespace Entities.DTOs
{
    public class CarImageForUpdateDto : IDto
    {
        public int CarId { get; set; }
        public string Image { get; set; }
    }
}