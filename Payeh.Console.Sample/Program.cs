
using System;
using Payeh.DomainDrivenDesign.ValueObjects;

namespace Payeh.Console.Sample
{
    class Program
    {
        static void Main(string[] args)
        {


            string phone =  new Phone("0098","9371770774");
            System.Console.WriteLine(phone);
        }
    }
}