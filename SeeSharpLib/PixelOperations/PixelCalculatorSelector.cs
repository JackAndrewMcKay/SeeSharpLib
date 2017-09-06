using System;
using System.Collections.Generic;

namespace SeeSharpLib.PixelOperations
{
	public class PixelCalculatorSelector
	{
		public static PixelCalculatorSelector Instance = new PixelCalculatorSelector();

		static PixelCalculatorSelector()
		{
			Instance.AddCalculatorTypeMapping(typeof(byte), typeof(ByteCalculator));
		}

		private readonly Dictionary<Type, Type> _map;

		public PixelCalculatorSelector()
		{
			_map = new Dictionary<Type, Type>();
		}

		public void AddCalculatorTypeMapping(Type pixelType, Type calculatorType)
		{
			_map.Add(pixelType, calculatorType);
		}

		public Type GetPixelCalculatorType(Type pixelType) => _map[pixelType];
	}
}
