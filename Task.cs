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
            set
            {
             if (!string.IsNullOrEmpty(value))
                 description = value;
            }
        }
        /// <summary>
        /// get date format into hour, and minute into string
        /// </summary>
        /// <returns></returns>
        private string GetTimeString()
        {
            string time = string.Format("{0}: {1}", date.Hour.ToString("00"),
                date.Minute.ToString("00"));

            return time;
        }

        /// <summary>
        /// replace the proirity list underscore to an empty string
        /// </summary>
        /// <returns></returns>
        public string GetPriorityString()
        {
            string txtOut = Enum.GetName(typeof(PriorityType), priority);
            txtOut = txtOut.Replace("_", " ");
            return txtOut;
        }

        /// <summary>
        /// an alternative way to format into a string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string txtOut = $"{date.ToLongDateString(),-25} {GetTimeString(),12} {" ", 6} {GetPriorityString(),25} {description,40}";

            return txtOut;
        }
    }
}
