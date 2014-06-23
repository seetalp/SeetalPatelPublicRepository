using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRMetrics.Models
{
    public class RetentionRequest
    {

        public decimal OneYearTenureHeadcount { get; set; }
        public decimal ThreeYearTenureHeadcount { get; set; }
        public decimal FiveYearTenureHeadcount { get; set; }
        public decimal TotalHeadcount { get; set; }
        

    }

    public class RetentionResponse
    {

        public decimal OneYearTenureHeadcount { get; set; }
        public decimal ThreeYearTenureHeadcount { get; set; }
        public decimal FiveYearTenureHeadcount { get; set; }
        public decimal TotalHeadcount { get; set; }
        public decimal RetentionPercentage { get; set; }

    }
}