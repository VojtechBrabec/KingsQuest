namespace KingsQuest;

public class Room
{
	private string name;
	private string description;

	public Room(string name)
	{
		this.name = name;
	}

	public Room(string name, string description)
	{
		this.name = name;
		this.description = description;
	}

	public override string ToString()
	{
		return name + ":\n" + description;
	}

	public string getName
	{
		get { return name; }
	}
	public string getDescription
	{
		get { return description; }
	}

}