using Microsoft.EntityFrameworkCore;

namespace Slamty.Domain.Entities
{
    [Owned]
    public class Location
    {
        public double Lat { get; set; }
        public double Lng { get; set; }
        public string Name { get; set; }
    }
}
