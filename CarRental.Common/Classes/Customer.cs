using System;
using System.Collections.Generic;
using System.Text;
using CarRental.Common.Interfaces;

namespace CarRental.Common.Classes
{
    public class Customer : IPerson
    {
        public int Id { get; }

        public string SocialSecurityNumber { get; }

        public string FirstName { get; }

        public string LastName { get; }

        public Customer(int id, string socialSecurityNumber, string firstName, string lastName)
        {
            Id = id;
            SocialSecurityNumber = socialSecurityNumber;
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
