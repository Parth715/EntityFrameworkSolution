using EntityFramework.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Controllers
{
    public class StudentsController
    {
        private readonly EdDbContext _context;

        public StudentsController()
        {
            _context = new EdDbContext();
        }

        public List<Student> GetAll()
        {
            return _context.Students.Include(x => x.Major).ToList();
        }

        public Student GetByPk(int Id)
        {
            return _context.Students.Include(x => x.Major).SingleOrDefault(s => s.Id == Id);
        }
        
        public bool Create(Student student)
        {
            student.Id = 0;
            student.Firstname = "Parth";
            student.Lastname = "Patel";
            student.Gpa = 3.4m;
            student.Sat = 1170;
            _context.Students.Add(student);
            var rowsAffected = _context.SaveChanges();
            if(rowsAffected != 1)
            {
                throw new Exception("Creation failed");
            }
            return true;
        }
        
        public bool Change(int id, Student student)
        {
            if(id != student.Id)
            {
                throw new Exception("Ids don't match");
            }
            _context.Entry(student).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            var rowsAffected = _context.SaveChanges();
            if(rowsAffected != 1)
            {
                throw new Exception("Change failed");
            }
            return true;
        }

        public bool Remove(int Id)
        {
            var student = _context.Students.Find(Id);
            if(student == null)
            {
                return false;
            }
            _context.Remove(Id);
            _context.SaveChanges();
            return true;
        }
    }
}
