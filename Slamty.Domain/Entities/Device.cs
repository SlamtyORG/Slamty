using Microsoft.EntityFrameworkCore;
using Slamty.Domain.Enums;

namespace Slamty.Domain.Entities
{
    [Owned]
    public class Device
    {
        public DeviceType DeviceType { get; set; }
        public string Name { get; set; }
        public string SN { get; set; }

    }
}
