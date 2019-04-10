using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Videly.Dtos;
using Videly.Models;

namespace Videly.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<CustomerDto, Customer>();
        }
    }
}