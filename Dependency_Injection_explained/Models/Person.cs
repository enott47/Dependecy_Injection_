using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Dependency_Injection_explained.Models
{
    public class Person
    {
        
        public int? ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }

        public Person(int newID, string newNewFirstName, string newLastName, int newAge, string newEmail)
        {
            this.ID = newID;
            this.FirstName = newNewFirstName;
            this.LastName = newLastName;
            this.Age = newAge;
            this.Email = newEmail;
        }

        public Person()
        {
                //added to avoid unwanted use of first constructor
        }

    }
}