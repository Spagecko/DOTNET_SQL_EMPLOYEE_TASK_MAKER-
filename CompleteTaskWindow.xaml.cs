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

namespace EmployeeTaskManger
{
    /// <summary>
    /// Interaction logic for CompleteTaskWindow.xaml
    /// </summary>
    public partial class CompleteTaskWindow : Window
    {
        ProgramUser currentUser = new ProgramUser();
        public CompleteTaskWindow(int Id, string EmployeeId, int AcessLevel, string title)
        {
            InitializeComponent();
            currentUser.id = Id;
            currentUser.EmployeeId = EmployeeId;
            currentUser.AcessLevel = AcessLevel;
            currentUser.title = title;
        }


    }
}
