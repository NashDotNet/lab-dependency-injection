namespace OpenGenericsExample2
{
	public class Pickle
	{
		readonly string _pickleType;

		public Pickle(string pickleType)
		{
			_pickleType = pickleType;
		}

		public override string ToString()
		{
			return _pickleType;
		}
	}
}