using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentList
{
    public class StudentGroup
    {
        public int Id;
        public string Name;

        public StudentGroup(int Id, string Name)
        {
            this.Id = Id;
            this.Name = Name;
        }
    }
}
