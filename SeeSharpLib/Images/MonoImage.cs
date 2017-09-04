using SeeSharpLib.Common;

namespace SeeSharpLib.Images
{
	public class MonoImage<TPixel>
	{
		private readonly TPixel[][] _pixels;
		public TPixel this[int x, int y]
		{
			get => _pixels[x][y];
			set => _pixels[x][y] = value;
		}

		public readonly Size Size;

		public MonoImage(int width, int height)
		{
			_pixels = new TPixel[width][];

			for (var x = 0; x < width; x++)
			{
				_pixels[x] = new TPixel[height];
			}

			Size = new Size(width, height);
		}
	}
}
