using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Repos.Repos;
namespace Services
{
    public class DepartmentService
    {
        private readonly IDept _dept;
        public DepartmentService(IDept dept)
        {
            _dept = dept;

        }
        public string AddDepartment(Department dept)
        {
            string message = _dept.AddDept(dept);
            return message;
        }
        public List<Department> GetDeptList()
        {
            return _dept.GetDepartments();
        }
    }
}
