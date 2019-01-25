using System.Windows;

namespace Emp_Dep
{
    /// <summary>
    /// Логика взаимодействия для EditDepWindow.xaml
    /// </summary>
    public partial class EditDepWindow : Window
    {
        public EditDepWindow(int i, Rep dbEmpDep)
        {
            InitializeComponent();
            btn.Click += delegate
            {
                dbEmpDep.DbDepartments[i - 1].DepName = txt.Text;
                this.DialogResult = true;
            };
        }
    }
}
