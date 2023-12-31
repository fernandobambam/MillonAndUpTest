﻿using MediatR;

namespace Application.EProperties.Commands.CreateProperty
{
    public class CreatePropertyRequest : IRequest<Unit>
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public decimal Price { get; set; }
        public string? CodeInternal { get; set; }
        public int Year { get; set; }
        public int? IdOwner { get; set; }
    }
}
