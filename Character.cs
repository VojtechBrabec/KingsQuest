namespace KingsQuest;

public class Character
{
	private string name;
	// private string description;
	public Character(string name)
	{
		this.name = name;
	}


	public string getName()
	{
		return name;
	}

	public override string ToString()
	{
		return name;
	}


}