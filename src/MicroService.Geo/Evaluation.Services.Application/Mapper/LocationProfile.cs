using AutoMapper;
using Evaluation.Services.Domain.Request;
using Evaluation.Services.Domain.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Evaluation.Services.Application.Mapper
{
    public class LocationProfile : Profile
    {
        public LocationProfile()
        {

            CreateMap<Infrastructure.Entities.Location, Domain.Models.Location>();
            CreateMap<Infrastructure.Entities.Location, GeocodingResponse>();

        }
    }

}
