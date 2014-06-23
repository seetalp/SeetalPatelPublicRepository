using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLabs.DTOs.Level2
{
    public class FibonacciListerResponse
    {

        public FibonacciListerResponse()//Instantiate the list inside the model
        {
            fibonacciList = new List<int>();
        }
            public int a { get; set; }
            public int b { get; set; }
            public int givenNumber { get; set; }
            public int temp { get; set; }
            public List <int> fibonacciList { get; set; }
    }
}
