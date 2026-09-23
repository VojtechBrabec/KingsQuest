namespace KingsQuest;

public class Program
{

	private static LinkManager lm = new LinkManager();
	private static Room throneRoom = new Room("Throne Room", "A grand room with a large throne at the end. The king is sitting on the throne with the princess by his side");
	private static Room dungeon = new Room("Dragon Lair", "A dark and damp room with a dragon sleeping in the corner");
	private static Room armory = new Room("Armory", "A room filled with weapons and armor");


	public static void Main(string[] args)
	{
		LinkManager linkManager = new LinkManager();
		linkManager.AddLink(new Link(throneRoom, dungeon));
		linkManager.AddLink(new Link(throneRoom, armory));

		lm = linkManager;

		// lm.AddLink(new Link(throneRoom, dungeon));
		// lm.AddLink(new Link(throneRoom, armory));

		gameLoop();

	}

	private static void gameLoop()
	{
		Room currentRoom = throneRoom;
		List<Room> availableRooms = new List<Room>();
		string input = "";
		while (true)
		{
			Console.WriteLine("You are in the " + currentRoom);
			Console.WriteLine("Where would you like to go?");
			availableRooms = lm.GetNextDoorRooms(currentRoom);

			foreach (Room room in availableRooms)
			{
				Console.WriteLine(room.getName);
			}

			input = Console.ReadLine().ToLower();
			foreach (Room room in availableRooms)
			{
				if (room.getName.ToLower() == input)
				{
					currentRoom = room;
					break;
				}
			}

			availableRooms.Clear();


			if (input == "exit")
			{
				return;
			}
		}
	}

}