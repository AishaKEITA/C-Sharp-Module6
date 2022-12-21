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
        private const string fileVersionToken = "ToDoRe_21";
        private const double fileVersionNr = 1.0;


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
    }
}
