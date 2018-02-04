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
            // Property-je koji se generisu automatski ili su kljucevi, poput ID, trebalo bi iskljuciti iz mapiranja kako ih AutoMapper ne bi slucajno promenio
            Mapper.CreateMap<Customer, CustomerDTO>().ForMember(c => c.Id, opt => opt.Ignore());
            Mapper.CreateMap<CustomerDTO, Customer>();

            Mapper.CreateMap<Movie, MovieDTO>().ForMember(m => m.Id, opt => opt.Ignore());   
            Mapper.CreateMap<MovieDTO, Movie>();
        }
    }
}