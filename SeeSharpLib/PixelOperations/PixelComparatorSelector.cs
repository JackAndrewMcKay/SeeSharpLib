using System;
using System.Collections.Generic;

namespace SeeSharpLib.PixelOperations
{
	public class PixelComparatorSelector
	{
		public static PixelComparatorSelector Instance = new PixelComparatorSelector();

		static PixelComparatorSelector()
		{
			
		}

		private readonly Dictionary<Type, Type> _map;

		public PixelComparatorSelector()
		{
			_map = new Dictionary<Type, Type>();
		}

		public void AddComparatorTypeMapping(Type pixelType, Type calculatorType)
		{
			_map.Add(pixelType, calculatorType);
		}

		public Type GetPixelComparatorType(Type pixelType) => _map[pixelType];
	}
}
