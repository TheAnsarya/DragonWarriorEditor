using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonWarriorEditor {
	class Tile : ITile {
		// TODO: Currently assuming 1 byte = index, so 0-255
		// TODO: put in adaptor function
		public byte[] RawData { get; set; }

		public Size Size { get; set; }

		// TODO: FIgure out live updates but with caching
		public Image AsImage(IPalette palette) {
			//public Image AsImage(int[] ) {
			/*
			Bitmap b = new Bitmap(this.Size.Width, this.Size.Height, PixelFormat.Format32bppArgb);
			b.Palette.Entries.
			Bitmap.FromStream()
			b.
				using (MemoryStream mStream = new MemoryStream()) {
				return Image.FromStream(mStream);
			}
			*/

			throw new NotImplementedException();
		}

		public Image AsImage() {
			throw new NotImplementedException();
		}

		// TODO: Currently assuming rawdata = indexes
		public byte[] ToRawImage(IPalette palette) {
			byte[] data = new byte[4 * this.RawData.Length];

			for (int i = 0; i < this.RawData.Length; i++) {
				int offset = i * 4;
				Color color = palette.Colors[this.RawData[i]];
				data[offset] = color.A;
				data[offset + 1] = color.R;
				data[offset + 2] = color.G;
				data[offset + 3] = color.B;
			}

			return data;
		}
	}
}
