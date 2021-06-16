using BookA.Data;
using BookA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookA.Repository
{
    public class StudentRepository
    {
        private readonly BookStoreContext _context = null;
        public StudentRepository(BookStoreContext context)
        {
            _context = context;
        }
        public async Task<int> AddNewStudent(StudentModel model)
        {
            var newStudent = new Student()
            {
                first_name = model.first_name,
                last_name=model.last_name,
                email=model.email,
                password=model.password
            };
            await _context.Students.AddAsync(newStudent);
            await _context.SaveChangesAsync();
            return newStudent.id;
        }
    }
}
