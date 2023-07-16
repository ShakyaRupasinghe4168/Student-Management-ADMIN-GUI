using Assignment_GUI.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Assignment_GUI.ViewModels
{
    public partial class MainWindowVM : ObservableObject
    {
        [ObservableProperty]
        public ObservableCollection<Student> students;
        [ObservableProperty]
        public Student selectedStudent = null;

        public void CloseMainWindow()
        {
            Application.Current.MainWindow.Close();
        }

        [RelayCommand]
        public void AddStudent()
        {
            var vm = new AddStudentVM();
            vm.title = "ADD USER";
            AddStudent window = new AddStudent(vm);
            window.ShowDialog();

            if (vm.Student.FirstName != null)
            {
                students.Add(vm.Student);
            }
        }

        [RelayCommand]
        public void Delete()
        {
            if (selectedStudent != null)
            {
                string name = selectedStudent.FirstName;
                Students.Remove(selectedStudent);
                MessageBox.Show($"{name} is Deleted successfuly.");

            }
            else
            {
                MessageBox.Show(" Select Student before Delete.");


            }
        }
        [RelayCommand]
        public void Modify()
        {


            if (selectedStudent != null)
            {
                var vm = new AddStudentVM(selectedStudent);
                vm.title = "EDIT USER";
                var window = new AddStudent(vm);

                window.ShowDialog();


                int index = students.IndexOf(selectedStudent);
                students.RemoveAt(index);
                students.Insert(index, vm.Student);


            }
            else
            {
                MessageBox.Show(" Select the student");
            }
        }

        public MainWindowVM()
        {
            Students = new ObservableCollection<Student>();

            BitmapImage image1 = new BitmapImage(new Uri("/Model/Images/im1.jpg", UriKind.Relative));
            Students.Add(new Student("Joana", "Patric", 4, "22/10/1999", "Mechanical", 3.4, image1));

            BitmapImage image2 = new BitmapImage(new Uri("/Model/Images/im2.jpg", UriKind.Relative));
            Students.Add(new Student("Mery", "Brown", 5, "12/08/1998", "Computer", 3.0, image2));

            BitmapImage image3 = new BitmapImage(new Uri("/Model/Images/im3.jpg", UriKind.Relative));
            Students.Add(new Student("William", "Fedric", 1, "25/1/2000", "Electrical", 3.7, image3));

            BitmapImage image4 = new BitmapImage(new Uri("/Model/Images/im4.jpeg", UriKind.Relative));
            Students.Add(new Student("Henry", "Potter", 2, "12/11/2001", "Mechanical", 2.7, image4));


            BitmapImage image5 = new BitmapImage(new Uri("/Model/Images/im5.jpg", UriKind.Relative));
            Students.Add(new Student("Lily", "Cedric", 2, "18/06/2000", "Civil", 3.1, image5));
        }
    }
}