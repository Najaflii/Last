using Core.Constants;
using Core.Entities;
using Core.Helpers;
using DataAccess.Repositories.Implementations;
using Manage.Controllers;

namespace Manage
{
    public class Program
    {
        static void Main()
        {
            GroupController groupController = new GroupController();
            StudentController studentController = new StudentController();
            AdminController adminController = new AdminController();
            TeacherController teacherController = new TeacherController();


            ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, " Welcome :) ");



        Authentication: var admin = adminController.Authenticate();

            if (admin != null)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"Welcome :) , {admin.Username}");

                Console.WriteLine("---");
                while (true)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "1 - Create Group");
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "2 - Update Group");
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "3 - Delete Group");
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "4 - All Groups");
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "5 - Get Group by name");
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "6 - Create Student");
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "7 - Update Student");
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "8 - Delete Student");
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "9 - All Students by Group");
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "10 - Get Student by Group");
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "11 - Create Teacher");
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "12 - Update Teacher");
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "13 - Delete Teacher");
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "14 - All Teachers");
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "15 - Add Group to Teacher");
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "16 - All Groups of Teacher ");
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.White, "0 - Exit");

                    Console.WriteLine("---");

                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkYellow, "Please Select Option");
                    string number = Console.ReadLine();

                    int SelectedNumber;
                    bool result = int.TryParse(number, out SelectedNumber);
                    if (result)
                    {
                        if (SelectedNumber >= 0 && SelectedNumber <= 16)
                        {
                            switch (SelectedNumber)
                            {
                                case (int)Options.CreateGroup:
                                    groupController.CreateGroup();
                                    break;
                                case (int)Options.UpdateGroup:
                                    groupController.UpdateGroup();
                                    break;
                                case (int)Options.DeleteGroup:
                                    groupController.DeleteGroup();
                                    break;
                                case (int)Options.AllGroups:
                                    groupController.AllGroups();
                                    break;
                                case (int)Options.GetGroupByName:
                                    groupController.GetGroupName();
                                    break;
                                case (int)Options.CreateStudent:
                                    studentController.CreateStudent();
                                    break;
                                case (int)Options.UpdateStudent:
                                    studentController.UpdateStudent();
                                    break;
                                case (int)Options.DeleteStudent:
                                    studentController.DeleteStudent();
                                    break;
                                case (int)Options.AllStudentsByGroup:
                                    studentController.AllStudentsByGroup();
                                    break;
                                case (int)Options.GetStudentByGroup:
                                    studentController.GetStudentByGroup();
                                    break;
                                case (int)Options.CreateTeacher:
                                    teacherController.CreateTeacher();
                                    break;
                                case (int)Options.UpdateTeacher:
                                    teacherController.UpdateTeacher();
                                    break;
                                case (int)Options.DeleteTeacher:
                                    teacherController.DeleteTeacher();
                                    break;
                                case (int)Options.AllTeachers:
                                    teacherController.GetAll();
                                    break;
                                case (int)Options.AddGroupToTeacher:
                                    teacherController.AddGroupToTeacher();
                                    break;
                                case (int)Options.AllGroupsOfTeacher:
                                    teacherController.GetAllGroupsByTeacher();
                                    break;
                                case (int)Options.Exit:
                                    groupController.Exit();
                                    break;
                            }
                        }
                        else
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Sorry entered wrong number");
                        }
                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, " Please enter number");
                    }
                }
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Admin username or Password is incorrect ");
                goto Authentication;
            }
        }
    }
}