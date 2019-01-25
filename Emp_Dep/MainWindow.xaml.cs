using System;
using System.Data.SqlClient;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;


namespace Emp_Dep
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Rep dbEmpDep;
        /// <summary>
        /// 
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            //создание переменной описывающей подключение к базе даных
            var connectionString = @"Data source=(LocalDb)\MSSQLLocalDB;
                                    Initial Catalog=Emp_Dep;
                                    Integrated security = True;";   /*False */

            //создание экземпляра класса подключения к базе с параметрами connectionString
            //пример открытия и закрытия подключения к базе данных
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                Console.WriteLine(connection.State);
               
                //connection.Close();
            }

            

            
            

            dbEmpDep = new Rep();
            MainGrid.DataContext = dbEmpDep;
            this.DataContext = dbEmpDep;

            dbEmpDep.AddDep("Приемная");
            dbEmpDep.AddDep("Прачечная");
            dbEmpDep.AddDep("Морг");
            dbEmpDep.AddEmp("Василий", "Афанасьев", 25.ToString(), 1);
            dbEmpDep.AddEmp("Федор", "Ивлев", 25.ToString(), 1);
            dbEmpDep.AddEmp("Тамара", "Иванова", 32.ToString(), 2);
            dbEmpDep.AddEmp("Валентина", "Кошелева", 32.ToString(), 2);
            dbEmpDep.AddEmp("Василий", "Пупкин", 48.ToString(), 3);
            dbEmpDep.AddEmp("Иван", "Ложкин", 48.ToString(), 3);

            //DepCombobox.ItemsSource = dbEmpDep.DbDepartments;

            DepEditBtn.Click += delegate
            {
                new EditDepWindow((DepCombobox.SelectedItem as Department).DepId, dbEmpDep).ShowDialog();
            };

            ListEmp.MouseDoubleClick += ListEmp_MouseDoubleClick;
        }

        private void ListEmp_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            new EditEmpWindow((ListEmp.SelectedItem as Employee).GetHashCode(), dbEmpDep).ShowDialog();
        }

        private void DepCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //ListEmp.Items.Refresh();
            RefreshListEmp();
        }

        /// <summary>
        /// Обновление списка сотрудников в департаменте
        /// </summary>
        private void RefreshListEmp()
        {
            ListEmp.ItemsSource = dbEmpDep.DbEmployees.Where(w => w.DepID == (DepCombobox.SelectedValue as Department)?.DepId);
        }

        private void ButtonDelDep_Click(object sender, RoutedEventArgs e)
        {
            dbEmpDep.DelDep((DepCombobox.SelectedValue as Department).DepId);
            RefreshListEmp();
        }

        private void ButtonAddDep_Click(object sender, RoutedEventArgs e)
        {

            new AddDepWindow(dbEmpDep).ShowDialog();
            RefreshListEmp();
        }

        private void ButtonAddEmp_Click(object sender, RoutedEventArgs e)
        {

            new AddEmpWindow(dbEmpDep, (DepCombobox.SelectedItem as Department).DepId).ShowDialog();
            RefreshListEmp();
        }

        private void ButtonDelEmp_Click(object sender, RoutedEventArgs e)
        {

            Employee selEmployee = ListEmp.SelectedItem as Employee;
            //int empHashCode = (ListEmp.SelectedItem as Employee).GetHashCode();
            //var selEmp = dbEmpDep.DbEmployees.Single(el => el.GetHashCode() == empHashCode);

            dbEmpDep.DelEmp(selEmployee);
            RefreshListEmp();
        }

    }
}

