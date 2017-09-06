namespace SeeSharpLib.PixelOperations
{
	public interface IPixelComparator<TPixel>
	{
		int Compare(TPixel operandA, TPixel operandB);
	}
}
