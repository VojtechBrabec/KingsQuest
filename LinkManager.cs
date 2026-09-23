namespace KingsQuest;

public class LinkManager
{
	private List<Link> links = new List<Link>();


	public List<Room> GetNextDoorRooms(Room room)
	{
		List<Room> availableRooms = new List<Room>();
		foreach (Link link in links)
		{
			if (link.getOtherRoom(room) != null)
			{
				availableRooms.Add(link.getOtherRoom(room));
			}
		}


		return availableRooms;
	}
	public void AddLink(Link link)
	{
		foreach (Link l in links)
		{
			if (l.CompareTo(link) == 0)
			{
				return;
			}
		}
		links.Add(link);
	}

	public void removeLink(Link link)
	{
		links.Remove(link);
	}

}