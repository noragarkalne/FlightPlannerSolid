using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;

namespace Flight_Planner.App_Start
{
    public class AutoMapperConfig
    {
        public static IMapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {

            });
            config.AssertConfigurationIsValid();
            var mapper = config.CreateMapper();
            return mapper;
        }
    }
}