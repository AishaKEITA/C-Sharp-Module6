using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment6
{
    public class Task
    {
        private DateTime date;//to access date and time of the task
        private string description;//will allow the user to add the description of the task
        private PriorityType priority;//this will give the user the priority selected


        //default constructor
        public Task()
        {
            priority = PriorityType.Normal;
        }
        /// <summary>
        /// constructor with parameter
        /// the other constructors are called using the this keyyword
        /// </summary>
        /// <param name="taskDate"></param>
        public Task(DateTime taskDate) : this(taskDate, string.Empty, PriorityType.Normal)
        {

        }
        /// <summary>
        /// description, date, and priority are object saved here using this
        /// </summary>
        /// <param name="taskDate"></param>
        /// <param name="description"></param>
        /// <param name="priority"></param>
        public Task(DateTime taskDate, string description, PriorityType priority)
        {
            this.date = taskDate;
            this.description = description;
            this.priority = priority;
        }

        /// <summary>
        /// to give a read and write access to date
        /// </summary>
        public DateTime DateAndTime
        {
            get { return date; }
            set { date = value; }
        }

        /// <summary>
        /// to give a read and write access for priority type
        /// </summary>
        public PriorityType Priority
        {
            get { return priority; }
            set { priority = value; }
        }
        /// <summary>
        /// to give a read and write access to description
        /// </summary>
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
    }
}
