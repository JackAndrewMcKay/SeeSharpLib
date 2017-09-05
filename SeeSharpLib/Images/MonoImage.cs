using System;
using SeeSharpLib.Common;
using SeeSharpLib.Manipulation;

namespace SeeSharpLib.Images
{
	public class MonoImage<TPixel> : ICloneable
	{
		private readonly TPixel[][] _pixels;
		public TPixel this[int x, int y]
		{
			get => _pixels[x][y];
			set => _pixels[x][y] = value;
		}

		public int BitDepth { get; }

		public readonly Size Size;

		public MonoImage(int width, int height, int bitDepth)
		{
			_pixels = new TPixel[width][];

			for (var x = 0; x < width; x++)
			{
				_pixels[x] = new TPixel[height];
			}

			Size = new Size(width, height);

			BitDepth = bitDepth;
		}

		public void Apply(IGrayscaleImageManipulation<float> effect)
		{
			effect.ApplyTo((MonoImage<float>)(object)this);
		}

		public object Clone()
		{
			var image = new MonoImage<TPixel>(Size.Width, Size.Height, BitDepth);

			for (var y = 0; y < Size.Height; y++)
			{
				for (var x = 0; x < Size.Width; x++)
				{
					image[x, y] = this[x, y];
				}
			}

			return image;
		}
	}
}
