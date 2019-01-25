using System.Windows;

namespace Emp_Dep
{
    /// <summary>
    /// Логика взаимодействия для AddDepWindow.xaml
    /// </summary>
    public partial class AddDepWindow : Window
    {
        public AddDepWindow(Rep dbEmpDep)
        {
            InitializeComponent();
            btn.Click += delegate
            {
                dbEmpDep.AddDep(txt.Text);
                this.DialogResult = true;
            };

        }
    }
}