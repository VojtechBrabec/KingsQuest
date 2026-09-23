namespace KingsQuest;

internal class Room
{


	//0 left, 1 right, 2 up, 3 down
	private Room[] nextDoorRooms = new Room[4];
	public string Name { get; set; }
	public string Description { get; set; }
	public Room(string name, string description)
	{
		Name = name;
		Description = description;
	}


	internal void setNextDoorRoom(int direction, Room room)
	{
		if (nextDoorRooms[direction] != null)
		{
			return;
		}
		nextDoorRooms[direction] = room;
		switch (direction)
		{
			case 0:
				room.setNextDoorRoom(1, this);
				break;
			case 1:
				room.setNextDoorRoom(0, this);
				break;
			case 2:
				room.setNextDoorRoom(3, this);
				break;
			case 3:
				room.setNextDoorRoom(2, this);
				break;
		}
	}

	internal Room getNextDoorRoom(int direction)
	{
		return nextDoorRooms[direction];
	}

	public override string ToString()
	{
		return $"{Name}\n{Description}";
	}
}