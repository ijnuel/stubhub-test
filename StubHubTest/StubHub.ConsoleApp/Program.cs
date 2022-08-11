using StubHub.ConsoleApp;
using StubHub.ConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Viagogo
{
    public class Solution
    {
        static void Main(string[] args)
        {
            var events = new List<Event>{
                new Event{ Name = "Phantom of the Opera", City = "New York"},
                new Event{ Name = "Metallica", City = "Los Angeles"},
                new Event{ Name = "Metallica", City = "New York"},
                new Event{ Name = "Metallica", City = "Boston"},
                new Event{ Name = "LadyGaGa", City = "New York"},
                new Event{ Name = "LadyGaGa", City = "Boston"},
                new Event{ Name = "LadyGaGa", City = "Chicago"},
                new Event{ Name = "LadyGaGa", City = "San Francisco"},
                new Event{ Name = "LadyGaGa", City = "Washington"}
            };

            //1. find out all events that arein cities of customer
            // then add to email.
            var customer = new Customer { Name = "Mr. Fake", City = "New York" };

            var customers = new List<Customer>{
                new Customer{ Name = "Nathan", City = "New York"},
                new Customer{ Name = "Bob", City = "Boston"},
                new Customer{ Name = "Cindy", City = "Chicago"},
                new Customer{ Name = "Lisa", City = "Los Angeles"}
            };

            SendEmails(events, customer);

            customers.ForEach(item => SendEmails(events, item));




            /**
            We want you to send an email to this customer with all events in their city
            * Just call AddToEmail(customer, event) for each event you think they should get
            */
        }

        static void SendEmails(List<Event> events, Customer customer)
        {
            PrintDots();
            Solutions.DefaultCode(events, customer);
            PrintDots();
            Solutions.ProblemOne(events, customer);
            PrintDots();
            Solutions.ProblemTwo(events, customer);
            PrintDots();
            Solutions.ProblemThree(events, customer);
            PrintDots();
            Solutions.ProblemFour(events, customer);
            PrintDots();
            Solutions.ProblemFive(events, customer);
            PrintDots();
        }


        static void PrintDots()
        {
            Console.WriteLine("************************************************************");
        }


    }
} /*
var customers = new List<Customer>{
new Customer{ Name = "Nathan", City = "New York"},
new Customer{ Name = "Bob", City = "Boston"},
new Customer{ Name = "Cindy", City = "Chicago"},
new Customer{ Name = "Lisa", City = "Los Angeles"}
};
*/