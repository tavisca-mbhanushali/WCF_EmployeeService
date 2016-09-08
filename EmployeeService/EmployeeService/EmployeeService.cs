using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace EmployeeService
{
   
    public class EmployeeService : IEmployeeService
    {
        static List<Employee> Employeelist;
       public EmployeeService()
        {
            if (Employeelist == null)
            {
                Employeelist = new List<Employee>();
                Employeelist.Add(new Employee { Id = 1, Name = "Mahesh", Gender = "Male", DateOfBirth = DateTime.Now });
                Employeelist.Add(new Employee { Id = 2, Name = "Jaya", Gender = "Female", DateOfBirth = DateTime.Now });
            }
        }

        public Employee GetEmployee(int id)
        {
            return Employeelist.Find(x => x.Id.Equals(id));
        }

        public void SaveEmployee(Employee Employee)
        {
            Employeelist.Add(Employee);
            
        }
    }
}
