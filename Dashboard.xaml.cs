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
        public Dashboard(int Id, string EmployeeId, int AcessLevel, string title )
        {
            InitializeComponent();
            ProgramUser currentUser = new ProgramUser();
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
    }
}
