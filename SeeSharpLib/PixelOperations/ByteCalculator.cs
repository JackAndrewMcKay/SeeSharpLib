namespace SeeSharpLib.PixelOperations
{
	public class ByteCalculator : IPixelCalculator<byte>
	{
		public byte Add(byte operandA, byte operandB) => (byte) (operandA + operandB);

		public byte Add(byte operandA, int operandB) => (byte)(operandA + operandB);

		public byte Add(byte operandA, float operandB) => (byte)(operandA + operandB);

		public byte Add(byte operandA, double operandB) => (byte)(operandA + operandB);

		public byte Subtract(byte operandA, byte operandB) => (byte) (operandA - operandB);

		public byte Subtract(byte operandA, int operandB) => (byte)(operandA - operandB);

		public byte Subtract(byte operandA, float operandB) => (byte)(operandA - operandB);

		public byte Subtract(byte operandA, double operandB) => (byte)(operandA - operandB);

		public byte Multiply(byte operandA, byte operandB) => (byte) (operandA * operandB);

		public byte Multiply(byte operandA, int operandB) => (byte)(operandA * operandB);

		public byte Multiply(byte operandA, float operandB) => (byte)(operandA * operandB);

		public byte Multiply(byte operandA, double operandB) => (byte)(operandA * operandB);

		public byte Divide(byte operandA, byte operandB) => (byte) (operandA / operandB);

		public byte Divide(byte operandA, int operandB) => (byte)(operandA / operandB);

		public byte Divide(byte operandA, float operandB) => (byte)(operandA / operandB);

		public byte Divide(byte operandA, double operandB) => (byte)(operandA / operandB);
	}
}
