using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Repos.Repos
{
    public class Dept : IDept
    {
        private readonly RepoContext _context;
        public Dept(RepoContext context)
        {
            _context = context;
        }
        public string AddDept(Department dept)
        {
            try
            {
                _context.Departments.Add(dept);
                _context.SaveChanges();
                return "Department added succesfully";
            }
            catch(Exception ex){
                return "Department not added because of the error "+ex.Message;
            }
        }

        public string EditDept(Department dept)
        {
            throw new NotImplementedException();
        }

        public List<Department> GetDepartments()
        {
           return  _context.Departments.ToList();

        }

        public string RemoveDept(int id)
        {
            throw new NotImplementedException();
        }
    }
}
