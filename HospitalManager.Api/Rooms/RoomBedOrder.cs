namespace HospitalManager.Api.Rooms
{
    public class RoomBedOrder
    {
        public string HospitalName { get; set; }
        public int RoomNumber { get; set; }
        public int NumberOfBedsToAdd { get; set; }

        public RoomBedOrder(string hospitalName, int roomNumber, int numberOfBedsToAdd)
        {
            HospitalName = hospitalName;
            RoomNumber = roomNumber;
            NumberOfBedsToAdd = numberOfBedsToAdd;
        }

        public RoomBedOrder()
        {
        }
    }
}