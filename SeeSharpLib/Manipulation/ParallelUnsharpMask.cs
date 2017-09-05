using SeeSharpLib.Images;

namespace SeeSharpLib.Manipulation
{
	public class ParallelUnsharpMask : IGrayscaleImageManipulation<float>
	{
		private readonly double _weight;
		private readonly double _sigma;
		private readonly int _radius;

		public ParallelUnsharpMask(int radius, double sigma, double weight)
		{
			_weight = weight;
			_radius = radius;
			_sigma = sigma;
		}

		public void ApplyTo(MonoImage<float> image)
		{
			MonoImage<float> unsharpMask = image.Clone() as MonoImage<float>;
			unsharpMask.Apply(new ParallelGaussianBlur(_radius, _sigma));
			unsharpMask.Apply(new ParallelMultiplication(_weight));
			image.Apply(new ParallelImageSubtraction(unsharpMask));

			double normalisingFactor = 1 / (1 - _weight);
			image.Apply(new ParallelMultiplication(normalisingFactor));
		}
	}
}
