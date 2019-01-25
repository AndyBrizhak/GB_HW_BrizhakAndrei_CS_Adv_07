using System.Linq;
using System.Windows;

namespace Emp_Dep
{
    /// <summary>
    /// Логика взаимодействия для EditEmpWindow.xaml
    /// </summary>
    public partial class EditEmpWindow : Window
    {
        public EditEmpWindow(int i, Rep dbEmpDep)
        {
            InitializeComponent();
            btn.Click += delegate
            {
                var selEmp = dbEmpDep.DbEmployees.Single(e => e.GetHashCode() == i);
                selEmp.FName = txt.Text;
                //dbEmpDep.DbEmployees[i].FName = txt.Text;
                this.DialogResult = true;
            };

        }
    }
}