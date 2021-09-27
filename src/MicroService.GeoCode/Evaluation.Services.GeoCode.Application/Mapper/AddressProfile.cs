using AutoMapper;
using Evaluation.Services.GeoCode.Domain.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace Evaluation.Services.GeoCode.Application.Mapper
{
    public class AddressProfile : Profile
    {
        public AddressProfile()
        {
            CreateMap<Infrastructure.Entities.Address, Domain.Models.Address>();
            CreateMap<GeocodingAddressRequest, Infrastructure.Entities.Address>();

        }
    }

}
