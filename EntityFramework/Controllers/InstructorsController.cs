using EntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Controllers
{
    public class InstructorsController
    {
        private readonly EdDbContext _context;
        public InstructorsController()
        {
            _context = new EdDbContext();
        }
        public List<Instructor> GetAll()
        {
            return _context.Instructors.ToList();
        }
        public Instructor GetByPk(int Id)
        {
            return _context.Instructors.Find(Id);
        }

        public bool Create(Instructor teacher)
        {
            teacher.Id = 44;
            teacher.Firstname = "Greg";
            teacher.Lastname = "Doud";
            teacher.YearsExperience = 20;
            _context.Add(teacher);
            var rowsaffected = _context.SaveChanges();
            if (rowsaffected != 1)
            {
                throw new Exception("That instructor couldn't be added to the table");
            }
            return true;
        }

        public bool Change(int Id, Instructor teacher)
        {
            if (Id != teacher.Id)
            {
                throw new Exception("The Id you provided does not match the Id with the instructor");
            }
            _context.Entry(teacher).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return true;
        }
        public bool Remove(int Id)
        {
            var teacher = _context.Instructors.Find(Id);
            if (teacher == null)
            {
                throw new Exception("That Id does not exist");
            }
            _context.Remove(Id);
            _context.SaveChanges();
            return true;
        }
    }
}
