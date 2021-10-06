using System;
using System.Collections.Generic;

#nullable disable

namespace EntityFramework.Models
{
    public partial class Major
    {
        public override string ToString() //console writeline automatically calls tostring in console.writeline() 
        {                                   //so now we get a custom tostring and it will input these 4 pieces of data into the major instance that is being called
            return $"{Id} | {Code} | {Description} | {MinSat}";
        }
        public Major()
        {
            MajorClasses = new HashSet<MajorClass>();
            Students = new HashSet<Student>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public int MinSat { get; set; }

        public virtual ICollection<MajorClass> MajorClasses { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
