using EntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Controllers
{
    public class MajorsController
    {
        private readonly EdDbContext _context;

        public MajorsController()
        {
            _context = new EdDbContext();
        }

        public List<Major> GetAll()
        {
            return _context.Majors.ToList();
        }
        public Major GetByPk(int Id)
        {
            return _context.Majors.Find(Id);
        }
        public Major GetByCode(string Code)
        {
            return _context.Majors.SingleOrDefault(m => m.Code == Code);
        }
        public bool Create(Major major)//first major is a major instance second major is the instance name/variable
        {
            major.Id = 0;
            _context.Majors.Add(major); //add a instance with Id of 0 and default description and Minsat
            var rowsAffected = _context.SaveChanges();
            if(rowsAffected != 1)
            {
                throw new Exception("Create failed");
            }
            return true;
        }
        public bool Change(int Id, Major major)
        {
            if(Id != major.Id)
            {
                throw new Exception("Ids don't match");
            }
            _context.Entry(major).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            var rowsAffected = _context.SaveChanges();
            if (rowsAffected != 1)
            {
                throw new Exception("Change failed");
            }
            return true;
        }
    }
}
