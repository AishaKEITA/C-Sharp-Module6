﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment6
{
    public partial class MainForm : Form
    {
        //TeamManager constructor
        TaskManager taskManager;

        private string fileName = Application.StartupPath + "\\Task.txt"; //create a file name
        public MainForm()
        {
            InitializeComponent();
            InitializeGui();
        }

        /// <summary>
        /// method to initialize gui when the program starts
        /// </summary>
        private void InitializeGui()
        {
            this.Text = "To do reminder designed by Aisha";

            taskManager = new TaskManager();
            comboBoxPriority.Items.Clear();
            comboBoxPriority.Items.AddRange(Enum.GetNames(typeof(PriorityType)));
            comboBoxPriority.SelectedIndex = (int)PriorityType.Normal;

            lstTask.Items.Clear();

            txtTodo.Text = string.Empty;
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy-MM-dd  HH:mm";

            toolTip1.ShowAlways = true;
            toolTip1.SetToolTip(dateTimePicker1, "Click to open calender, date and time");

            toolTip1.SetToolTip(comboBoxPriority, "Select priority");

            string tips = "To change: Seleclt an item first!" + Environment.NewLine;
            tips += "Make your changes in the input controls" + Environment.NewLine;
            tips += "Click the changes button" + Environment.NewLine;

            toolTip1.SetToolTip(lstTask, tips);
            toolTip1.SetToolTip(btnChange, tips);

            string desTips = "Write here";
            toolTip1.SetToolTip(txtTodo, desTips);

            openDataToolStripMenuItem.Enabled = true;
            saveDataFileToolStripMenuItem.Enabled = true;

             btnChange.Enabled = false;
             btnDelete.Enabled = false;
        }
        /// <summary>
        /// show text when form loads
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "To do reminder designed by Aisha";
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        /// <summary>
        /// method to add task
        /// enable delete and delete button when add is clicked
        /// then update gui
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            Task task = ReadInput();
            if (taskManager.AddNewTask(task))
            {
                UpdateGui();
            }

            btnChange.Enabled = true;
            btnDelete.Enabled = true;
        }

        /// <summary>
        /// method to read user input
        /// </summary>
        /// <returns></returns>
        private Task ReadInput()
        {
            Task task = new Task();

            if (string.IsNullOrEmpty(txtTodo.Text))
            {
                MessageBox.Show("No subject? Write something please");
                return null;
            }

            task.Description = txtTodo.Text;
            task.DateAndTime = dateTimePicker1.Value;
            task.Priority = (PriorityType)comboBoxPriority.SelectedIndex;

            return task;
        }

        /// <summary>
        /// method to update gui
        /// </summary>
        private void UpdateGui()
        {
            lstTask.Items.Clear();
            string[] infoStrings = taskManager.GetInfoStringsList();
            if (infoStrings != null)
                lstTask.Items.AddRange(infoStrings);
        }

        /// <summary>
        /// method to exit when the user clicks exits
        /// a prompt will show to confirm if the user wants to exit or not
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitAltF4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dlgResult = MessageBox.Show("Are you sure you want to exit?",
                "Thik twice", MessageBoxButtons.OKCancel);
            if (dlgResult == DialogResult.OK)
                Application.Exit();
        }

        /// <summary>
        /// method to open data file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openDataToolStripMenuItem_Click(object sender, EventArgs e)
        {

            bool ok = taskManager.ReadDataFromFile(fileName);
            if (!ok)
            {
                string errMessage = "Something went wrong openig the file";
                MessageBox.Show(errMessage);
            }
            else
                UpdateGui();
        }

        /// <summary>
        /// method for the user to save data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveDataFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string errMessage = "something went wrong while saving data to file";
            bool ok = taskManager.WriteDataToFile(fileName);
            if (!ok)
                MessageBox.Show(errMessage);
            else
                MessageBox.Show("Data saved to file:" + Environment.NewLine + fileName);
        }

        /// <summary>
        /// intialize gui when open is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            InitializeGui();
        }

        /// <summary>
        /// method to change user input
        /// by clicking the change button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChange_Click(object sender, EventArgs e)
        {
            int index = lstTask.SelectedIndex;
            if (index >= 0)
            {
                Task task = ReadInput();
                bool ok = taskManager.ChangeTaskAt(task, index);

                if (ok)
                    UpdateGui();
            }
            else
                MessageBox.Show("Select an element to change");
        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
        }

        private void lblDateTimm_Click(object sender, EventArgs e)
        {
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// method to select list box items
        /// to delete the position of user task
        /// </summary>
        /// <returns></returns>
        private int lstBoxItemSelected()
        {
            int index = lstTask.SelectedIndex;
            if (lstTask.SelectedIndex < 0)
            {
                MessageBox.Show("Please select an item from the list");
                return -1;
            }
            else
                return index;

        }
        /// <summary>
        /// delete unwanted task and ask user to confirm delete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            int index = lstBoxItemSelected();
            string MessageBoxTitle = "";
            string MessageBoxContent = "Are you sure you want to delete this task?";
            DialogResult dialogResult = MessageBox.Show(MessageBoxContent, MessageBoxTitle, MessageBoxButtons.YesNo);


            if (index < 0)
            {
                return;
            }
            if (dialogResult == DialogResult.Yes)
            {
                taskManager.DeleteTaskAt(index);

                UpdateGui();
            }
            else if (dialogResult == DialogResult.No)
            {
                return;
            }
        }

        private void lstTask_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// display timer clock in the application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            lblClock.Text = DateTime.Now.ToLongTimeString();

        }

        private void groupBoxTodo_Enter(object sender, EventArgs e)
        {

        }
    }
}
