using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace DragonWarriorEditor {
	public class Definition {

		public enum Map {
			TantegelCastleThroneRoom = 0,
			TantegelCastleBasementSunlightShrine = 1,
			TantegelCastle = 2,
			Rimuldar = 3,
			Cantlin = 4,
			Brecconary = 5,
			Kol = 6,
			SwampCave = 7,
			RainShrine = 8,
			RainbowShrine = 9,
			ErdricksCaveB1 = 100,
			ErdricksCaveB2 = 11,
			GarinhamsGraveB1 = 12,
			GarinhamsGraveB2 = 13,
			GarinhamsGraveB3 = 14,
			GarinhamsGraveB4 = 15,
			Garinham = 16,
			CharlockCastleB1 = 17,
			CharlockCastleB2 = 18,
			CharlockCastleB3 = 19,
			CharlockCastleB4 = 20,
			CharlockCastleB5 = 21,
			CharlockCastleB6 = 22,
			CharlockCastleB7 = 23,
			CharlockCastleF1 = 24,
			Hauksness = 25,
			RockMountainB1 = 26,
			RockMountainB2 = 27
		}

		public enum Size {
			w10h10 = 1,
			w14h14 = 2,
			w20h20 = 3,
			w24h24 = 4,
			w30h30 = 5,
			w6h30 = 6,
			w14h12 = 7
		}

		public static ReadOnlyDictionary<Size, Dimension> Sizes = new ReadOnlyDictionary<Size, Dimension>(
			new Dictionary<Size, Dimension>() {
				{ Size.w10h10, new Dimension(10, 10) },
				{ Size.w14h14, new Dimension(14, 14) },
				{ Size.w20h20, new Dimension(20, 20) },
				{ Size.w24h24, new Dimension(24, 24) },
				{ Size.w30h30, new Dimension(30, 30) },
				{ Size.w6h30, new Dimension(6, 30) },
				{ Size.w14h12, new Dimension(14, 12) }
			}
		);

		public static ReadOnlyDictionary<Map, MapInfo> Maps = new ReadOnlyDictionary<Map, MapInfo>(
			new Dictionary<Map, MapInfo>() {
				{ Map.TantegelCastleThroneRoom, new MapInfo(Size.w10h10, 0x412) },
				{ Map.TantegelCastleBasementSunlightShrine, new MapInfo(Size.w10h10, 0xD34) },
				{ Map.TantegelCastle, new MapInfo(Size.w30h30, 0x250) },
				{ Map.Rimuldar, new MapInfo(Size.w30h30, 0xB72) },
				{ Map.Cantlin, new MapInfo(Size.w30h30, 0x8E8) },
				{ Map.Brecconary, new MapInfo(Size.w30h30, 0x726) },
				{ Map.Kol, new MapInfo(Size.w24h24, 0x606) },
				{ Map.SwampCave, new MapInfo(Size.w6h30, 0xF8C) },
				{ Map.RainShrine, new MapInfo(Size.w10h10, 0xD66) },
				{ Map.RainbowShrine, new MapInfo(Size.w10h10, 0xD98) },
				{ Map.ErdricksCaveB1, new MapInfo(Size.w10h10, 0x12C0) },
				{ Map.ErdricksCaveB2, new MapInfo(Size.w10h10, 0x12F2) },
				{ Map.GarinhamsGraveB1, new MapInfo(Size.w20h20, 0x10AA) },
				{ Map.GarinhamsGraveB2, new MapInfo(Size.w14h12, 0x126C) },
				{ Map.GarinhamsGraveB3, new MapInfo(Size.w20h20, 0x1172) },
				{ Map.GarinhamsGraveB4, new MapInfo(Size.w10h10, 0x123A) },
				{ Map.Garinham, new MapInfo(Size.w20h20, 0xAAA) },
				{ Map.CharlockCastleB1, new MapInfo(Size.w20h20, 0xDCA) },
				{ Map.CharlockCastleB2, new MapInfo(Size.w10h10, 0xE92) },
				{ Map.CharlockCastleB3, new MapInfo(Size.w10h10, 0xEC4) },
				{ Map.CharlockCastleB4, new MapInfo(Size.w10h10, 0xEF6) },
				{ Map.CharlockCastleB5, new MapInfo(Size.w10h10, 0xF28) },
				{ Map.CharlockCastleB6, new MapInfo(Size.w10h10, 0xF5A) },
				{ Map.CharlockCastleB7, new MapInfo(Size.w30h30, 0x444) },
				{ Map.CharlockCastleF1, new MapInfo(Size.w20h20, 0xC0) },
				{ Map.Hauksness, new MapInfo(Size.w20h20, 0x188) },
				{ Map.RockMountainB1, new MapInfo(Size.w14h14, 0xFE6) },
				{ Map.RockMountainB2, new MapInfo(Size.w14h12, 0x1048) }  // TODO: This is 14x14 in DWTAD
			}
		);

		public class Dimension {
			public int Width { get; private set; }

			public int Height { get; private set; }

			public int DataLength {
				get {
					return this.Width * this.Height / 2;
				}
			}

			public Dimension(int width, int height) {
				this.Width = width;
				this.Height = height;
			}
		}

		public class MapInfo {
			// TODO: Currently doesn't deal with NOT FOUND
			// TODO: Maybe protect the constructor so only can be made here
			public Map Map {
				get {
					return Definition.Maps.First(x => x.Value == this).Key;
				}
			}

			public Size Size { get; private set; }

			public Dimension Dimension {
				get {
					return Definition.Sizes[this.Size];
				}
			}
			public int DataLength {
				get {
					return this.Dimension.DataLength;
				}
			}

			public long Address { get; private set; }

			public MapInfo(Size size, long address) {
				this.Size = size;
				this.Address = address;
			}
		}
	}
}
