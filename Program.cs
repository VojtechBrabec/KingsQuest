namespace KingsQuest;

public class Program
{

	private static LinkManager lm;
	private static Room throneRoom = new Room("Throne Room", "A grand room with a large throne at the end. The king is sitting on the throne with the princess by his side");
	private static Room dungeon = new Room("Dragon Lair", "A dark and damp room with a dragon sleeping in the corner");
	private static Room armory = new Room("Armory", "A room filled with weapons and armor");

	private static Character king = new Character("King");
	private static Character princess = new Character("Princess");
	private static Character dragon = new Character("Dragon");
	private static Character guard = new Character("Guard");



	private static void setUp()
	{
		lm = new LinkManager();
		lm.AddLink(new Link(throneRoom, dungeon));
		lm.AddLink(new Link(throneRoom, armory));

		throneRoom.addCharacter(king);
		throneRoom.addCharacter(princess);
		dungeon.addCharacter(dragon);
		armory.addCharacter(guard);
	}


	public static void Main(string[] args)
	{


		setUp();


		// lm.AddLink(new Link(throneRoom, dungeon));
		// lm.AddLink(new Link(throneRoom, armory));

		gameLoop();

	}

	private static void gameLoop()
	{
		Room currentRoom = throneRoom;
		List<Room> availableRooms = new List<Room>();
		List<Character> availableCharacters = new List<Character>();
		string input = "";

		Console.WriteLine("Welcome to Kings Quest! Type 'help' for a list of commands.\n\n");


		while (true)
		{


			Console.WriteLine("You are in the " + currentRoom);



			availableRooms = lm.GetNextDoorRooms(currentRoom);
			availableCharacters = currentRoom.getCharacters;

			Console.WriteLine("Available rooms:\n");
			foreach (Room room in availableRooms)
			{
				Console.WriteLine(room.getName);
			}

			Console.WriteLine("You can talk to: \n");


			foreach (Character character in availableCharacters)
			{
				Console.WriteLine(character.getName());
			}

			input = Console.ReadLine().ToLower();
			Console.Clear();


			// Console.WriteLine("\n\n");
			if (input.StartsWith("talk-to"))
			{
				characterSelection(availableCharacters, currentRoom, input);
			}
			else if (input.StartsWith("go-to"))
			{
				currentRoom = roomSelection(availableRooms, currentRoom, input);
			}

			availableRooms.Clear();
			// Console.WriteLine("clear was here");

			if (input == "help")
			{
				help();
				Console.Clear();
			}

			if (input == "exit")
			{
				return;
			}


		}
	}
	private static Room roomSelection(List<Room> availableRooms, Room currentRoom, string input)
	{
		input = input.Substring(6);
		foreach (Room room in availableRooms)
		{

			if (room.getName.ToLower() == input)
			{
				Console.WriteLine("You went to: " + room.getName);
				currentRoom = room;
				return currentRoom;
			}
		}
		return currentRoom;
	}

	private static void characterSelection(List<Character> availableCharacters, Room currentRoom, string input)
	{
		string characterName = input.Substring(8);
		Character? character = currentRoom.getCharacter(characterName);
		Console.WriteLine("you are trying to talk to: " + characterName);
		if (character != null)
		{
			Console.WriteLine("You talk to " + character.getName());
		}
		else
		{
			Console.WriteLine("There is no one by that name here.");
		}
	}


	private static void help()
	{
		Console.WriteLine("\n\n");
		Console.WriteLine("**************************************************\n");

		Console.WriteLine("Available commands:");
		Console.WriteLine("go-to <room-name> - Move to a different room");
		Console.WriteLine("talk-to <character-name> - Talk to a character");
		Console.WriteLine("help - Show this help message");
		Console.WriteLine("exit - Exit the game");
		Console.WriteLine("enter to exit this help menu\n");
		Console.WriteLine("**************************************************");
		Console.WriteLine("\n\n");

		Console.ReadLine();

	}
}