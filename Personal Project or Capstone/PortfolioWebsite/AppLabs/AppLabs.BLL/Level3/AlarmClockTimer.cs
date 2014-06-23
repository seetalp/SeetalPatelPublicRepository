using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppLabs.DTOs.Level3;

namespace AppLabs.BLL.Level3
{
    public class AlarmClockTimer
    {

        public AlarmClockResponse SetAlarm (AlarmClockRequest request)
        {
            var response = new AlarmClockResponse();

            
            request.timerMessage = response.timerMessage;

            if (request.currentTime == request.alarmTime)
            {
                
            }
             
                return response;
        }



    }
}
