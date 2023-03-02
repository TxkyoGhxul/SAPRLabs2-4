namespace BLL.Exceptions;
public class ModelNotTrainedException : Exception
{
	public ModelNotTrainedException() : base("Model is not trained!")
	{
	}
}
