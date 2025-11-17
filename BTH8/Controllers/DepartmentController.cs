using BTH8.Models;
using System.Linq;
using System.Web.Mvc;

public class DepartmentController : Controller
{
    QL_NhanSuEntities db = new QL_NhanSuEntities();

    public ActionResult Index()
    {
        var departments = db.tbl_Deparment.ToList();
        return View(departments);
    }

    public ActionResult ShowEmployeesByDept(int ? id) 
    {
        var employees = db.tbl_Employee.Where(e => e.Deptid == id).ToList();

        ViewBag.DeptName = db.tbl_Deparment.Find(id).Name;

        return View(employees);
    }
}