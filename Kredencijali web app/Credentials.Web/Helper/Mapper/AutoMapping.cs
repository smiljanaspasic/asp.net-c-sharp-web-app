using Credentials.Data;
using Credentials.Web.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBook.Web.Helper.Mapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
           


            CreateMap<KredencijaliModel, Kredencijali>();
            CreateMap<Kredencijali, KredencijaliModel>();
        }
    }
}
