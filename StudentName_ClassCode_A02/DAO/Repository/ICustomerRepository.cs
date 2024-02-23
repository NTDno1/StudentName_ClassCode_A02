using BUS.DTO;
using BUS.Models;

namespace DAO.Repository
{
    public interface ICustomerRepository
    {
        Customer GetCustomer(string userName , string passWord);
        List<Customer> GetListCustomer();
    }
}
