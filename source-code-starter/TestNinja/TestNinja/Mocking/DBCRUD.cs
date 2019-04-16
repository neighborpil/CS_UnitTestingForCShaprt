using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNinja.Mocking
{
    public interface IDBCRUD
    {
        void DeleteEmployee(int id);
    }

    public class DBCRUD : IDBCRUD
    {
        private EmployeeContext _db;

        public DBCRUD()
        {
            _db = new EmployeeContext();
        }

        public void DeleteEmployee(int id)
        {
            var employee = _db.Employees.Find(id);
            _db.Employees.Remove(employee);
            _db.SaveChanges();
        }
    }
}
