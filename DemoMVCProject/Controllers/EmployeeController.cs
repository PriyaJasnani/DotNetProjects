using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DemoMVCProject.Data;
using DemoMVCProject.Models;
using System.Data.SqlClient;
using System.Data;
using Microsoft.Data.SqlClient;

namespace DemoMVCProject.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IConfiguration _configuration;

        public EmployeeController(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        // GET: Employee
        public IActionResult Index()
        {
            DataTable dt = new DataTable();

            using (SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("DevConnection")))
            {
                sqlConnection.Open();
                SqlDataAdapter da = new SqlDataAdapter("EmployeeViewAll", sqlConnection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.Fill(dt);
            }
            return View(dt);
        }


        // GET: Employee/AddorEdit/
        public IActionResult AddorEdit(int? id)
        {
            EmployeeViewModel employeeViewModel = new EmployeeViewModel();
            if (id > 0)
                employeeViewModel = FetchBookByID(id);
            return View(employeeViewModel);
        }

        // POST: Employee/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddorEdit(int id, [Bind("empid,empname,designation,grossal,deducts,netsal,isactive")] EmployeeViewModel employeeViewModel)
        {

            if (ModelState.IsValid)
            {
                using (SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("DevConnection")))
                {
                    sqlConnection.Open();
                    SqlCommand cmd = new SqlCommand("EmpAddorEdit", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("empid", employeeViewModel.empid);
                    cmd.Parameters.AddWithValue("empname", employeeViewModel.empname);
                    cmd.Parameters.AddWithValue("designation", employeeViewModel.designation);
                    cmd.Parameters.AddWithValue("grossal", employeeViewModel.grossal);
                    cmd.Parameters.AddWithValue("deducts", employeeViewModel.deducts);
                    cmd.Parameters.AddWithValue("netsal", employeeViewModel.netsal);
                    cmd.Parameters.AddWithValue("isactive", employeeViewModel.isactive);

                    cmd.ExecuteNonQuery();

                }

                return RedirectToAction(nameof(Index));
            }
            return View(employeeViewModel);
        }

        // GET: Employee/Delete/5
        public IActionResult Delete(int? id)
        {
            EmployeeViewModel employeeViewModel = FetchBookByID(id);
            return View(employeeViewModel);
        }

        // POST: Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("DevConnection")))
            {
                sqlConnection.Open();
                SqlCommand sqlCmd = new SqlCommand("EmployeeDeleteByID", sqlConnection);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("empid", id);
                sqlCmd.ExecuteNonQuery();
            }

            return RedirectToAction(nameof(Index));
        }
        [NonAction]
        public EmployeeViewModel FetchBookByID(int? id)
        {
            EmployeeViewModel employeeViewModel = new EmployeeViewModel();
            using (SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("DevConnection")))
            {
                DataTable dtbl = new DataTable();
                sqlConnection.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("EmployeeViewByID", sqlConnection);
                sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlDa.SelectCommand.Parameters.AddWithValue("empid", id);
                sqlDa.Fill(dtbl);
                if (dtbl.Rows.Count == 1)
                {
                    employeeViewModel.empid = Convert.ToInt32(dtbl.Rows[0]["empid"].ToString());
                    employeeViewModel.empname = dtbl.Rows[0]["empname"].ToString();
                    employeeViewModel.designation = dtbl.Rows[0]["designation"].ToString();
                    employeeViewModel.grossal = Convert.ToInt32(dtbl.Rows[0]["grossal"].ToString());
                    employeeViewModel.deducts = Convert.ToInt32(dtbl.Rows[0]["deducts"].ToString());
                    employeeViewModel.netsal = Convert.ToInt32(dtbl.Rows[0]["netsal"].ToString());
                    employeeViewModel.isactive = dtbl.Rows[0]["isactive"].ToString();

                }
                return employeeViewModel;
            }

        }
    }
}
