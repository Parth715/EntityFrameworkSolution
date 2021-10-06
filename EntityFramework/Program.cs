using EntityFramework.Controllers;
using EntityFramework.Models;
using System;
using System.Linq;

namespace EntityFramework
{
    class Program
    {
        static void Main(string[] args)
        {
            Major major = null;
            var majorsCtrl = new MajorsController();
            try
            {
                var NewMajor = new Major()
                {
                    Id = 0,
                    Code = "MUSC",
                    Description = "Music",
                    MinSat = 1595
                };
                var returncode = majorsCtrl.Create(NewMajor);
                if (!returncode)
                {
                    Console.WriteLine("Create Failed");
                }
            }catch (Exception ex)
            {
                Console.WriteLine($"Exception occurred: {ex.Message}");
            }
            major = majorsCtrl.GetByCode("GENB");
            Console.WriteLine(major);

            major = majorsCtrl.GetByPk(2);
            Console.WriteLine($"{major.Description}");

            major = majorsCtrl.GetByPk(1000);
            if(major==null)
            {
                Console.WriteLine("Major not found");
            }
            var majors = majorsCtrl.GetAll();
            foreach(var m in majors)
            {
                Console.WriteLine($"{m.Description}");
            }
            
            
                             
        }
    }
}
