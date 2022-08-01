using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using DataAccess.Contexts;
using DataAccess.Repositories.Base;

namespace DataAccess.Repositories.Implementations
{
    public class StudentRepository : IRepository<Student>
    {
        public Student Create(Student entity)
        {
            try
            {
                DbContext.Students.Add(entity);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return entity;
        }
        public void Delete(Student entity)
        {
            try
            {
                DbContext.Students.Remove(entity);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void Update(Student entity)
        {
            try
            {
                var student = DbContext.Students.Find(s => s.Id == entity.Id);
                if (student != null)
                {
                    student.Name = entity.Name;
                    student.Surname = entity.Surname;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public Student Get(Predicate<Student> filter = null)
        {
            try
            {
                if (filter == null)
                {
                    return DbContext.Students[0];
                }
                else
                {
                    return DbContext.Students.Find(filter);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public List<Student> GetAll(Predicate<Student> filter = null)
        {
            try
            {
                if (filter == null)
                {
                    return DbContext.Students;
                }
                else
                {
                    return DbContext.Students.FindAll(filter);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
    }
}
