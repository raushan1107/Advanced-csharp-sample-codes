using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfApp_DataBindingLearning.Core;
using WpfApp_DataBindingLearning.Models;

namespace WpfApp_DataBindingLearning.ViewModels
{
    public class MainViewModel
    {
        public ObservableCollection<Person> People { get; set; }
        public Person SelectedPerson { get; set; }

        public ICommand AddPersonCommand { get; }

        public MainViewModel()
        {
            People = new ObservableCollection<Person>()
            {
                new Person { Name = "Ritu", Age = 25, Email = "ritu@example.com" },
                new Person { Name = "Raushan", Age = 29, Email = "raushan@example.com" }
            };

            SelectedPerson = People[0];

            AddPersonCommand = new RelayCommand(o => AddPerson());
        }

        private void AddPerson()
        {
            People.Add(new Person
            {
                Name = "New User",
                Age = 18,
                Email = "new@example.com"
            });
        }
    }
}
