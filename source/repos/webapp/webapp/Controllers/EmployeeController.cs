using Microsoft.AspNetCore.Mvc;
using webapp.Models;
using webapp.Config;
using System.Data;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace webapp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        List<Employee> employees = new List<Employee>();
        DbConfig db = new DbConfig();
        DataTable dtemp;
        public EmployeeController()
        {
    
            /*
           dtemp = db.GetDataTable("select * from employees");
            foreach(DataRow dr in dtemp)
            {
                employees.Add(new Employee() {EmpId = int.Parse(dr["id"].ToString()), EmpFirstName = dr["firstname"].ToString(), dr["lastname"].ToString() })
            }
  
            */


            employees.Add(new Employee() { EmpId = 1, EmpFirstname = "Leonard", EmpLastName = "Estrada" });
            employees.Add(new Employee() { EmpId = 2, EmpFirstname = "Leonard", EmpLastName = "Estrada2" });

        }
        // GET: api/<EmployeeController>
        [HttpGet]
        public List<Employee> Get()
        {
            return employees;
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public Employee Get(int id)
        {
            //dtemp = db.GetDataTable("select * from employees where id='" + id + "'"); 
            //DataRow dr = dtemp.Rows[0];
            //Employee employee = new Employee() {EmpId = int.Parse(dr["id"].ToString()), EmpFirstName = dr["firstname"].ToString(), dr["lastname"].ToString() };
            Employee employee = employees.Find(e => e.EmpId == id);
           
            return employee;
            
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public List<Employee> Post([FromBody] Employee employee)
        {
            //string insert_query;
            //string[] fields = new string[] {"lastname", "firstname"} ;
            //object[] values = new object[] {employee.EmpLastName, employee.EmpFirstname};
            //insert_query = db.insert_query("employees", fields, values);
            //db.executequery(insert_query);

            // sring insertquer
            
            employees.Add(employee);
            
            return employees;
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public List<Employee> Put(int id, [FromBody] Employee employee)
        {
            //string update_query;
            //string[] fields = new string[] {"lastname", "firstname"} ;
            //object[] values = new object[] {employee.EmpLastName, employee.EmpFirstname};

            //update_query = db.update_query("employees", fields, values, id);
            //db.executequery(update_query);
            

            Employee selectedemployee = employees.Find(e => e.EmpId == id);
            int index = employees.IndexOf(selectedemployee);

            employees[index].EmpLastName = employee.EmpLastName;
            employees[index].EmpFirstname = employee.EmpFirstname;

            return employees;

        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public List<Employee> Delete(int id)
        {
            //string delete_query;
            //delete_query = db.delete_query("employees", id);
            //db.executequery(delete_query);

            Employee employee = employees.Find(e => e.EmpId == id);
            employees.Remove(employee);
            return employees;
        }
    }
}
