using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Assignment_GUI.Model
{
    public class Student
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Semester { get; set; }
        public string DateOfBirth { get; set; }
        public string Department { get; set; }
        public Double GPA { get; set; }
        public BitmapImage Image { get; set; }

        public String ImagePath
        {
            get { return $"/Model/Images/{Image}"; }
        }

        public Student(string firstName, string lastName, int semester, string dateOfBirth, string department, double gpa, BitmapImage image)
        {

            FirstName = firstName;
            LastName = lastName;
            Semester = semester;
            DateOfBirth = dateOfBirth;
            Department = department;
            GPA = gpa;
            Image = image;
        }

        public Student()
        {
        }
    }
}