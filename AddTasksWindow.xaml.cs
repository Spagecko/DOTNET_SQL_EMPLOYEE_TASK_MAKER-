using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace EmployeeTaskManger
{
    /// <summary>
    /// Interaction logic for AddTasksWindow.xaml
    /// </summary>
    public partial class AddTasksWindow : Window
    {
        ProgramUser currentUser = new ProgramUser();
        public AddTasksWindow(int Id, string EmployeeId, int AcessLevel, string title )
        {
            currentUser.id = Id;
            currentUser.EmployeeId = EmployeeId;
            currentUser.AcessLevel = AcessLevel;
            currentUser.title = title;
            InitializeComponent();
            FillComboBox(currentUser.EmployeeId, currentUser.AcessLevel); 
        }
        private void FillComboBox (string employeeId, int acessLevel)
        {

            string cmdString = ""; 
            if(acessLevel == 1) // if CEO is signed in 
            {
                cmdString = "Select EmployeeId FROM Employees"; 
            }
            else if (acessLevel == 2) // if manager is signed in 
            {
                cmdString = "Select EmployeeId FROM Employees WHERE AcessLevel > 2"; 
            }
            else  // everoyone else
            {
                cmdString = "Select EmployeeId From Employees WHERE AcessLevel > 2 AND EmployeeId =" + " " +"'"+ employeeId + "'"; 

            }

            string conString = Properties.Resources.DB_CONNECTION;
    

            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(cmdString, con);
                SqlDataReader results = cmd.ExecuteReader();
                while(results.Read())
                {
                    CoboSelectionBox.Items.Add(results["EmployeeId"].ToString()); 
                }
                results.Close();
                con.Close();
                



            }
        }

        private void AddTaskBtn_Click(object sender, RoutedEventArgs e)
        {
            //form validation
         
            if(CoboSelectionBox.SelectedIndex == -1) // if combobox is not selected
            {
                MessageBox.Show("You need to select the employee");
            }
            else if (TaskNameInput.Text =="") // if task name is not inputed
            {
                MessageBox.Show("You need to write a Task Nane");
            }
            else // add to DB 
            {
                string cmdString = "INSERT INTO Tasks (TaskHolder, TaskTitle, TaskDesc, DateStartedOn, EstimateToComplition)" +
                    "  VALUES (@EmployeeId, @TaskTitle, @TaskDesc, @DateStartedOn, @EstimateToComplition)";

                string timeStampForStart = DateTime.Now.ToString();
                string conString = Properties.Resources.DB_CONNECTION;
                
                using(SqlConnection con = new SqlConnection(conString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(cmdString, con);
                    cmd.Parameters.AddWithValue("@EmployeeId", CoboSelectionBox.SelectedItem);
                    cmd.Parameters.AddWithValue("@TaskTitle",  TaskNameInput.Text);
                    cmd.Parameters.AddWithValue("@TaskDesc", TaskDescInput.Text );
                    cmd.Parameters.AddWithValue("@DateStartedOn", timeStampForStart);
                    cmd.Parameters.AddWithValue("@EstimateToComplition", TaskETAInput.Text);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }




            }

   

        }
    }
}
