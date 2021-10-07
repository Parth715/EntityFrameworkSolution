
using EntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EntityFramework.Controllers
{
    public class ClassController
    {
        private readonly EdDbContext _context;
        public ClassController()
        {
            _context = new EdDbContext();
        }
        public List<Class> GetAll()
        {
            return _context.Classes.ToList();
        }
        public Class GetByPk(int Id)
        {
            return _context.Classes.Find(Id);
        }
        public bool Create(Class room)
        {
            room.Id = 100;
            room.Code = "NFL";
            room.Subject = "Sports";
            room.Section = 101;
            _context.Add(room);
            var rowsAffected = _context.SaveChanges();
            if (rowsAffected != 1)
            {
                throw new Exception("The class could not be added to the table");
            }
            return true;
        }
        public bool Change(int Id, Class room)
        {
            if (Id != room.Id)
            {
                throw new Exception("The Id you provided does not match the Id with the instructor");
            }
            _context.Entry(room).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return true;
        }
        public bool Remove(int Id)
        {
            var room = _context.Instructors.Find(Id);
            if (room == null)
            {
                throw new Exception("That Id does not exist");
            }
            _context.Remove(Id);
            _context.SaveChanges();
            return true;
        }
    }
}
