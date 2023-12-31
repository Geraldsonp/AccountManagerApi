using System;
using ApplicationLayer;
using ApplicationLayer.Domain.Enums;


namespace AccountManagerAPi.Dtos
{
    public record ClientResponse
    {
        public int ClientId { get; set; }
        public Status Status { get; set; }
        public string Name { get; set; } = null!;

        public Gender Gender { get; set; }

        public int Age { get; set; }

        public string Identification { get; set; } = null!;

        public string Address { get; set; } = null!;

        public string Phone { get; set; } = null!;
    }
}
