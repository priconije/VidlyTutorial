using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.DTOs;
using Vidly.Models;

namespace Vidly.App_Start
{
    /*
     *                  ========== AutoMapper ==========
     *                  
     * Za instalaciju: Nuget konzola -> Install-Package automapper -version:4.1
     * Nakon toga se kreira ova klasa koja nasledjuje Profile.
     * AutoMapper mapira property-je dve klase po IMENIMA, tako da je npr.
     * Customer Name == CustomerDTO Name.
     * Nakon sto se ovde definisu mapiranja, treba u Global.asax podesiti da se mapper
     * ucita pri startu aplikacije.
     */
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {            
            Mapper.CreateMap<Customer, CustomerDTO>();
            Mapper.CreateMap<CustomerDTO, Customer>();
        }
    }
}