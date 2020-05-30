using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace EmployeeTaskManger
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ProgramUser currUser = new ProgramUser();
        }

        private void Username_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            string ConString = Properties.Resources.DB_CONNECTION;

            using (SqlConnection con = new SqlConnection(ConString))
            {
                con.Open();
                string CmdString = "SELECT COUNT(1)  FROM UserAccounts WHERE UserName = @Username AND password = @Password";
                SqlCommand cmd = new SqlCommand(CmdString, con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Username", Username.Text);
                cmd.Parameters.AddWithValue("@Password", Password.Password);
                int count = Convert.ToInt32(cmd.ExecuteScalar()); 
                if(count == 1 )
                {
                    string newCmdString = "SELECT * FROM Employees WHERE  EmployeeID = @Username";
                    SqlCommand newCmd = new SqlCommand(newCmdString, con);
                    newCmd.CommandType = CommandType.Text;
                    newCmd.Parameters.AddWithValue("@Username", Username.Text);
                    SqlDataReader results = newCmd.ExecuteReader();
                    ProgramUser currUser = new ProgramUser();
                    while (results.Read()) // storing user info to new class to be pass to next window
                    {
                        currUser.id = Int32.Parse(results["id"].ToString());
                        currUser.EmployeeId = results["EmployeeId"].ToString();
                        currUser.AcessLevel = Int32.Parse(results["AcessLevel"].ToString());
                        currUser.title = results["Title"].ToString();

                    }
                    this.DataContext = currUser;
                    Dashboard newWindow = new Dashboard(currUser.id, currUser.EmployeeId, currUser.AcessLevel, currUser.title);
                    newWindow.DataContext = this.DataContext;
                    this.Close();
                    newWindow.Show(); 
                    
                }
                else
                {
                    MessageBoxResult result = MessageBox.Show("Username and password combination did not work");
                }
                con.Close();


            }


        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
       
        }
    }
}
