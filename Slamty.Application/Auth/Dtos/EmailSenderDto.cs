using Slamty.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Slamty.Application.Auth.Dtos
{
    public sealed record EmailSenderDto
    {
        [MaxLength(40)]
        [MinLength(3)]
        public string Subject { get; set; }
        [MinLength(3)]
        public string Body { get; set; }

        public AppUser? User { get; set; }
    }
}
