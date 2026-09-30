namespace KingsQuest;

public class Room
{
	private string name;
	private string description;

	private List<Character> characters = new List<Character>();

	public Room(string name)
	{
		this.name = name;
	}

	public Room(string name, string description)
	{
		this.name = name;
		this.description = description;
	}


	public string getName
	{
		get { return name; }
	}
	public string getDescription
	{
		get { return description; }
	}

	public List<Character> getCharacters
	{
		get { return characters; }
	}

	public Character? getCharacter(string name)
	{

		name = name.ToLower();
		foreach (Character c in characters)
		{
			if (c.getName().ToLower() == name)
			{
				return c;
			}
		}
		return null;
	}

	public void addCharacter(Character character)
	{
		if (character == null || characters.Contains(character))
		{
			return;
		}
		characters.Add(character);
	}

	public override string ToString()
	{
		return name + ":\n" + description;
	}

}