using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AppLabs.DTOs.Level3
{
    public class AlarmClockRequest
    {
        public string timerMessage { get; set; }
        public DateTime alarmTime { get; set; }
        public DateTime currentTime { get; set; }
        

    }
}
