using EntityFramework.Controllers;
using EntityFramework.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFramework
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var majCtrl = new MajorsController();
            var majors = await majCtrl.GetAll();
            majors.ForEach(m => Console.WriteLine(m));
            var major = await majCtrl.GetByPk(1);
            Console.WriteLine(major);
        }
       
        
        
        
        static void X() { 
        //    Major major = null;
        //    var majorsCtrl = new MajorsController();
        //        var NewMajor = new Major()
        //        {
        //            Id = 0,
        //            Code = "MUSC",
        //            Description = "Music",
        //            MinSat = 1595
        //        };
        //        var returncode = majorsCtrl.Create(NewMajor);
        //    try
        //    {
        //        if (!returncode)
        //        {
        //            Console.WriteLine("Create Failed");
        //        }
        //    }catch (Exception ex)
        //    {
        //        Console.WriteLine($"Exception occurred: {ex.Message}");
        //    }
        //    NewMajor.Description = "Classical Music";
        //    majorsCtrl.Change(NewMajor.Id, NewMajor);

        //    var rc = majorsCtrl.Remove(NewMajor.Id);
        //    if (!rc)
        //    {
        //        Console.WriteLine("Remove Failed");
        //    }
        //    major = majorsCtrl.GetByCode("GENB");
        //    Console.WriteLine(major);

        //    major = majorsCtrl.GetByPk(2);
        //    Console.WriteLine($"{major.Description}");

            //major = majorsCtrl.GetByPk(1000);
            //if(major==null)
            //{
            //    Console.WriteLine("Major not found");
            //}
            //var majors = majorsCtrl.GetAll();
            //foreach(var m in majors)
            //{
            //    Console.WriteLine(m);
            //}
            
            
                             
        }
    }
}
