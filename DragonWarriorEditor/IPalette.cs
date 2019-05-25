using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonWarriorEditor {
	interface IPalette {
		byte[] RawData { get; set; }

		Color[] Colors { get; }

		int Size { get; }

		bool ColorAllowed(Color color);
	}
}
