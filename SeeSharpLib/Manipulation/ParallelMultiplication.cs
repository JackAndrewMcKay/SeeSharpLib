using System;
using System.Threading.Tasks;
using SeeSharpLib.Images;

namespace SeeSharpLib.Manipulation
{
	public class ParallelMultiplication : IGrayscaleImageManipulation<float>
	{
		private readonly double _factor;

		public ParallelMultiplication(double factor)
		{
			_factor = factor;
		}

		public void ApplyTo(MonoImage<float> image)
		{
			var maxIntensity = (Math.Pow(2, image.BitDepth) - 1);

			Parallel.For(0, image.Size.Height, new ParallelOptions {MaxDegreeOfParallelism = Environment.ProcessorCount}, y =>
			{
				for (int x = 0; x < image.Size.Width; x++)
				{
					double newValue = image[x, y] * _factor;
					newValue = Math.Max(0, newValue);
					newValue = Math.Min(maxIntensity, newValue);

					image[x, y] = (float) (newValue);
				}
			});
		}
	}
}
