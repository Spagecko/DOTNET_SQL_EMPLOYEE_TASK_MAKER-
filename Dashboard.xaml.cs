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
namespace EmployeeTaskManger
{
    /// <summary>
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class Dashboard : Window
    {
        ProgramUser currentUser = new ProgramUser();
        public Dashboard(int Id, string EmployeeId, int AcessLevel, string title )
        {
            InitializeComponent();
           
            currentUser.id = Id;
            currentUser.EmployeeId = EmployeeId;
            currentUser.AcessLevel = AcessLevel;
            currentUser.title = title;
           
            FillDataGridOnInit(); 

        }

        private void FillDataGridOnInit()
        {
            string conString = Properties.Resources.DB_CONNECTION;
            
            using (SqlConnection con = new SqlConnection (conString))
            {
                con.Open();
                string cmdString = "SELECT * FROM Tasks";
                SqlCommand cmd = new SqlCommand(cmdString, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("Tasks");
                sda.Fill(dt);
                DataDisply.ItemsSource = dt.DefaultView;
                con.Close(); 



            }


        }

        private void AddTaskBtn_Click(object sender, RoutedEventArgs e)
        {
            AddTasksWindow addTasksWindow = new AddTasksWindow(currentUser.id, currentUser.EmployeeId, currentUser.AcessLevel, currentUser.title);
            addTasksWindow.Show(); 
            
        }

        private void RemoveTaskBtn_Click(object sender, RoutedEventArgs e)
        {
           RemoveTaskWindow removeTaskWindow = new RemoveTaskWindow(currentUser.id, currentUser.EmployeeId, currentUser.AcessLevel, currentUser.title);
            removeTaskWindow.Show();
        }

        private void CompleteTaskBtn_Click(object sender, RoutedEventArgs e)
        {   
            CompleteTaskWindow completeTaskWindow = new CompleteTaskWindow(currentUser.id, currentUser.EmployeeId, currentUser.AcessLevel, currentUser.title);
            completeTaskWindow.Show(); 
        }

        private void ShowAllTaskBtn_Click(object sender, RoutedEventArgs e)
        {
            string conString = Properties.Resources.DB_CONNECTION;

            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();
                string cmdString = "SELECT * FROM Tasks";
                SqlCommand cmd = new SqlCommand(cmdString, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("Tasks");
                sda.Fill(dt);
                DataDisply.ItemsSource = dt.DefaultView;
                con.Close();



            }
        }

        private void ShowPersonTasksbtn_Click(object sender, RoutedEventArgs e)
        {
            string conString = Properties.Resources.DB_CONNECTION;

            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();
                string cmdString = "SELECT Employees.EmployeeId AS 'Empolyees' ," +
                    " COUNT(Tasks.TaskTitle) as 'Number of Tasks' " +
                    "FROM Employees  " +
                    "LEFT JOIN Tasks ON  Employees.EmployeeId = Tasks.TaskHolder  " +
                    "GROUP BY Employees.EmployeeId ;";
                SqlCommand cmd = new SqlCommand(cmdString, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("Tasks");
                sda.Fill(dt);
                DataDisply.ItemsSource = dt.DefaultView;
                con.Close();



            }
        }

        private void ShowWorkerTaskBtn_Click(object sender, RoutedEventArgs e)
        {
            string conString = Properties.Resources.DB_CONNECTION;

            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();
                string cmdString = "SELECT Employees.Title AS Employee_Type, COUNT (Tasks.TaskTitle) AS Number_Of_Tasks " +
                    "FROM Employees " +
                    "LEFT JOIN  Tasks ON Employees.EmployeeId = Tasks.TaskHolder " +
                    "GROUP BY Employees.Title;";
                SqlCommand cmd = new SqlCommand(cmdString, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("Tasks");
                sda.Fill(dt);
                DataDisply.ItemsSource = dt.DefaultView;
                con.Close();



            }

        }

        /* SELECT Employees.Title AS Employee_Type, COUNT (Tasks.TaskTitle) AS Number_Of_Tasks 
FROM Employees
LEFT JOIN  Tasks ON Employees.EmployeeId = Tasks.TaskHolder
GROUP BY Employees.Title; */

        private void Logout_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
