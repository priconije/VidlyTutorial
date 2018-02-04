using System;
using System.ComponentModel.DataAnnotations;
using Vidly.Models;

namespace Vidly.DTOs
{
    public class MovieDTO
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        [Required]
        [Range(0, 20, ErrorMessage = "The Number in Stock must be between 0 and 20.")]
        public int NumberInStock { get; set; }


        [Required]
        public int GenreId { get; set; }
    }
}