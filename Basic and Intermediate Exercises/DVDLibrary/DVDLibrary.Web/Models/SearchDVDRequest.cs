using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using DVDLibrary.DTOs;

namespace DVDLibrary.Web.Models
{
    public class SearchDVDRequest
    {
        
        public string SearchTitle { get; set; }
        public string SearchDirector { get; set; }
        public string SearchActor { get; set; }


        public List<DVD> SearchResults { get; set; }


        //public SearchDVDRequest()
        //{
        //    SearchResults = new List<DVD>();
        //}
       

    }
}