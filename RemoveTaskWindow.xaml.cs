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
    /// Interaction logic for RemoveTaskWindow.xaml
    /// </summary>
    public partial class RemoveTaskWindow : Window
    {
        ProgramUser currentUser = new ProgramUser();
        public RemoveTaskWindow(int Id, string EmployeeId, int AcessLevel, string title)
        {
            InitializeComponent();
     
            currentUser.id = Id;
            currentUser.EmployeeId = EmployeeId;
            currentUser.AcessLevel = AcessLevel;
            currentUser.title = title;
            InitSelectionGrid( currentUser.EmployeeId, currentUser.AcessLevel);
        }
        private void InitSelectionGrid(string employeeId, int acessLevel) { }

        private void EmployeeSelection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void DelectionSelections_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
