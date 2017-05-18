using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using DnnInterProj.EntityModel.Dtos;
using DnnInterProj.EntityModel.Model;

namespace DnnInterProj.App_Start
{
    public class MappinProfile : Profile
    {
        public MappinProfile()
        {
            Mapper.CreateMap<Person, PersonDto>();
            Mapper.CreateMap<PersonDto, Person>()
                .ForMember(dest => dest.JoinedDate, opt => opt.UseValue<DateTime>(DateTime.Now));

            Mapper.CreateMap<Person, Person>();

        }

    }

}