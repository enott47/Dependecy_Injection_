using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dependency_Injection_explained.Models;
using Newtonsoft.Json;
using System.Web.Mvc;

namespace Dependency_Injection_explained.Interfaces
{
    //Save Person Data
    public interface IPerson
    {
        string SavePersonData(Person person);


        //updates person data 
        string UpdatePersonData(Person person);

        //retrieve people data
        string GetAllPeopleData();

        //delete person
        string DeletePersonData(int personID);

        
    }
}
