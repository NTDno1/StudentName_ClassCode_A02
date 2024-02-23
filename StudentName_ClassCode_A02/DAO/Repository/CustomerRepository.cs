using BUS.DTO;
using BUS.Models;
using Microsoft.EntityFrameworkCore;

namespace DAO.Repository
{
    public class CustomerRepository: ICustomerRepository
    {
        private readonly HotelDbContext _context;

        public CustomerRepository(HotelDbContext context)
        {
            _context = context;
        }

        public Customer GetCustomer(string email, string passWord)
        {
            Customer customer = _context.Customers.FirstOrDefault(u=>u.Email == email && u.Password == passWord );
            if (_context.Customers == null)
            {
                return null;
            }
            return customer;
        }
        public List<Customer> GetListCustomer()
        {
            List<Customer> list = _context.Customers.Where(u=>u.CustomerID != 2).ToList();
            return list;
        }
    }
}
