namespace SeeSharpLib.PixelOperations
{
	public interface IPixelCalculator<TPixel>
	{
		TPixel Add(TPixel operandA, TPixel operandB);

		TPixel Add(TPixel operandA, int operandB);

		TPixel Add(TPixel operandA, float operandB);

		TPixel Add(TPixel operandA, double operandB);

		TPixel Subtract(TPixel operandA, TPixel operandB);

		TPixel Subtract(TPixel operandA, int operandB);

		TPixel Subtract(TPixel operandA, float operandB);

		TPixel Subtract(TPixel operandA, double operandB);

		TPixel Multiply(TPixel operandA, TPixel operandB);

		TPixel Multiply(TPixel operandA, int operandB);

		TPixel Multiply(TPixel operandA, float operandB);

		TPixel Multiply(TPixel operandA, double operandB);

		TPixel Divide(TPixel operandA, TPixel operandB);

		TPixel Divide(TPixel operandA, int operandB);

		TPixel Divide(TPixel operandA, float operandB);

		TPixel Divide(TPixel operandA, double operandB);
	}
}
