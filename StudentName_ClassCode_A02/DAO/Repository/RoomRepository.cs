using BUS.Models;

namespace DAO.Repository
{
    public class RoomRepository : IRoomRepository
    {
        private readonly HotelDbContext _context;

        public RoomRepository(HotelDbContext context)
        {
            _context = context;
        }
        public List<RoomInformation> GetListRoom()
        {
            return _context.RoomInformations.ToList();
        }

        public RoomInformation GetRoom(string userName, string passWord)
        {
            throw new NotImplementedException();
        }
    }
}
