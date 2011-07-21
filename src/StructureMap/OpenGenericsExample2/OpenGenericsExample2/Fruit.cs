namespace OpenGenericsExample2
{
	public class Fruit
	{
		readonly string _name;

		public Fruit(string name)
		{
			_name = name;
		}

		public override string ToString()
		{
			return _name;
		}
	}
}