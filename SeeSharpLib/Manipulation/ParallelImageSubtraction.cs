using System;
using System.Threading.Tasks;
using SeeSharpLib.Images;

namespace SeeSharpLib.Manipulation
{
	public class ParallelImageSubtraction : IGrayscaleImageManipulation<float>
	{
		private readonly MonoImage<float> _image;

		public ParallelImageSubtraction(MonoImage<float> image)
		{
			_image = image;
		}

		public void ApplyTo(MonoImage<float> image)
		{
			var maxIntensity = (Math.Pow(2, image.BitDepth) - 1);

			Parallel.For(0, image.Size.Height, new ParallelOptions {MaxDegreeOfParallelism = Environment.ProcessorCount}, y =>
			{
				for (int x = 0; x < image.Size.Width; x++)
				{
					var newValue = (image[x, y] - _image[x, y]);
					newValue = Math.Max(0, newValue);
					newValue = (float)Math.Min(maxIntensity, newValue);

					image[x, y] = newValue;
				}
			});
		}
	}
}
