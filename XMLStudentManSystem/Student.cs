using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLStudentManSystem
{
     public  class Student
    {
        private string name;
        private int age;
        private int sex;
        private int id;

        public string Name { get => name; set => name = value; }
        public int Age { get => age; set => age = value; }
        public int Sex { get => sex; set => sex = value; }
        public int Id { get => id; set => id = value; }
        public Student(string name, int age, int sex, int id)
        {
            this.name = name;
            this.age = age;
            this.sex = sex;
            this.id = id;
        }
        public Student() { }
    }
}
