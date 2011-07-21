namespace OpenGenericsExample2
{
	public class Color
	{
		readonly string _color;

		public Color(string color)
		{
			_color = color;
		}

		public override string ToString()
		{
			return _color;
		}
	}
}