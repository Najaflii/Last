using Core.Entities;
using Core.Helpers;
using DataAccess.Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manage.Controllers
{
    public class TeacherController
    {
        private GroupRepository _groupRepository;

        private StudentRepository _studentRepository;

        private TeacherRepository _teacherRepository;

        public TeacherController()
        {
            _studentRepository = new StudentRepository();
            _groupRepository = new GroupRepository();
            _teacherRepository = new TeacherRepository();
        }




        #region CreateTeacher

        public void CreateTeacher()
        {
            ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "Enter new teacher name ");
            string name = Console.ReadLine();

            ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "Enter new teacher surname ");
            string surname = Console.ReadLine();

        Age: ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "Enter new teacher age");
            string age = Console.ReadLine();

            byte teacherAge;
            var result = byte.TryParse(age, out teacherAge);
            if (result)
            {
                var teacher = new Teacher
                {
                    Name = name,
                    Surname = surname,
                    Age = teacherAge,
                };
                var dbTeacher = _teacherRepository.Create(teacher);
                if (dbTeacher != null)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"{dbTeacher.Name} , {dbTeacher.Surname} , {dbTeacher.Age}");
                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, $"Something went wrong");
                }
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please enter correct age");
                goto Age;
            }
        }

        #endregion

        #region UpdateTeacher
        public void UpdateTeacher()
        {

            var teachers = _teacherRepository.GetAll();
            if (teachers.Count > 0)
            {
                foreach (var teacher in teachers)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, $"{teacher.Id} , {teacher.Name} , {teacher.Surname}");

                Id: ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "Enter teacher id ");
                    string id = Console.ReadLine();
                    int teacherId;
                    var result = int.TryParse(id, out teacherId);
                    if (result)
                    {
                        var dbTeacher = _teacherRepository.Get(t => t.Id == teacherId);
                        if (dbTeacher != null)
                        {

                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "Enter teacher new name");
                            string newName = Console.ReadLine();

                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "Enter teacher new surname");
                            string newSurname = Console.ReadLine();

                        NewAge: ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "Enter teacher new age");
                            string newAge = Console.ReadLine();

                            byte teacherNewAge;
                            result = byte.TryParse(newAge, out teacherNewAge);
                            if (result)
                            {
                                var updateTeacher = new Teacher
                                {
                                    Id = dbTeacher.Id,
                                    Name = newName,
                                    Surname = newSurname,
                                    Age = teacherNewAge
                                };

                                _teacherRepository.Update(updateTeacher);

                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"{updateTeacher.Name} , {updateTeacher.Surname} ");
                            }
                            else
                            {
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Enter age in correct format");
                                goto NewAge;
                            }
                        }
                        else
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Teacher doesn't exist with this id");
                            goto Id;
                        }
                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please enter id in correct format");
                        goto Id;
                    }
                }
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, " There are no any teacher ");
            }

        }

        #endregion

        #region DeleteTeacher
        public void DeleteTeacher()
        {
            var teachers = _teacherRepository.GetAll();
            if (teachers.Count > 0)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Blue, "All teacher list ");
                foreach (var teacher in teachers)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, $"ID - {teacher.Id}, FullName - {teacher.Name} {teacher.Surname}");
                }

            Id: ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "Enter teacher id ");
                string id = Console.ReadLine();
                int teacherId;
                var result = int.TryParse(id, out teacherId);

                if (result)
                {
                    var teacher = _teacherRepository.Get(t => t.Id == teacherId);
                    if (teacher != null)
                    {
                        string fullName = $"{teacher.Name} {teacher.Surname}";
                        _teacherRepository.Delete(teacher);
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"{fullName} is deleted ");
                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Teacher doesn't exist with this id ");
                        goto Id;
                    }
                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Enter id in correct format");
                    goto Id;
                }
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There are no any teacher ");
            }
        }

        #endregion

        #region GetAll

        public void GetAll()
        {
            var teachers = _teacherRepository.GetAll();
            if (teachers.Count > 0)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, "All teachers list");
                foreach (var teacher in teachers)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"Id - {teacher.Id} , FullName - {teacher.Name} {teacher.Surname}");
                }
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There is no any teacher");
            }

        }

        #endregion

        #region AddGroupToTeacher

        public void AddGroupToTeacher()
        {
            var groups = _groupRepository.GetAll();
            if (groups.Count > 0)
            {
                var teachers = _teacherRepository.GetAll();
                if (teachers.Count > 0)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Blue, "All teacher list");
                    foreach (var teacher in teachers)
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"Id - {teacher.Id} , FullName - {teacher.Name} {teacher.Surname}");
                    }
                Id: ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "Enter teacher id");
                    string id = Console.ReadLine();

                    int teacherId;
                    var result = int.TryParse(id, out teacherId);
                    if (result)
                    {
                        var teacher = _teacherRepository.Get(t => t.Id == teacherId);
                        if (teacher != null)
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Blue, "All groups list");
                            foreach (var group in groups)
                            {
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"Id - {group.Id},Name - {group.Name}");
                            }
                        GroupId: ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "Enter group id");
                            string groupid = Console.ReadLine();
                            int groupId;
                            result = int.TryParse(groupid, out groupId);
                            if (result)
                            {
                                var group = _groupRepository.Get(t => t.Id == groupId);
                                if (group != null)
                                {
                                    if (group.Teacher == null)
                                    {
                                        teacher.Groups.Add(group);
                                        group.Teacher = teacher;
                                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"{group.Name} is added to {teacher.Name}");

                                    }
                                    else
                                    {
                                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, $"This group has already teacher - {group.Teacher.Name} {group.Teacher.Surname}");
                                    }
                                }
                                else
                                {
                                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Group doesn't exist with this id");
                                    goto GroupId;
                                }
                            }
                            else
                            {
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Enter id in correct format");
                                goto GroupId;
                            }
                        }
                        else
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Teacher doesn't exist with this id");
                            goto Id;
                        }
                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Enter id in correct format");
                        goto Id;
                    }
                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There is no any teacher");
                }

            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "You must create a group before adding group to teacher");
            }

        }
        #endregion

        #region GetAllGroupsByTeacher

        public void GetAllGroupsByTeacher()
        {
            var teachers = _teacherRepository.GetAll();
            if (teachers.Count > 0)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "All teachers list");
                foreach (var teacher in teachers)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"Id - {teacher.Id} , Fullname - {teacher.Name} {teacher.Surname}");
                }
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow,"Enter teacher id");
                string id = Console.ReadLine();

                int teacherId;
                var result = int.TryParse(id, out teacherId);
                if (result)
                {
                    var teacher = _teacherRepository.Get(t => t.Id == teacherId);
                    if (teacher != null)
                    {
                        var groups = _groupRepository.GetAll(g => g.Teacher == null ? g.Teacher.Id == teacher.Id : false);
                        if (groups.Count > 0)
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "The groups of teacher");
                            foreach (var group in groups)
                            {
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"Id - {group.Id} Name - {group.Name}");
                            }
                        }
                        else
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Teacher has no group");
                        }
                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Teacher doesn't exist with this id");
                    }
                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Enter id in correct format");
                }
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There is no any teacher");
            }
        }

        #endregion
    }
}
