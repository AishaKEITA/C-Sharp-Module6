using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment6
{
    class TaskManager
    {
        //declare a list<T> where T is a task type
        List<Task> tasksList;

        //create the tasklist in the constructor
        //will add, shrink or delete the object
        public TaskManager()
        {
            tasksList = new List<Task>();
        }

        /// <summary>
        /// get an object of the list in a certain position
        /// if found return index
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Task GetTask(int index)
        {
            if (CheckIndex(index))
            return tasksList[index];
            else
                return null;
        }

        /// <summary>
        /// to add the task object into the list
        /// ïf the list sucesseful, otherwise return false
        /// </summary>
        /// <param name="newTask"></param>
        /// <returns></returns>
        public  bool AddNewTask(Task newTask)
        {
            if (tasksList == null)
            {
                return false;
            }
            tasksList.Add(newTask);

            return true;
        }
        /// <summary>
        /// check index position and return true if index is greater or equal to 0
        /// and index is less than tasklist.Count
        /// otherwise return false
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public bool CheckIndex(int index)
        {
            bool ok = false;

            if ((index >= 0) && (index < tasksList.Count))
            {
                ok = true;
            }
            return ok;
        }

        /// <summary>
        /// add new task using object description, new time and priority
        /// </summary>
        /// <param name="newTime"></param>
        /// <param name="description"></param>
        /// <param name="priority"></param>
        /// <returns></returns>
        public bool AddNewTask(DateTime newTime, string description, PriorityType priority)
        {
            bool ok = true;

            Task newTask = new Task(newTime, description, priority);
            if (newTask != null)
                tasksList.Add(newTask);

            else
                ok = false;

            return ok;
        }

        /// <summary>
        /// the object replaces existing index position
        /// return true if sucessful otherwise false
        /// </summary>
        /// <param name="task"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public bool ChangeTaskAt(Task task, int index)
        {
            bool ok = true;
            if ((task != null) && CheckIndex(index))
                tasksList[index] = task;
            else
                ok = false;

            return ok;

        }

        /// <summary>
        /// delete task if index is greater or equal to zero
        /// true if sucessful otherwise false
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public bool DeleteTaskAt(int index)
        {
            bool ok = false;

            if ((index >= 0) && (index < tasksList.Count))
            {
                tasksList.RemoveAt(index);
                ok = true;
            }
            return ok;
        }

        /// <summary>
        /// a method that return a string
        /// is made of a string of any object in the tasklist
        /// </summary>
        /// <returns></returns>
        public string[] GetInfoStringsList()
        {
            string[] infoStrings = new string[tasksList.Count];

            for (int i = 0; i < infoStrings.Length; i++)
            {
                infoStrings[i] = tasksList[i].ToString();
            }

            return infoStrings;
        }

        /// <summary>
        /// a class that handles saving and reading data
        /// to and from text file. Send the task list
        /// from which data is read and saved to the file name
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public bool WriteDataToFile(string fileName)
        {
            FileManager fileManager = new FileManager();
            return fileManager.SaveTaskListToFile(tasksList, fileName);
        }

        /// <summary>
        /// send the tasklist object above
        /// data from the file name is saved
        /// make changes in the FileManager
        /// return ReadTaskListFrFile
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public bool ReadDataFromFile(string fileName)
        {
            FileManager fileManager = new FileManager();
            return fileManager.ReadTaskListFrFile(tasksList, fileName);
        }
    }
}
