using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRMetrics.Models
{
    public class TurnoverRequest
    {

        public decimal StartHeadcount { get; set; }
        public decimal EndHeadcount { get; set; }
        public decimal TotalTerminations { get; set; }
        public decimal VoluntaryTerminations { get; set; }
        public decimal InvoluntaryTerminations { get; set; }
        public decimal VolunataryRegrettableTerminations { get; set; }
        public decimal VolunataryNotRegrettableTerminations { get; set; }
    
    }

    public class TurnoverResponse
    {

        public decimal StartHeadcount { get; set; }
        public decimal EndHeadcount { get; set; }
        public decimal AverageHeadcount { get; set; }
        public decimal TotalTerminations { get; set; }
        public decimal VoluntaryTerminations { get; set; }
        public decimal InvoluntaryTerminations { get; set; }
        public decimal VolunataryRegrettableTerminations { get; set; }
        public decimal VolunataryNotRegrettableTerminations { get; set; }
        public decimal TotalTurnover { get; set; }
        public decimal VoluntaryTurnover { get; set; }
        public decimal InvoluntaryTurnover { get; set; }
        public decimal RegrettableTurnover { get; set; }
    }

    
}