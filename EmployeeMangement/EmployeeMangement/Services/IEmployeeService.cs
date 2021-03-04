using EmployeeMangement.Models.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeMangement.Services
{
    public interface IEmployeeService
    {
        public List<ViewEmployee> Gets();
        public bool Create(ViewEmployee request);
        public ViewEmployee Get(int id);
        public bool Edit(ViewEmployee request);
       
        public bool Remove(ViewEmployee request);
    }
}
