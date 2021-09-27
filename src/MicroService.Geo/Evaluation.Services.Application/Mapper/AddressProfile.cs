using AutoMapper;
using Evaluation.Services.Domain.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace Evaluation.Services.Application.Mapper
{
    public class AddressProfile : Profile
    {
        public AddressProfile()
        {

            CreateMap<Infrastructure.Entities.Address, Domain.Models.Address>();
            CreateMap<GeolocationRequest, Infrastructure.Entities.Address>();

        }
    }

}
