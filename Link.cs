namespace KingsQuest;

public class Link : IComparable<Link>
{

	Room r1;
	Room r2;

	public Link(Room r1, Room r2)
	{
		this.r1 = r1;
		this.r2 = r2;
		if (r1 == null || r2 == null || r1.Equals(r2))
		{
			throw new ArgumentNullException("Rooms cannot be null or the same room");
		}
	}


	public Room getOtherRoom(Room room)
	{
		if (room.Equals(r1))
		{
			return r2;
		}
		else if (room.Equals(r2))
		{
			return r1;
		}
		else
		{
			return null;
		}
	}

	public int CompareTo(Link? other)
	{
		if (other == this) return 0;
		if (r1.Equals(other.r1) && r2.Equals(other.r2)) return 0;
		if (r1.Equals(other.r2) && r2.Equals(other.r1)) return 0;

		return -1;
	}
}