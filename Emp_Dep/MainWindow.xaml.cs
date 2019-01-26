using System;
using System.Configuration;
using System.Data;
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
        
        public MainWindow()
        {
            InitializeComponent();

            dbEmpDep = new Rep();

            // Connection - Устанавливает подключение к источнику данных
            // Command - Позволяет выполнять операции с данными из БД
            // DataReader - Позволяет хранить и работать с данными независимо от БД
            // DataSet, DataTable - содержит данные, полученные из БД
            
            var connectionString = ConfigurationManager.ConnectionStrings["DefaultStr"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand command = new SqlCommand(
                "SELECT Id, FName, LName, Age, DepID",
                connection);

            adapter.SelectCommand = command;

            DataTable dataEmpTable = new DataTable();

            adapter.Fill(dataEmpTable);

            ListEmp.DataContext = dataEmpTable.DefaultView;






            MainGrid.DataContext = dbEmpDep;
            this.DataContext = dbEmpDep;



           

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
            //command = new SqlCommand("DELETE FROM EmpTable WHERE Id = @ID", connection);

            //SqlParameter parameter = command.Parameters.Add("@ID", SqlDbType.Int, 0, "ID");

            //parameter.SourceVersion = DataRowVersion.Original;

            //adapter.DeleteCommand = command;

            //DataRowView rowView = (DataRowView)ListEmp.SelectedItem;
            //rowView.Row.Delete();
            //adapter.Update(dataEmpTable);

            Employee selEmployee = ListEmp.SelectedItem as Employee;
            dbEmpDep.DelEmp(selEmployee);
            RefreshListEmp();
        }

    }
}

