using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment6
{
    class FileManager
    {
        //fields
        private const string fileVersionToken = "ToDoRe_21";
        private const double fileVersionNr = 1.0;

        /// <summary>
        /// method to save task list
        /// and list of files
        /// </summary>
        /// <param name="tasklist"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public bool SaveTaskListToFile(List<Task> tasklist, string fileName)
        {
            bool ok = true;
            StreamWriter writer = null;
            try
            {
                writer = new StreamWriter(fileName);
                writer.WriteLine(fileVersionToken);
                writer.WriteLine(fileVersionNr);
                writer.WriteLine(tasklist.Count);

                for (int i = 0; i < tasklist.Count; i++)
                {
                    writer.WriteLine(tasklist[i].Description);
                    writer.WriteLine(tasklist[i].Priority.ToString());
                    writer.WriteLine(tasklist[i].DateAndTime.Year);
                    writer.WriteLine(tasklist[i].DateAndTime.Month);
                    writer.WriteLine(tasklist[i].DateAndTime.Day);
                    writer.WriteLine(tasklist[i].DateAndTime.Hour);
                    writer.WriteLine(tasklist[i].DateAndTime.Minute);
                    writer.WriteLine(tasklist[i].DateAndTime.Second);

                }
            }
            catch
            {
                ok = false;
            }

            finally

            {
                if (writer != null)
                    writer.Close();
            }
            return ok;
        }
        /// <summary>
        /// method to read task list
        /// and file names
        /// </summary>
        /// <param name="tasklist"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public bool ReadTaskListFrFile(List<Task> tasklist, string fileName)
        {
            bool ok = true;

            StreamReader reader = null;

            try
            {
                if (tasklist != null)
                    tasklist.Clear();
                else
                    tasklist = new List<Task>();

                reader = new StreamReader(fileName);

                string versionTest = reader.ReadLine();
                double version = double.Parse(reader.ReadLine());

                if ((versionTest == fileVersionToken) && (version == fileVersionNr))
                {
                    int count = int.Parse(reader.ReadLine());
                    for (int i = 0; i < count; i++)
                    {
                        Task task = new Task();
                        task.Description = reader.ReadLine();
                        task.Priority = (PriorityType)Enum.Parse(typeof(PriorityType), reader.ReadLine());

                        //read only objects
                        int year = 0, motnth = 0, day = 0;
                        int hour = 0, minute = 0, second = 0;

                        year = int.Parse(reader.ReadLine());
                        motnth = int.Parse(reader.ReadLine());
                        day = int.Parse(reader.ReadLine());
                        hour = int.Parse(reader.ReadLine());
                        minute = int.Parse(reader.ReadLine());
                        second = int.Parse(reader.ReadLine());

                        task.DateAndTime = new DateTime(year, motnth, day, hour, minute, second);

                        tasklist.Add(task);
                    }
                }
                else
                    ok = false;
            }
            catch
            {
                ok = false;
            }

            finally
            {
                if (reader != null)
                    reader.Close();
            }

            return ok;
        }
    }
}
