using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVDLibrary.DTOs;
using DVDLibrary.DTOs.Interfaces;

namespace DVDLibrary.Data.InMemoryRepositories
{
    public class InMemoryDVDRepository: IDVDRepository  
    {
        private static readonly  List<DVD> _dvds= new List<DVD>();  //Instantiate the list to pass it through the methods

        static InMemoryDVDRepository()
        {
            // set up some sample data
            _dvds.AddRange(new DVD[]
            {
                new DVD{ Id=1, Title="The Shawshank Redemption", Director="Frank Darabont", Rating = "R", Year = 1994, Runtime = 146, Star = "Tim Robbins"},
                new DVD{ Id=2, Title="Sneakers", Director="Phil Alden Robinson", Rating = "PG-13", Year = 1992, Runtime = 126, Star = "Robert Redford"},

            });
        }

        public List<DVD> Search(string title, string director, string actor)//there are three search parameters and if all are populated we search on all three
        {
            if (String.IsNullOrEmpty(title) && String.IsNullOrEmpty(director) && !String.IsNullOrEmpty(actor))//if the title and director are empty, then return the actor as a filter A-Only
            {
                var results = _dvds.Where(d=>d.Title.StartsWith(actor));//only returns a list where actor matches
                return results.ToList();
            }

            else if (String.IsNullOrEmpty(title) && !String.IsNullOrEmpty(director) && String.IsNullOrEmpty(actor))//if the title and actor are empty, then return the director as a filter D-Only
            {
                var results = _dvds.Where(d => d.Title.StartsWith(director));//only returns a list where director matches
                return results.ToList();
            }

            else if (!String.IsNullOrEmpty(title) && String.IsNullOrEmpty(director) && String.IsNullOrEmpty(actor))//if the director and actor are empty, then return the title as a filter T-Only
            {
                var results = _dvds.Where(d => d.Title.StartsWith(title));//only returns a list where title matches
                return results.ToList();
            }

            else if (!String.IsNullOrEmpty(title) && !String.IsNullOrEmpty(director) && String.IsNullOrEmpty(actor))//if only actor is empty, then return the title and director T&D 
            {
                var results = _dvds.Where(d => d.Title.StartsWith(title)&& d.Director.StartsWith(director));
                return results.ToList();
            }

            else if (String.IsNullOrEmpty(title) && !String.IsNullOrEmpty(director) && !String.IsNullOrEmpty(actor))//if only actor is empty, then return the title and director A&D 
            {
                var results = _dvds.Where(d => d.Star.StartsWith(actor) && d.Director.StartsWith(director));
                return results.ToList();
            }

            else if (!String.IsNullOrEmpty(title) && !String.IsNullOrEmpty(director) && !String.IsNullOrEmpty(actor))//if all parameters have data in it then return a list filtering on all THREE A D and T
            {
                var results = _dvds.Where(d => d.Title.StartsWith(title) && d.Director.StartsWith(director) && d.Star.Contains(actor));//only returns list where ALL parameters match
                return results.ToList();
            }

            return new List<DVD>();//if all are null return a list
        }


        public List<DVD> GetAllDvds()
        {
            return _dvds;
        }



        public void Add(DVD dvd)
        {
            if (_dvds.Any())
                dvd.Id = _dvds.Max(d => d.Id) + 1;
            else
            {
               dvd.Id = 1;
               _dvds.Add(dvd);//Add and generate an ID to be the next in line
            }
        }

        public void Delete(int id)
        {
            _dvds.RemoveAll(d => d.Id == id);//Remove based on ID match
        }

        public void Edit(DVD dvd)
        {
            Delete(dvd.Id);
            _dvds.Add(dvd);//Edit based on ID match
        }

        public DVD GetbyID(int id)//Select a DVD by its unique identifier - use this if you want to assist the delete and edit functions
        {
            return _dvds.First(d => d.Id == id);
        }
    }
}
