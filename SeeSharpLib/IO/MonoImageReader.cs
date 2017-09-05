using System.IO;
using SeeSharpLib.Images;

namespace SeeSharpLib.IO
{
	public class MonoImageReader
	{
		public MonoImage<float> ReadFloatFrame(string path, int width, int height, int bitDepth)
		{
			var img = new MonoImage<float>(width, height, bitDepth);

			using (var stream = File.OpenRead(path))
			{
				using (var reader = new BinaryReader(stream))
				{
					for (var y = 0; y < height; y++)
					{
						for (var x = 0; x < width; x++)
						{
							img[x, y] = reader.ReadSingle();
						}
					}
				}
			}

			return img;
		}

		public MonoImage<ushort> ReadUShortFrame(string path, int width, int height, int bitDepth)
		{
			var img = new MonoImage<ushort>(width, height, bitDepth);

			using (var stream = File.OpenRead(path))
			{
				using (var reader = new BinaryReader(stream))
				{
					for (var y = 0; y < height; y++)
					{
						for (var x = 0; x < width; x++)
						{
							img[x, y] = reader.ReadUInt16();
						}
					}
				}
			}

			return img;
		}

		public MonoImage<byte> ReadByteFrame(string path, int width, int height, int bitDepth)
		{
			var img = new MonoImage<byte>(width, height, bitDepth);

			using (var stream = File.OpenRead(path))
			{
				using (var reader = new BinaryReader(stream))
				{
					for (var y = 0; y < height; y++)
					{
						for (var x = 0; x < width; x++)
						{
							img[x, y] = reader.ReadByte();
						}
					}
				}
			}

			return img;
		}
	}
}
