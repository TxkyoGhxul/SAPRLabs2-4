namespace BLL.Exceptions;
public class WrongDataToTrainException : Exception
{
	public WrongDataToTrainException(string msg) : base(msg)
	{
	}

	public WrongDataToTrainException() : base("Data is wrong!")
	{
	}
}
