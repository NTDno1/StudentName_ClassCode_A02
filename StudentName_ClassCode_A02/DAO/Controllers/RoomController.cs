using BUS.Models;
using DAO.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DAO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly HotelDbContext _context;
        private readonly IRoomRepository _roomRepository;

        public RoomController(HotelDbContext context, IRoomRepository roomRepository)
        {
            _context = context;
            _roomRepository = roomRepository;
        }

        // GET: api/Customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetRoom()
        {
            List<RoomInformation> cust = _roomRepository.GetListRoom();
            if (cust == null)
            {
                return NotFound();
            }
            return Ok(cust);
        }

        // GET: api/Customers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(int id)
        {
            if (_context.Customers == null)
            {
                return NotFound();
            }
            var customer = await _context.Customers.FindAsync(id);

            if (customer == null)
            {
                return NotFound();
            }

            return customer;
        }

        // PUT: api/Customers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(int id, Customer customer)
        {
            if (id != customer.CustomerID)
            {
                return BadRequest();
            }

            _context.Entry(customer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Customers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Customer>> PostCustomer(string email, string pass)
        {
            if (_context.Customers == null)
            {
                return Problem("Entity set 'HotelDbContext.Customers'  is null.");
            }

            Customer cus = new()
            {
                CustomerName = "",
                Email = email,
                Birthday = DateTime.Now,
                IdentityCard = "",
                LicenceDate = DateTime.Now,
                LicenceNumber = "",
                Mobile = "",
                Password = pass,
            };
            _context.Customers.Add(cus);
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpPost("AddNew")]
        public async Task<ActionResult<Customer>> AddNew(string CustomerName, string email, DateTime birthday,
            string IdentityCard, DateTime LicenceDate, string LicenceNumber, string mobile)
        {
            if (_context.Customers == null)
            {
                return Problem("Entity set 'HotelDbContext.Customers'  is null.");
            }
            var checkEmail = _context.Customers.FirstOrDefault(u => u.Email.Equals(email));
            if (checkEmail != null)
            {
                return Problem("Đã tồn tại Email");
            }
            else
            {
                Customer cus = new()
                {
                    CustomerName = CustomerName,
                    Email = email,
                    Birthday = birthday,
                    IdentityCard = IdentityCard,
                    LicenceDate = LicenceDate,
                    LicenceNumber = LicenceNumber,
                    Mobile = mobile,
                    Password = "123",
                };
                _context.Customers.Add(cus);
                await _context.SaveChangesAsync();
            }
            return Ok();
        }

        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            if (_context.RoomInformations == null)
            {
                return NotFound();
            }
            var RoomInformations = await _context.RoomInformations.FindAsync(id);
            if (RoomInformations == null)
            {
                return NotFound();
            }

            _context.RoomInformations.Remove(RoomInformations);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CustomerExists(int id)
        {
            return (_context.Customers?.Any(e => e.CustomerID == id)).GetValueOrDefault();
        }
    }
}
