using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentList
{
    public class Student
    {
        public int Id;
        public string Name;
        public StudentGroup Group;

        public Student(int Id, string Name, StudentGroup Group) { 
            this.Id = Id;
            this.Name = Name;
            this.Group = Group;
        }
    }
}
