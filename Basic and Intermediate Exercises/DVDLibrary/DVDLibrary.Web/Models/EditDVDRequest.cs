using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using DVDLibrary.DTOs;

namespace DVDLibrary.Web.Models
{
    public class EditDVDRequest
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a title!")]
        public string Title { get; set; }
        public string Rating { get; set; }
        [Required(ErrorMessage = "Please enter a year that is after 1900 and before 2020!")]
        [Range(1900, 2020)]
        public int Year { get; set; }
        [Required(ErrorMessage = "Please enter a valid runtime")]
        [Range(0, 1000)]
        public int Runtime { get; set; }
        public string Director { get; set; }
        public string Star { get; set; }

        public EditDVDRequest()
        {
            
        }

        public EditDVDRequest(DVD dvd)
        {
            Id = dvd.Id;
            Title = dvd.Title;
            Rating = dvd.Rating;
            Year = dvd.Year;
            Runtime = dvd.Runtime;
            Director = dvd.Director;
            Star = dvd.Star;
        }

        public DVD CreateDvd()
        {
            return new DVD
            {
                Id = Id,
                Title = Title,
                Rating = Rating,
                Year = Year,
                Runtime = Runtime,
                Director = Director,
                Star = Star
            };
        }
    }
}