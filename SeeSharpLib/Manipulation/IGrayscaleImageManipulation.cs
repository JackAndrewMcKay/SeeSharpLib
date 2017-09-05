using SeeSharpLib.Images;

namespace SeeSharpLib.Manipulation
{
	public interface IGrayscaleImageManipulation<TPixel>
	{
		/// <summary>
		/// Apply the manipulation to the specified image.
		/// </summary>
		/// <param name="image">The image to be modified.</param>
		void ApplyTo(MonoImage<TPixel> image);
	}
}
