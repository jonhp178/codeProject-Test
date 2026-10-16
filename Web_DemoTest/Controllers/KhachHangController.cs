using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_DemoTest.Models;
using BCrypt;
using System.Data.Entity.Migrations;

namespace Web_DemoTest.Controllers
{
    public class KhachHangController : Controller
    {
        // GET: KhachHang
        CoffeeOrderDBEntities db = new CoffeeOrderDBEntities();
        public ActionResult Index()
        {
            return View(db.Customers.ToList());
        }

        [HttpGet]
        public ActionResult CreateAcc()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateAcc(Customer customer, string PasswordHash)
        {
            try
            {
                customer.PasswordHash = BCrypt.Net.BCrypt.HashPassword(PasswordHash, workFactor: 11);
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                // 🔍 In ra lỗi chi tiết từ hệ thống/database thay vì ẩn đi
                // Nếu lỗi do thực thể bên trong Entity Framework (InnerException), lấy thông tin từ đó sẽ rõ nhất:
                //string errorMsg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;

                ModelState.AddModelError("", "Lỗi tạo mới acc: " );
            }
            return View(customer);
        }
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            var customer = db.Customers.Find(id);
            return View(customer);
        }
        [HttpPost]
        public ActionResult Edit(Customer customer)
        {
            db.Customers.AddOrUpdate(customer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}