namespace KingsQuest;

using System.Collections;
internal class Program
{
	public static void Main(string[] args)
	{
		Room throneRoom = new Room("Throne Room", "The grand throne room of the castle. The King is sitting on his trone with the princess by his side");
		Room dragonLair = new Room("Dragon's Lair", "A dark and ominous cave where the dragon sleeps. The air is thick with smoke and the smell of sulfur.");
		Room armory = new Room("Armory", "A guard stands in the room. It's filled with weapons and armor. The walls are lined with racks of swords, shields, and suits of armor.");

		throneRoom.setNextDoorRoom(0, armory);
		throneRoom.setNextDoorRoom(1, dragonLair);

		ArrayList directions = new ArrayList();
		Room currentRoom = throneRoom;
		while (true)
		{

			for (int i = 0; i < 4; i++)
			{
				if (currentRoom.getNextDoorRoom(i) != null)
				{
					directions.Add(currentRoom.getNextDoorRoom(i));
				}

			}

			Console.WriteLine(currentRoom);
			Console.WriteLine("Where would you like to go? (left, right, up, down)");

			for (int i = 0; i < directions.Count; i++)
			{
				Console.WriteLine($"{i + 1}. {((Room)directions[i]).Name}");
			}

			string input = Console.ReadLine().ToLower();

			for (int i = 0; i < directions.Count; i++)
			{
				if (input.Equals(((Room)directions[i]).Name.ToLower()))
				{
					currentRoom = (Room)directions[i];
					break;
				}
			}


			directions.Clear();

			if (input.Equals("quit"))
			{
				break;
			}
		}
	}
}