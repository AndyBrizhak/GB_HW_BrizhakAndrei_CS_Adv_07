using System.Collections.ObjectModel;
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
    /// Содержит две коллекции Департаменты и Работники
    /// </summary>
    public class Rep                                                             
    {
        

        /// <summary>
        /// Коллекция Работники
        /// </summary>
        public ObservableCollection<Employee> DbEmployees { get; set; }

        /// <summary>
        /// Коллекция Департаменты
        /// </summary>
        public ObservableCollection<Department> DbDepartments { get; set; }

        public Rep()
        {
            DbEmployees = new ObservableCollection<Employee>();
            DbDepartments = new ObservableCollection<Department>();

            DbDepartments.Add(new Department("Приемная",1));
            DbDepartments.Add(new Department("Прачечная", 2));
            DbDepartments.Add(new Department("Морг", 3));

            DbEmployees.Add(new Employee("Василий", "Афанасьев", 25.ToString(), 1));
            DbEmployees.Add(new Employee("Федор", "Ивлев", 25.ToString(), 1));
            DbEmployees.Add(new Employee("Тамара", "Иванова", 32.ToString(), 2));
            DbEmployees.Add(new Employee("Валентина", "Кошелева", 32.ToString(), 2));
            DbEmployees.Add(new Employee("Василий", "Пупкин", 48.ToString(), 3));
            DbEmployees.Add(new Employee("Иван", "Ложкин", 48.ToString(), 3));

            

        }




        /// <summary>
        /// Добавляет Департамент 
        /// </summary>
        /// <param name="NameDep">Имя нового департамента</param>
        public void AddDep(string nameDep)
        {
            DbDepartments.Add(new Department(nameDep, DbDepartments.Count + 1));

        }

        /// <summary>
        /// Удаление департамента и всех его сотрудников
        /// </summary>
        /// <param name="id">Идентификатор департамента</param>
        public void DelDep(int id)
        {
            for (int i = DbEmployees.Count - 1; i >= 0; i--)
            {
                if (DbEmployees[i].DepID == id)
                {
                    DbEmployees.RemoveAt(i);
                }
            }

            for (int i = DbDepartments.Count - 1; i >= 0; i--)
            {
                if (DbDepartments[i].DepId == id) DbDepartments.RemoveAt(i);
            }
        }

        /// <summary>
        /// Добавление работника в коллекцию
        /// </summary>
        /// <param name="fName"></param>
        /// <param name="lName"></param>
        /// <param name="age"></param>
        /// <param name="strAge"></param>
        /// <param name="depId"></param>
        public void AddEmp(string fName, string lName, string strAge, int depId)
        {
            DbEmployees.Add(new Employee(fName, lName, strAge, depId));

        }


        /// <summary>
        /// Удаляет работника из коллекции
        /// </summary>
        /// <param name="selEmployee"></param>
        public void DelEmp(Employee selEmployee)
        {
            if (DbEmployees.Count == 0) return;
            if (!DbEmployees.Contains(selEmployee)) return;
            DbEmployees.Remove(selEmployee);
        }
    }
}