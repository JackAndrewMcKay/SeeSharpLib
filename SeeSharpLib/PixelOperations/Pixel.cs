using System;

namespace SeeSharpLib.PixelOperations
{
	public class Pixel<TPixel>
	{
		private static IPixelCalculator<TPixel> _calculator;
		public static IPixelCalculator<TPixel> Calculator => _calculator ?? (_calculator = Activator.CreateInstance(PixelCalculatorSelector.Instance.GetPixelCalculatorType(typeof(TPixel))) as IPixelCalculator<TPixel>);

		private static IPixelComparator<TPixel> _comparator;
		public static IPixelComparator<TPixel> Comparator => _comparator ?? (_comparator = Activator.CreateInstance(PixelComparatorSelector.Instance.GetPixelComparatorType(typeof(TPixel))) as IPixelComparator<TPixel>);

		private TPixel _value;

		public Pixel(TPixel pixel)
		{
			_value = pixel;
		}

		public static implicit operator Pixel<TPixel>(TPixel value) => new Pixel<TPixel>(value);

		public static implicit operator TPixel(Pixel<TPixel> pixel) => pixel._value;

		public static Pixel<TPixel> operator +(Pixel<TPixel> operandA, Pixel<TPixel> operandB) => Calculator.Add(operandA, operandB);

		public static Pixel<TPixel> operator +(Pixel<TPixel> operandA, int operandB) => Calculator.Add(operandA, operandB);

		public static Pixel<TPixel> operator +(Pixel<TPixel> operandA, float operandB) => Calculator.Add(operandA, operandB);

		public static Pixel<TPixel> operator +(Pixel<TPixel> operandA, double operandB) => Calculator.Add(operandA, operandB);

		public static Pixel<TPixel> operator -(Pixel<TPixel> operandA, Pixel<TPixel> operandB) => Calculator.Subtract(operandA, operandB);

		public static Pixel<TPixel> operator -(Pixel<TPixel> operandA, int operandB) => Calculator.Subtract(operandA, operandB);

		public static Pixel<TPixel> operator -(Pixel<TPixel> operandA, float operandB) => Calculator.Subtract(operandA, operandB);

		public static Pixel<TPixel> operator -(Pixel<TPixel> operandA, double operandB) => Calculator.Subtract(operandA, operandB);

		public static Pixel<TPixel> operator *(Pixel<TPixel> operandA, Pixel<TPixel> operandB) => Calculator.Multiply(operandA, operandB);

		public static Pixel<TPixel> operator *(Pixel<TPixel> operandA, int operandB) => Calculator.Multiply(operandA, operandB);

		public static Pixel<TPixel> operator *(Pixel<TPixel> operandA, float operandB) => Calculator.Multiply(operandA, operandB);

		public static Pixel<TPixel> operator *(Pixel<TPixel> operandA, double operandB) => Calculator.Multiply(operandA, operandB);

		public static Pixel<TPixel> operator /(Pixel<TPixel> operandA, Pixel<TPixel> operandB) => Calculator.Divide(operandA, operandB);

		public static Pixel<TPixel> operator /(Pixel<TPixel> operandA, int operandB) => Calculator.Divide(operandA, operandB);

		public static Pixel<TPixel> operator /(Pixel<TPixel> operandA, float operandB) => Calculator.Divide(operandA, operandB);

		public static Pixel<TPixel> operator /(Pixel<TPixel> operandA, double operandB) => Calculator.Divide(operandA, operandB);

		public static bool operator >(Pixel<TPixel> operandA, Pixel<TPixel> operandB) => Comparator.Compare(operandA, operandB) > 0;

		public static bool operator <(Pixel<TPixel> operandA, Pixel<TPixel> operandB) => Comparator.Compare(operandA, operandB) < 0;

		public static bool operator >=(Pixel<TPixel> operandA, Pixel<TPixel> operandB) => Comparator.Compare(operandA, operandB) >= 0;

		public static bool operator <=(Pixel<TPixel> operandA, Pixel<TPixel> operandB) => Comparator.Compare(operandA, operandB) <= 0;

		public static bool operator ==(Pixel<TPixel> operandA, Pixel<TPixel> operandB) => Comparator.Compare(operandA, operandB) == 0;

		public static bool operator !=(Pixel<TPixel> operandA, Pixel<TPixel> operandB) => Comparator.Compare(operandA, operandB) != 0;

	}
}
