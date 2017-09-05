using System;
using System.Threading.Tasks;
using SeeSharpLib.Images;

namespace SeeSharpLib.Manipulation
{
	public class ParallelGaussianBlur : IGrayscaleImageManipulation<float>
	{
		private readonly int _kernelRadius;
		private readonly int _kernelWidth;
		private readonly double _sigma;
		private readonly double[] _kernel;

		public ParallelGaussianBlur(int kernelRadius, double sigma)
		{
			_kernelRadius = kernelRadius;
			_kernelWidth = (2 * kernelRadius) + 1;
			_sigma = sigma;
			
			_kernel = new double[_kernelWidth];
			PopulateKernel();
			NormaliseKernel();
		}

		public void ApplyTo(MonoImage<float> image)
		{
			MonoImage<float> intermediateImage = image.Clone() as MonoImage<float>;

			ApplyHorizontally(image, intermediateImage);
			ApplyVertically(intermediateImage, image);
		}

		/// <summary>
		/// Populate a 1D gaussian kernel using the supplied sigma and radius.
		/// </summary>
		private void PopulateKernel()
		{
			double variance = Math.Pow(_sigma, 2);
			double doubleVariance = 2 * variance;

			double factorA = 1 / Math.Sqrt(Math.PI * doubleVariance);

			for (int i = 0; i < _kernelWidth; i++)
			{
				int distanceFromCenter = i - _kernelRadius;
				int distanceSquared = (int) Math.Pow(distanceFromCenter, 2);

				double newValue = factorA * Math.Exp(-(distanceSquared / doubleVariance));
				_kernel[i] = newValue;
			}
		}

		/// <summary>
		/// Normalise the kernel so that the maximum total of all weights is 1. This is to prevent an alteration to the global brightness of the image.
		/// </summary>
		private void NormaliseKernel()
		{
			double accumulatedTotal = 0;

			for (int i = 0; i < _kernelWidth; i++)
			{
				accumulatedTotal += _kernel[i];
			}

			for (int i = 0; i < _kernelWidth; i++)
			{
				_kernel[i] /= accumulatedTotal;
			}
		}

		/// <summary>
		/// Do a horizontal pass of the kernel over the image. The results are placed in an intermediate image as other the result of each transformation would affect the values of the next kernel sample.
		/// </summary>
		/// <param name="srcImage">The image source data.</param>
		/// <param name="dstImage">The image destination data.</param>
		private void ApplyHorizontally(MonoImage<float> srcImage, MonoImage<float> dstImage)
		{
			int maxIntensity = (int) (Math.Pow(2, srcImage.BitDepth) - 1);

			Parallel.For(0, srcImage.Size.Height, new ParallelOptions {MaxDegreeOfParallelism = Environment.ProcessorCount}, y =>
			{
				for (int x = 0; x < srcImage.Size.Width; x++)
				{
					double accumulated = 0;

					for (int kernelX = 0, pixelX = x - _kernelRadius; kernelX < _kernelWidth; kernelX++, pixelX++)
					{
						int correctedX = MirrorXIfOutOfRange(pixelX, srcImage.Size.Width);

						accumulated += (_kernel[kernelX] * srcImage[correctedX, y]);
					}

					accumulated = Math.Max(0, accumulated);
					accumulated = Math.Min(maxIntensity, accumulated);

					dstImage[x, y] = (float) accumulated;
				}
			});
		}

		/// <summary>
		/// Do a vertical pass of the kernel over the image. The results are placed in an intermediate image as other the result of each transformation would affect the values of the next kernel sample.
		/// </summary>
		/// <param name="srcImage">The image source data.</param>
		/// <param name="dstImage">The image destination data.</param>
		private void ApplyVertically(MonoImage<float> srcImage, MonoImage<float> dstImage)
		{
			int maxIntensity = (int)(Math.Pow(2, srcImage.BitDepth) - 1);

			Parallel.For(0, srcImage.Size.Height, new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount }, y =>
			{
				for (int x = 0; x < srcImage.Size.Width; x++)
				{
					double accumulated = 0;

					for (int kernelY = 0, pixelY = y - _kernelRadius; kernelY < _kernelWidth; kernelY++, pixelY++)
					{
						int correctedY = MirrorYIfOutOfRange(pixelY, srcImage.Size.Height);

						accumulated += (_kernel[kernelY] * srcImage[x, correctedY]);
					}

					accumulated = Math.Max(0, accumulated);
					accumulated = Math.Min(maxIntensity, accumulated);

					dstImage[x, y] = (float)accumulated;
				}
			});
		}

		/// <summary>
		/// Mirrors X if it exceeds the image boundaries
		/// </summary>
		/// <param name="x">The x coordinate</param>
		/// <param name="width">The image width</param>
		/// <returns>The corrected X value</returns>
		private int MirrorXIfOutOfRange(int x, int width) => (x < 0) ? -x : (x >= width) ? width - 1 - (x - width) : x;

		/// <summary>
		/// Mirrors Y if it exceeds the image boundaries
		/// </summary>
		/// <param name="y">The y coordinate</param>
		/// <param name="height">The image height</param>
		/// <returns>The corrected X value</returns>
		private int MirrorYIfOutOfRange(int y, int height) => (y < 0) ? -y : (y >= height) ? height - 1 - (y - height) : y;
	}
}
