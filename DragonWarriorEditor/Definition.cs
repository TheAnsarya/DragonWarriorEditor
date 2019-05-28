using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
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
			ErdricksCaveB1 = 10,
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

		public enum MapSize {
			w10h10 = 0,
			w14h14 = 1,
			w20h20 = 2,
			w24h24 = 3,
			w30h30 = 4,
			w6h30 = 5,
			w14h12 = 6
		}

		public enum TileSet {
			Town = 0,
			Dungeon = 1
		}

		public static ReadOnlyDictionary<MapSize, Size> Sizes = new ReadOnlyDictionary<MapSize, Size>(
			new Dictionary<MapSize, Size>() {
				{ MapSize.w10h10, new Size(10, 10) },
				{ MapSize.w14h14, new Size(14, 14) },
				{ MapSize.w20h20, new Size(20, 20) },
				{ MapSize.w24h24, new Size(24, 24) },
				{ MapSize.w30h30, new Size(30, 30) },
				{ MapSize.w6h30, new Size(6, 30) },
				{ MapSize.w14h12, new Size(14, 12) }
			}
		);

		public static ReadOnlyDictionary<Map, MapInfo> Maps = new ReadOnlyDictionary<Map, MapInfo>(
			new Dictionary<Map, MapInfo>() {
				{ Map.Brecconary, new MapInfo(MapSize.w30h30, 0x726, TileSet.Town) },
				{ Map.Cantlin, new MapInfo(MapSize.w30h30, 0x8E8, TileSet.Town) },
				{ Map.CharlockCastleB1, new MapInfo(MapSize.w20h20, 0xDCA, TileSet.Dungeon) },
				{ Map.CharlockCastleB2, new MapInfo(MapSize.w10h10, 0xE92, TileSet.Dungeon) },
				{ Map.CharlockCastleB3, new MapInfo(MapSize.w10h10, 0xEC4, TileSet.Dungeon) },
				{ Map.CharlockCastleB4, new MapInfo(MapSize.w10h10, 0xEF6, TileSet.Dungeon) },
				{ Map.CharlockCastleB5, new MapInfo(MapSize.w10h10, 0xF28, TileSet.Dungeon) },
				{ Map.CharlockCastleB6, new MapInfo(MapSize.w10h10, 0xF5A, TileSet.Dungeon) },
				{ Map.CharlockCastleB7, new MapInfo(MapSize.w30h30, 0x444, TileSet.Town) },
				{ Map.CharlockCastleF1, new MapInfo(MapSize.w20h20, 0xC0, TileSet.Town) },
				{ Map.ErdricksCaveB1, new MapInfo(MapSize.w10h10, 0x12C0, TileSet.Dungeon) },
				{ Map.ErdricksCaveB2, new MapInfo(MapSize.w10h10, 0x12F2, TileSet.Dungeon) },
				{ Map.Garinham, new MapInfo(MapSize.w20h20, 0xAAA, TileSet.Town) },
				{ Map.GarinhamsGraveB1, new MapInfo(MapSize.w20h20, 0x10AA, TileSet.Dungeon) },
				{ Map.GarinhamsGraveB2, new MapInfo(MapSize.w14h12, 0x126C, TileSet.Dungeon) },
				{ Map.GarinhamsGraveB3, new MapInfo(MapSize.w20h20, 0x1172, TileSet.Dungeon) },
				{ Map.GarinhamsGraveB4, new MapInfo(MapSize.w10h10, 0x123A, TileSet.Dungeon) },
				{ Map.Hauksness, new MapInfo(MapSize.w20h20, 0x188, TileSet.Town) },
				{ Map.Kol, new MapInfo(MapSize.w24h24, 0x606, TileSet.Town) },
				{ Map.RainShrine, new MapInfo(MapSize.w10h10, 0xD66, TileSet.Town) },
				{ Map.RainbowShrine, new MapInfo(MapSize.w10h10, 0xD98, TileSet.Town) },
				{ Map.Rimuldar, new MapInfo(MapSize.w30h30, 0xB72, TileSet.Town) },
				{ Map.RockMountainB1, new MapInfo(MapSize.w14h14, 0xFE6, TileSet.Dungeon) },
				{ Map.RockMountainB2, new MapInfo(MapSize.w14h12, 0x1048, TileSet.Dungeon) },  // TODO: This is 14x14 in DWTAD
				{ Map.SwampCave, new MapInfo(MapSize.w6h30, 0xF8C, TileSet.Dungeon) },
				{ Map.TantegelCastleThroneRoom, new MapInfo(MapSize.w10h10, 0x412, TileSet.Town) },
				{ Map.TantegelCastleBasementSunlightShrine, new MapInfo(MapSize.w10h10, 0xD34, TileSet.Town) },
				{ Map.TantegelCastle, new MapInfo(MapSize.w30h30, 0x250, TileSet.Town) }
			}
		);

		public static ReadOnlyDictionary<Map, string> MapNames = new ReadOnlyDictionary<Map, string>(
			new Dictionary<Map, string>() {
				{ Map.Brecconary, "Brecconary" },
				{ Map.Cantlin, "Cantlin" },
				{ Map.CharlockCastleB1, "Charlock Castle - B1" },
				{ Map.CharlockCastleB2, "Charlock Castle - B2" },
				{ Map.CharlockCastleB3, "Charlock Castle - B3" },
				{ Map.CharlockCastleB4, "Charlock Castle - B4" },
				{ Map.CharlockCastleB5, "Charlock Castle - B5" },
				{ Map.CharlockCastleB6, "Charlock Castle - B6" },
				{ Map.CharlockCastleB7, "Charlock Castle - B7" },
				{ Map.CharlockCastleF1, "Charlock Castle - F1" },
				{ Map.ErdricksCaveB1, "Erdrick's Cave - B1" },
				{ Map.ErdricksCaveB2, "Erdrick's Cave - B2" },
				{ Map.Garinham, "Garinham" },
				{ Map.GarinhamsGraveB1, "Garinham Grave - B1" },
				{ Map.GarinhamsGraveB2, "Garinham Grave - B2" },
				{ Map.GarinhamsGraveB3, "Garinham Grave - B3" },
				{ Map.GarinhamsGraveB4, "Garinham Grave - B4" },
				{ Map.Hauksness, "Hauksness Ruins" },
				{ Map.Kol, "Kol" },
				{ Map.RainShrine, "Rain Shrine" },
				{ Map.RainbowShrine, "Rainbow Shrine" },
				{ Map.Rimuldar, "Rimuldar" },
				{ Map.RockMountainB1, "Rock Mountain Cave - B1" },
				{ Map.RockMountainB2, "Rock Mountain Cave - B2" },
				{ Map.SwampCave, "Swamp Cave" },
				{ Map.TantegelCastle, "Tantegel Castle" },
				{ Map.TantegelCastleBasementSunlightShrine, "Tantegel Castle - Basement - Sunlight Shrine" },
				{ Map.TantegelCastleThroneRoom, "Tantegel Castle - Throne Room" }
			}
		);
		
		public class MapInfo {
			// TODO: Currently doesn't deal with NOT FOUND
			// TODO: Maybe protect the constructor so only can be made here
			public Map Map {
				get {
					return Maps.First(x => x.Value == this).Key;
				}
			}

			public long Address { get; private set; }

			public TileSet TileSet { get; private set; }

			public Size Size { get; private set; }

			public int DataLength {
				get {
					return this.Size.Width * this.Size.Height / 2;
				}
			}

			public MapInfo(MapSize size, long address, TileSet tileSet) {
				this.Size = Sizes[size];
				this.Address = address;
				this.TileSet = tileSet;
			}
		}
	}
}
