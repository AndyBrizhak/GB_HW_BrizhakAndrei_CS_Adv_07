using System.Windows;
using System.Data;

namespace Emp_Dep
{
    /// <summary>
    /// Логика взаимодействия для EditDepWindow.xaml
    /// </summary>
    public partial class EditDepWindow : Window
    {
        //public DataRow resultRow { get; set; }
        //public EditWindow(DataRow dataRow)
        //{
        //    InitializeComponent();
        //    resultRow = dataRow;
        //}

        //private void Window_Loaded(object sender, RoutedEventArgs e)
        //{
        //    txt.Text = resultRow["NameDep"].ToString();
        //}
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
