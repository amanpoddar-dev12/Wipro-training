using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Repos.Repos
{
    public interface IDept
    {
        string AddDept(Department dept);
        string EditDept(Department dept);
        List<Department> GetDepartments();
        string RemoveDept(int id);
    }
}
