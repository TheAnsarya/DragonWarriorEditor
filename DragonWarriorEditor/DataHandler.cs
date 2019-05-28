using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using static DragonWarriorEditor.Definition;

namespace DragonWarriorEditor {
	class DataHandler {
		string path;

		public DataHandler(string gamePath) {
			this.path = gamePath;
		}

		public string GetMapData(Map map) {
			MapInfo info = Definition.Maps[map];
			return this.getHexStringFromFile(info.Address, info.DataLength);
		}

		public bool SetMapData(Map map, string data) {
			MapInfo info = Definition.Maps[map];
			return this.writeByteArrayToFile(this.path, info.Address, StringToByteArray(data));
		}

		public bool setTantegelCastleThroneRoomData(string roomData) {
			return this.writeByteArrayToFile(this.path, 0x412, StringToByteArray(roomData));
		}

		public bool setTantegelCastleBasementSunlightShrineData(string roomData) {
			return this.writeByteArrayToFile(this.path, 0xD35, StringToByteArray(roomData));
		}

		public bool setTantegelCastleData(string roomData) {
			return this.writeByteArrayToFile(this.path, 0x250, StringToByteArray(roomData));
		}

		public bool setRimuldarData(string roomData) {
			return this.writeByteArrayToFile(this.path, 0xB72, StringToByteArray(roomData));
		}

		public bool setCantlinData(string roomData) {
			return this.writeByteArrayToFile(this.path, 0x8E8, StringToByteArray(roomData));
		}

		public bool setBrecconaryData(string roomData) {
			return this.writeByteArrayToFile(this.path, 0x726, StringToByteArray(roomData));
		}

		public bool setKolData(string roomData) {
			return this.writeByteArrayToFile(this.path, 0x606, StringToByteArray(roomData));
		}

		public bool setSwampCaveData(string roomData) {
			return this.writeByteArrayToFile(this.path, 0xF8C, StringToByteArray(roomData));
		}

		public bool setRainShrineData(string roomData) {
			return this.writeByteArrayToFile(this.path, 0xD66, StringToByteArray(roomData));
		}

		public bool setRainbowShrineData(string roomData) {
			return this.writeByteArrayToFile(this.path, 0xD98, StringToByteArray(roomData));
		}

		public bool setErdricksCaveB1Data(string roomData) {
			return this.writeByteArrayToFile(this.path, 0x12C0, StringToByteArray(roomData));
		}

		public bool setErdricksCaveB2Data(string roomData) {
			return this.writeByteArrayToFile(this.path, 0x12F2, StringToByteArray(roomData));
		}

		public bool setGarinhamsGraveB1Data(string roomData) {
			return this.writeByteArrayToFile(this.path, 0x10AA, StringToByteArray(roomData));
		}

		public bool setGarinhamsGraveB2Data(string roomData) {
			return this.writeByteArrayToFile(this.path, 0x126C, StringToByteArray(roomData));
		}

		public bool setGarinhamsGraveB3Data(string roomData) {
			return this.writeByteArrayToFile(this.path, 0x1172, StringToByteArray(roomData));
		}

		public bool setGarinhamsGraveB4Data(string roomData) {
			return this.writeByteArrayToFile(this.path, 0x123A, StringToByteArray(roomData));
		}

		public bool setGarinhamData(string roomData) {
			return this.writeByteArrayToFile(this.path, 0xAAA, StringToByteArray(roomData));
		}

		public bool setCharlockCastleB1Data(string roomData) {
			return this.writeByteArrayToFile(this.path, 0xDCA, StringToByteArray(roomData));
		}

		public bool setCharlockCastleB2Data(string roomData) {
			return this.writeByteArrayToFile(this.path, 0xE92, StringToByteArray(roomData));
		}

		public bool setCharlockCastleB3Data(string roomData) {
			return this.writeByteArrayToFile(this.path, 0xEC4, StringToByteArray(roomData));
		}

		public bool setCharlockCastleB4Data(string roomData) {
			return this.writeByteArrayToFile(this.path, 0xEF6, StringToByteArray(roomData));
		}

		public bool setCharlockCastleB5Data(string roomData) {
			return this.writeByteArrayToFile(this.path, 0xF28, StringToByteArray(roomData));
		}

		public bool setCharlockCastleB6Data(string roomData) {
			return this.writeByteArrayToFile(this.path, 0xF5A, StringToByteArray(roomData));
		}

		public bool setCharlockCastleB7Data(string roomData) {
			return this.writeByteArrayToFile(this.path, 0x444, StringToByteArray(roomData));
		}

		public bool setCharlockCastleF1Data(string roomData) {
			return this.writeByteArrayToFile(this.path, 0xC0, StringToByteArray(roomData));
		}

		public bool setHauksnessData(string roomData) {
			return this.writeByteArrayToFile(this.path, 0x188, StringToByteArray(roomData));
		}

		public bool setRockMountainB1Data(string roomData) {
			return this.writeByteArrayToFile(this.path, 0xFE6, StringToByteArray(roomData));
		}

		public bool setRockMountainB2Data(string roomData) {
			return this.writeByteArrayToFile(this.path, 0x1048, StringToByteArray(roomData));
		}

		#region common methods
		private static string convertAsciiToHex(String asciiString) {
			char[] charValues = asciiString.ToCharArray();
			string hexValue = "";
			foreach (char c in charValues) {
				int value = Convert.ToInt32(c);
				hexValue += String.Format("{0:X}", value);
			}
			return hexValue;
		}

		private static string convertHexToAscii(String hexString) {
			try {
				string ascii = string.Empty;

				for (int i = 0; i < hexString.Length; i += 2) {
					String hs = string.Empty;

					hs = hexString.Substring(i, 2);
					uint decval = System.Convert.ToUInt32(hs, 16);
					char character = System.Convert.ToChar(decval);
					ascii += character;

				}

				return ascii;
			} catch (Exception ex) {
				// Console.WriteLine(ex.Message);
			}

			return string.Empty;
		}

		private string getHexStringFromFile(long startPoint, int length) {
			StringBuilder hexString = new StringBuilder();
			using (FileStream fileStream = new FileStream(this.@path, FileMode.Open, FileAccess.Read)) {
				long offset = fileStream.Seek(startPoint, SeekOrigin.Begin);

				for (int x = 0; x < length; x++) {
					hexString.Append(fileStream.ReadByte().ToString("X2"));
				}
			}

			return hexString.ToString();
		}

		private static byte[] StringToByteArray(string hex) {
			return Enumerable.Range(0, hex.Length)
							 .Where(x => x % 2 == 0)
							 .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
							 .ToArray();
		}

		private bool writeByteArrayToFile(string fileName, long startPoint, byte[] byteArray) {
			bool result = false;
			try {
				using (var fs = new FileStream(fileName, FileMode.Open, FileAccess.ReadWrite)) {
					fs.Position = startPoint;
					fs.Write(byteArray, 0, byteArray.Length);
					result = true;
				}
			} catch (Exception ex) {
				// Console.WriteLine("Error writing file: {0}", ex);
				result = false;
			}

			return result;
		}
		#endregion
	}
}
