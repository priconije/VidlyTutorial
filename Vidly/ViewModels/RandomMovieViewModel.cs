using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    // ViewModel u ASP.NETu je vezan za jedan View i sadrzi sve sto treba tom View-u, 
    // npr. ako hocemo da prosledimo 2+ modela (Movie, Customer) na jedan View moramo koristiti ViewModel
    // Ovaj ViewModel ce biti vezan za Random.cshtml
    // Potrebno je na Random.cshtml promeniti:
    //                          @model Vidly.ViewModels.RandomMovieViewModel
    // Nakon toga pristupamo property-jima iz VM: @Model.Movie.Name
    public class RandomMovieViewModel
    {
        public Movie Movie { get; set; }
        public List<Customer> Customers { get; set; }


    }
}