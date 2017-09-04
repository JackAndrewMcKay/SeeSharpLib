using System.IO;
using SeeSharpLib.Images;

namespace SeeSharpLib.IO
{
	public class MonoImageWriter
	{
		public void WriteFloatFrame(string path, MonoImage<float> image)
		{
			using (var stream = File.OpenWrite(path))
			{
				using (var writer = new BinaryWriter(stream))
				{
					var size = image.Size;

					for (var y = 0; y < size.Height; y++)
					{
						for (var x = 0; x < size.Width; x++)
						{
							writer.Write(image[x, y]);
						}
					}
				}
			}
		}

		public void WriteUShortFrame(string path, MonoImage<ushort> image)
		{
			using (var stream = File.OpenWrite(path))
			{
				using (var writer = new BinaryWriter(stream))
				{
					var size = image.Size;

					for (var y = 0; y < size.Height; y++)
					{
						for (var x = 0; x < size.Width; x++)
						{
							writer.Write(image[x, y]);
						}
					}
				}
			}
		}

		public void WriteByteFrame(string path, MonoImage<byte> image)
		{
			using (var stream = File.OpenWrite(path))
			{
				using (var writer = new BinaryWriter(stream))
				{
					var size = image.Size;

					for (var y = 0; y < size.Height; y++)
					{
						for (var x = 0; x < size.Width; x++)
						{
							writer.Write(image[x, y]);
						}
					}
				}
			}
		}
	}
}
