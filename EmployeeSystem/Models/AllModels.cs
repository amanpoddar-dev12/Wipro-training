using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
   public class Department
    {
        public int DepartmentId { get; set; }
        public string Name { get; set; }

    }
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        [ForeignKey("dept")]
        public int DeptId {  get; set; }
        public Department? dept { get; set; }

    }
}
