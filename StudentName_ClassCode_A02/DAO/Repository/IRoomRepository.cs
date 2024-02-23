using BUS.Models;

namespace DAO.Repository
{
    public interface IRoomRepository
    {
        RoomInformation GetRoom(string userName, string passWord);
        List<RoomInformation> GetListRoom();
    }
}
