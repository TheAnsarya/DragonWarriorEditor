using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using static DragonWarriorEditor.Definition;

namespace DragonWarriorEditor {
	class DataHandler {
		private string Path { get; set; }

		public DataHandler(string gamePath) {
			this.Path = gamePath;
		}

		public string GetMapData(Map map) {
			MapInfo info = Definition.Maps[map];
			return this.getHexStringFromFile(info.Address, info.DataLength);
		}

		public bool SetMapData(Map map, string data) {
			MapInfo info = Definition.Maps[map];
			return this.writeByteArrayToFile(this.Path, info.Address, StringToByteArray(data));
		}

		private string getHexStringFromFile(long startPoint, int length) {
			StringBuilder hexString = new StringBuilder();
			using (FileStream fileStream = new FileStream(this.Path, FileMode.Open, FileAccess.Read)) {
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
			} catch {
				result = false;
			}

			return result;
		}
	}
}
