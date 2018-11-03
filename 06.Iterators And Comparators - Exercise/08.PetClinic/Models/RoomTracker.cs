public class RoomTracker
{
    private int currentIndex;

    public RoomTracker(int totalRooms)
    {
        this.TotalRooms = totalRooms;
        this.EmptyRooms = totalRooms;
        this.StartingRoom = this.TotalRooms / 2;
        this.currentIndex = 0;
    }

    public int TotalRooms { get; private set; }

    public int StartingRoom { get; private set; }

    public int EmptyRooms { get; private set; }

    public int GiveNextEmptyRoom()
    {
        var index = EmptyRooms % 2 != 0 ?
          StartingRoom + currentIndex++ : StartingRoom - currentIndex;

        this.EmptyRooms--;
        return index;
    }

    public bool MakeEmptyRoom(Pet[] roomsWithPets, int start, int end)
    {
        for (int i = start; i < end; i++)
        {
            if (roomsWithPets[i] != null)
            {
                roomsWithPets[i] = null;
                this.EmptyRooms++;
                return true;
            }
        }
        return false;
    }
}