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
    public class GroupController
    {
        private GroupRepository _groupRepository;

        public GroupController()
        {
            _groupRepository = new GroupRepository();
        }
        #region CreateGroup
        public void CreateGroup()
        {
            ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "Enter group name:");
            string name = Console.ReadLine();

            var group = _groupRepository.Get(g => g.Name.ToLower() == name.ToLower());
            if (group == null)
            {
            MaxSize: ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "Enter group max size:");
                string size = Console.ReadLine();
                int maxSize;
                bool result = int.TryParse(size, out maxSize);
                if (result)
                {
                    Group newGroup = new Group()
                    {
                        Name = name,
                        MaxSize = maxSize
                    };

                    var createdGroup = _groupRepository.Create(newGroup);
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"{createdGroup.Name} is created with max size:{createdGroup.MaxSize}");
                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please enter correct group max size");
                    goto MaxSize;
                }
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "This group doesn't exist");
            }
        }
        #endregion

        #region UpdateGroup

        public void UpdateGroup()
        {
            var groups = _groupRepository.GetAll();

            foreach (var dbGroup in groups)
            {
                Console.WriteLine($"ID - {dbGroup.Id} , Name - {dbGroup.Name}");
            }
            Id: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, "Enter group ID:");
            int chosenId;
            string id = Console.ReadLine();
            var result = int.TryParse(id, out chosenId);

            if (result)
            {
                var group = _groupRepository.Get(g => g.Id == chosenId);
                if (group != null)
                {
                    int oldSize = group.MaxSize;
                    string oldName = group.Name;
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, "Enter new group name");
                    string newName = Console.ReadLine();

                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, "Enter new group max size");
                    string size = Console.ReadLine();

                    int maxSize;
                    result = int.TryParse(size, out maxSize);

                    if (result)
                    {
                        var newGroup = new Group
                        {
                            Id = group.Id,
                            Name = newName,
                            MaxSize = maxSize
                        };

                        _groupRepository.Update(newGroup);

                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"Name:{oldName}, Max size: {oldSize} is update to Name:{newName} newSize:{maxSize} ");
                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please, enter correct group max size:");
                    }
                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please, enter correct group name");
                }
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Group doesn't exist with this ID");
                goto Id;
            }
        }

        #endregion

        #region DeleteGroup

        public void DeleteGroup()
        {
            var groups = _groupRepository.GetAll();
            if (groups.Count > 0)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "All groups");

                foreach (var dbGroup in groups)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, $"Id - {dbGroup.Id},Name - {dbGroup.Name}");
                }

            Id: ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "Enter group id :");
                int chosenId;
                string id = Console.ReadLine();
                var result = int.TryParse(id, out chosenId);
                if (result)
                {
                    var group = _groupRepository.Get(g => g.Id == chosenId);
                    if (group != null)
                    {
                        string name = group.Name;
                        _groupRepository.Delete(group);
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"{name} is deleted");
                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "This group doesn't exist");
                    }
                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Group doesn't exist with this id");
                    goto Id;
                }
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There are no any group");
            }

        }

        #endregion

        #region GetAll

        public void AllGroups()
        {
            ConsoleHelper.WriteTextWithColor(ConsoleColor.White, "All Groups");
            foreach (var group in _groupRepository.GetAll())
            {
                Console.WriteLine($"Name:{group.Name}, Max size:{group.MaxSize}");
            }
        }

        #endregion

        #region GetGroupByName

        public void GetGroupName()
        {
            ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, "Please enter group name:");
            string name = Console.ReadLine();

            var group = _groupRepository.Get(g => g.Name.ToLower() == name.ToLower());
            if (group != null)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"Name:{group.Name}, Max size: {group.MaxSize}");
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "This group doesn't exist");
            }
        }

        #endregion

        #region Exit

        public void Exit()
        {
            ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, "Thank you good bye :) ");
        }
        #endregion
    }
}
