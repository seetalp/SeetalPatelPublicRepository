using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppLabs.DTOs.Level1;

namespace AppLabs.BLL.Level1
{
    public class LeapYearCalculator
    {

        public LeapYearResponse FindLeapYear(LeapYearRequest request)
        {

            LeapYearResponse response = new LeapYearResponse();

            response.StartYear = request.StartYear;//set user formatted input to now equal our stored output value ("response")
            response.EndYear = request.EndYear;


            for (int i = response.StartYear; i < response.EndYear; i++)
            {
                if ((i % 4 == 0 && i % 100 != 0) || (i % 4 == 0 && i % 100 == 0 && i % 400 == 0))
                    response.LeapYearlist.Add(i);

            }

            return response;
        }

    }
}
