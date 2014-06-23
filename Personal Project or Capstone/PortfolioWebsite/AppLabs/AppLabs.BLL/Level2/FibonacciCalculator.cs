using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppLabs.DTOs.Level2;

namespace AppLabs.BLL.Level2
{
    public class FibonacciCalculator
    {

        public FibonacciListerResponse FibonacciLister(FibonacciListerRequest request)
        {
            var response = new FibonacciListerResponse();
            response.givenNumber = request.givenNumber;
            response.a = 0;
            response.b = 1;

            for (int i = 0; i < response.givenNumber; i++)
            {
                response.temp = response.a;
                response.a = response.b;
                response.b = response.temp + response.b;
                response.fibonacciList.Add(response.a);
            }

            return response;
        }
    }
}



//this didn't work for when n was >100
            //var response = new FibonacciListerResponse();
            //response.givenNumber = request.givenNumber;
            //response.nextValue = 1;
            //response.prevValue = -1;

            //for (int i = 0; i < response.givenNumber; i++)
            //{
            //    response.sumNumbers = response.nextValue + response.prevValue;
            //    response.prevValue = response.nextValue;
            //    response.nextValue = response.sumNumbers;
            //    response.fibonacciList.Add(response.nextValue);

            //}
            //return response;