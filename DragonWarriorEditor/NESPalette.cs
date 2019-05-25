using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonWarriorEditor {
	class NESPalette : IPalette {
		// TODO: refactor into colorspace
		public static readonly byte[] FullPaletteData = new byte[] {
			0x54, 0x54, 0x54, 0x00, 0x1E, 0x74, 0x08, 0x10, 0x90, 0x30, 0x00, 0x88,
			0x44, 0x00, 0x64, 0x5C, 0x00, 0x30, 0x54, 0x04, 0x00, 0x3C, 0x18, 0x00,
			0x20, 0x2A, 0x00, 0x08, 0x3A, 0x00, 0x00, 0x40, 0x00, 0x00, 0x3C, 0x00,
			0x00, 0x32, 0x3C, 0x00, 0x00, 0x00, 0x98, 0x96, 0x98, 0x08, 0x4C, 0xC4,
			0x30, 0x32, 0xEC, 0x5C, 0x1E, 0xE4, 0x88, 0x14, 0xB0, 0xA0, 0x14, 0x64,
			0x98, 0x22, 0x20, 0x78, 0x3C, 0x00, 0x54, 0x5A, 0x00, 0x28, 0x72, 0x00,
			0x08, 0x7C, 0x00, 0x00, 0x76, 0x28, 0x00, 0x66, 0x78, 0x00, 0x00, 0x00,
			0xEC, 0xEE, 0xEC, 0x4C, 0x9A, 0xEC, 0x78, 0x7C, 0xEC, 0xB0, 0x62, 0xEC,
			0xE4, 0x54, 0xEC, 0xEC, 0x58, 0xB4, 0xEC, 0x6A, 0x64, 0xD4, 0x88, 0x20,
			0xA0, 0xAA, 0x00, 0x74, 0xC4, 0x00, 0x4C, 0xD0, 0x20, 0x38, 0xCC, 0x6C,
			0x38, 0xB4, 0xCC, 0x3C, 0x3C, 0x3C, 0xEC, 0xEE, 0xEC, 0xA8, 0xCC, 0xEC,
			0xBC, 0xBC, 0xEC, 0xD4, 0xB2, 0xEC, 0xEC, 0xAE, 0xEC, 0xEC, 0xAE, 0xD4,
			0xEC, 0xB4, 0xB0, 0xE4, 0xC4, 0x90, 0xCC, 0xD2, 0x78, 0xB4, 0xDE, 0x78,
			0xA8, 0xE2, 0x90, 0x98, 0xE2, 0xB4, 0xA0, 0xD6, 0xE4, 0xA0, 0xA2, 0xA0
		};

		private static Color[] _FullPaletteColors;
		public static Color[] FullPaletteColors {
			get {
				if (_FullPaletteColors == null) {
					int size = FullPaletteData.Length / 3;
					_FullPaletteColors = new Color[size];

					for (int i = 0; i < size; i++) {
						int index = i * 3;
						_FullPaletteColors[i] = Color.FromArgb(FullPaletteData[index], FullPaletteData[index + 1], FullPaletteData[index + 2]);
					}
				}

				return _FullPaletteColors;
			}
		}



		private byte[] _RawData;
		public byte[] RawData {
			get {
				return this._RawData;
			}
			set {
				if (value == null) {
					throw new ArgumentNullException("RawData cannot be null");
				}

				if (value.Length != 4) {
					throw new ArgumentException("RawData must be byte[4]");
				}

				this._RawData = value;
				this._Colors = null;
				this._RawColorsInt = null;
				this._RawColors = null;
			}
		}

		private Color[] _Colors;
		public Color[] Colors {
			get {
				if (this._Colors == null) {
					this._Colors = new Color[] {
						FullPaletteColors[this.RawData[0]],
						FullPaletteColors[this.RawData[1]],
						FullPaletteColors[this.RawData[2]],
						FullPaletteColors[this.RawData[3]]
					};
				}

				return this._Colors;
			}
		}

		// TODO: Probably get this from the raw data instead?
		private int[] _RawColorsInt;
		public int[] RawColorsInt {
			get {
				if (this._RawColorsInt == null) {
					this._RawColorsInt = new int[this.Size];
					for (int i = 0; i < this.Size; i++) {
						_RawColorsInt[i] = this.Colors[i].ToArgb();
					};
				}

				return this._RawColorsInt;
			}
		}

		// TODO: Probably get this from the raw data instead?
		private byte[] _RawColorsByte;
		public byte[] RawColorsByte {
			get {
				if (this._RawColorsByte == null) {
					this._RawColorsByte = new byte[4 * this.Size];
					for (int i = 0; i < this.Size; i++) {
						int offset = RawData[i] * 4;
						int index = i * 4;
						this._RawColorsByte[index] = FullPaletteData[offset];
						this._RawColorsByte[index + 1] = FullPaletteData[offset + 1];
						this._RawColorsByte[index + 2] = FullPaletteData[offset + 2];
						this._RawColorsByte[index + 3] = FullPaletteData[offset + 3];
					}
				}

				return this._RawColorsByte;
			}
		}

		/*
		// TODO: Probably get this from the raw data instead?
		private byte[][] _RawColors;
		public byte[][] RawColors {
			get {
				if (this._RawColors == null) {
					this._RawColors = new byte[this.Size][4];
					for (int i = 0; i < this.Size; i++) {
						int offset = RawData[i] * 4;
						int index = i * 4;
						this._RawColors[index] = FullPaletteData[offset];
						this._RawColors[index + 1] = FullPaletteData[offset + 1];
						this._RawColors[index + 2] = FullPaletteData[offset + 2];
						this._RawColors[index + 3] = FullPaletteData[offset + 3];
					}
				}

				return this._RawColors;
			}
		}*/

		public int Size {
			get {
				// TODO: Use hard coded?
				return 4;
				// return this.Colors.Length;
			}
		}

		public NESPalette(byte[] colors) {
			if (colors.Length != 4) {
				throw new ArgumentException("colors should be byte[4]");
			}

			this.RawData = colors;
		}

		public bool ColorAllowed(Color color) {
			return FullPaletteColors.Any(x => x.Equals(color));
		}

		public bool ColorAllowed(int color) {
			return ColorAllowed(Color.FromArgb(color));
		}

		public bool ColorAllowed(byte[] color) {
			if (color.Length != 4) {
				throw new ArgumentException("color should be byte[4]");
			}

			return ColorAllowed(Color.FromArgb(color[0], color[1], color[2], color[3]));
		}
	}
}
