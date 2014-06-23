using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDLibrary.DTOs.Interfaces
{
    public interface IDVDRepository
        //These methods MUST be followed
    {
        List<DVD> GetAllDvds();//Brings a full list of all dvds in memory or in database
        DVD GetbyID(int id);
        List<DVD> Search(string title, string director, string actor);//we have three search parameters, so we can pass them through
        void Add(DVD dvd);
        void Delete(int id); //sits in the Edit Page 
        void Edit(DVD dvd);



    }
}
