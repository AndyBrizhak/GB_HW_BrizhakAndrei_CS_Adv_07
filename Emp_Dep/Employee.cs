using System.ComponentModel;


namespace Emp_Dep
{
    public class Employee : INotifyPropertyChanged
    {
        public string _fName;
        private string _lName;
        private string _age;
        private int _depID;

        public event PropertyChangedEventHandler PropertyChanged;

        public string FName
        {
            get => _fName;
            set
            {
                _fName = value;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.FName)));
            }
        }

        public string LName { get => _lName; set => _lName = value; }
        public string Age { get => _age; set => _age = value; }
        public int DepID { get => _depID; set => _depID = value; }

        public Employee(string _fName, string _lName, string _age, int _depID)
        {
            FName = _fName;
            LName = _lName;
            Age = _age;
            DepID = _depID;
        }

        public override string ToString()
        {


            return $"{FName}\t{LName}";
        }
    }

}
