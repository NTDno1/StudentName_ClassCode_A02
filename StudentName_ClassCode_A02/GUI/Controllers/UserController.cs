using BUS.DTO;
using BUS.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Xml.Linq;
using System.Net.Http.Json;
namespace GUI.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> GetUser(string email, string pass)
        {
            string link = "https://localhost:7280/api/Customers";
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.GetAsync(link + "/" + email + "/" + pass))
                {
                    if (res.IsSuccessStatusCode)
                    {
                        string jsonResult = await res.Content.ReadAsStringAsync();
                        var resoult = JsonConvert.DeserializeObject<Customer>(jsonResult);
                        int roleId = resoult.CustomerID;    
                        string name = resoult.CustomerName;
                        HttpContext.Session.SetString("Name", name);
                        HttpContext.Session.SetInt32("Role", roleId);
                        //return RedirectToRoute(new { action = "Author", id = roleId, name = name });
                        return Redirect($"/Home");
                    }
                    else
                    {
                        ViewData["Error"] = "Đăng nhập không thành công. Vui lòng kiểm tra lại thông tin đăng nhập.";
                        return View("Index");
                    }
                }
            }
        }
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignUp(string email, string pass, string repass)
        {
            if (!pass.Equals(repass))
            {
                ViewData["Error"] = "Vui Lòng Kiểm Tra Lại Thông Tin Đăng Nhập";
                return View("SignUp");
            }
            string link = "https://localhost:7280/api/Customers";
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage resget = await client.GetAsync(link))
                {
                    string jsonResult = await resget.Content.ReadAsStringAsync();
                    List<Customer> resoult = JsonConvert.DeserializeObject<List<Customer>>(jsonResult);
                    Customer checkCust = resoult.FirstOrDefault(u=>u.Email == email);
                    if (checkCust!= null)
                    {
                        ViewData["Error"] = "Email Đã Tồn Tại";
                        return View("SignUp");
                    }
                    else
                    {
                        using (HttpResponseMessage res = await client.PostAsJsonAsync(link + "?email=" + email + "&pass=" + pass, checkCust))
                        {
                            if (res.IsSuccessStatusCode)
                            {
                                ViewData["SignUp"] = "Đăng Ký Tài Khoản Thành Công";
                                return View("Index");
                            }
                            else
                            {
                                ViewData["Error"] = "Vui Lòng Kiểm Tra Lại Thông Tin Đăng Nhập";
                                return Redirect($"/User/Login");
                            }
                        }
                    }
                }
            }
        }
        public async Task<IActionResult> ListUser()
        {
            string link = "https://localhost:7280/api/Customers";
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.GetAsync(link))
                {
                    if (res.IsSuccessStatusCode)
                    {
                        string jsonResult = await res.Content.ReadAsStringAsync();
                        var resoult = JsonConvert.DeserializeObject<List<Customer>>(jsonResult);
                        List<Customer> listCus = resoult;
                        return View(listCus);
                    }
                    else
                    {
                        ViewData["Error"] = "Đăng nhập không thành công. Vui lòng kiểm tra lại thông tin đăng nhập.";
                        return View("Index");
                    }
                }
            }
        }

        public async Task<IActionResult> AddCustomer(string id)
        {
            return View();
        }
        public async Task<IActionResult> AddNewCustomer(CustomerDTO thamso)
        {
            string link = $"https://localhost:7280/api/Customers/AddNew?CustomerName={thamso.CustomerName}" +
                $"&email={thamso.Email}&birthday={thamso.Birthday}&IdentityCard={thamso.IdentityCard}&LicenceDate={thamso.LicenceDate}" +
                $"&LicenceNumber={thamso.LicenceNumber}&mobile={thamso.Mobile}";
            CustomerDTO cus = new CustomerDTO();
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.PostAsJsonAsync(link , cus))
                {
                    if (res.IsSuccessStatusCode)
                    {
                        string jsonResult = await res.Content.ReadAsStringAsync();
                        var resoult = JsonConvert.DeserializeObject<Customer>(jsonResult);
                        //return RedirectToRoute(new { action = "Author", id = roleId, name = name });
                        return View(resoult);
                    }
                    else
                    {
                        return View();
                    }
                }
            }
        }
        public async Task<IActionResult> DeleteCustomer(string id)
        {
            string link = "https://localhost:7280/api/Customers/";
            CustomerDTO cus = new CustomerDTO();
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.DeleteAsync(link+id))
                {
                    if (res.IsSuccessStatusCode)
                    {
                        return Redirect($"/Home");
                    }
                    else
                    {
                        return View();
                    }
                }
            }
        }
    }
}
