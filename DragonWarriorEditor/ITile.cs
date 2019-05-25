using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonWarriorEditor {
	interface ITile {

		byte[] RawData { get; set; }

		Size Size { get; set; }

		// TODO: FIgure out live updates but with caching
		Image AsImage();
	}
}
