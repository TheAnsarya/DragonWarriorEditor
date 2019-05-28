using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DragonWarriorEditor {
	public partial class MapForm : Form {
		private string Path { get; set; }

		private DataHandler _DataHandler;
		private DataHandler DataHandler {
			get {
				if (_DataHandler == null) {
					_DataHandler = new DataHandler(Path);
				}
				return _DataHandler;
			}
		}

		private List<PictureBox> Boxes;

		private Definition.Map CurrentMap;

		private Definition.MapInfo MapInfo {
			get {
				return Definition.Maps[CurrentMap];
			}
		}

		private static Dictionary<Definition.TileSet, Dictionary<byte, Image>> TileImages = new Dictionary<Definition.TileSet, Dictionary<byte, Image>>() {
			{
				Definition.TileSet.Town, new Dictionary<byte, Image>() {
					{ 0x00, Properties.Resources._0_grass },
					{ 0x01, Properties.Resources._1_desert },
					{ 0x02, Properties.Resources._2_water },
					{ 0x03, Properties.Resources._3_treasurechest },
					{ 0x04, Properties.Resources._4_solidstonewall2 },
					{ 0x05, Properties.Resources._5_stairsup },
					{ 0x06, Properties.Resources._6_redbrickfloor },
					{ 0x07, Properties.Resources._7_stairsdown },
					{ 0x08, Properties.Resources._8_forest },
					{ 0x09, Properties.Resources._9_poisonousswamp },
					{ 0x0A, Properties.Resources.a_barrier },
					{ 0x0B, Properties.Resources.b_lockeddoor },
					{ 0x0C, Properties.Resources.c_weaponshopsign },
					{ 0x0D, Properties.Resources.d_innsign },
					{ 0x0E, Properties.Resources.e_bridge },
					{ 0x0F, Properties.Resources.f_desk }
				}
			},
			{
				Definition.TileSet.Dungeon, new Dictionary<byte, Image>() {
					{ 0x00, Properties.Resources._0_crackedstonewall },
					{ 0x01, Properties.Resources._1_stairsup },
					{ 0x02, Properties.Resources._2_redbrickfloor },
					{ 0x03, Properties.Resources._3_stairsdown },
					{ 0x04, Properties.Resources._4_treasurechest },
					{ 0x05, Properties.Resources._5_lockeddoor },
					{ 0x06, Properties.Resources._6_princessgwaelin },
					{ 0x07, Properties.Resources._7_blackwall },
					{ 0x08, Properties.Resources._0_crackedstonewall_special },
					{ 0x09, Properties.Resources._1_stairsup_special },
					{ 0x0A, Properties.Resources._2_redbrickfloor_special },
					{ 0x0B, Properties.Resources._3_stairsdown_special },
					{ 0x0C, Properties.Resources._4_treasurechest_special },
					{ 0x0D, Properties.Resources._5_lockeddoor_special },
					{ 0x0E, Properties.Resources._6_princessgwaelin_special },
					{ 0x0F, Properties.Resources._7_blackwall_special }
				}
			}
		};

		private static Dictionary<Definition.TileSet, Dictionary<byte, string>> TileNames = new Dictionary<Definition.TileSet, Dictionary<byte, string>>() {
			{
				Definition.TileSet.Town, new Dictionary<byte, string>() {
					{ 0x00, "Grass" },
					{ 0x01, "Desert" },
					{ 0x02, "Water" },
					{ 0x03, "Treasure Chest" },
					{ 0x04, "Solid Stone" },
					{ 0x05, "Stairs Up" },
					{ 0x06, "Red Brick Floor" },
					{ 0x07, "Stairs Down" },
					{ 0x08, "Forest" },
					{ 0x09, "Poisonous Swamp" },
					{ 0x0A, "Barrier" },
					{ 0x0B, "Locked Door" },
					{ 0x0C, "Weapon Shop Sign" },
					{ 0x0D, "Inn Sign" },
					{ 0x0E, "Bridge" },
					{ 0x0F, "Desk" }
				}
			},
			{
				Definition.TileSet.Dungeon, new Dictionary<byte, string> {
					{ 0x00, "Solid Stone" },
					{ 0x01, "Stairs Up" },
					{ 0x02, "Red Brick Floor" },
					{ 0x03, "Stairs Down" },
					{ 0x04, "Treasure Chest" },
					{ 0x05, "Locked Door" },
					{ 0x06, "Princess Gwaelin" },
					{ 0x07, "Black Wall" },
					{ 0x08, "Solid Stone - Special" },
					{ 0x09, "Stairs Up - Special" },
					{ 0x0A, "Red Brick Floor - Special" },
					{ 0x0B, "Stairs Down - Special" },
					{ 0x0C, "Treasure Chest - Special" },
					{ 0x0D, "Locked Door - Special" },
					{ 0x0E, "Princess Gwaelin - Special" },
					{ 0x0F, "Black Wall - Special" }
				}
			}
		};

		public MapForm(string gamePath, Definition.Map currentMap) {
			Path = gamePath;
			CurrentMap = currentMap;
			InitializeComponent();
			PopulateComboBoxTileTypes();
			SetupLayout();
			SetupTilePalette();
		}

		private void loadMap() {
			string data = DataHandler.GetMapData(CurrentMap);
			Dictionary<byte, Image> tileset = TileImages[MapInfo.TileSet];

			int x = 1;
			bool hasError = false;

			foreach (char ch in data) {
				try {
					byte index = Convert.ToByte(ch.ToString(), 16);
					PictureBox box = Boxes[x];

					box.Image = tileset[index];
					box.Image.Tag = index;
					box.Refresh();
					box.SizeMode = PictureBoxSizeMode.StretchImage;
					box.Visible = true;

					x++;
				} catch (Exception ex) {
					hasError = true;
					break;
				}
			}

			if (hasError) {
				MessageBox.Show("Failed to populate map tiles. Try again. [" + x + "]", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				this.Close();
			}
		}

		private void SaveMap() {
			string data = "";
			for (int x = 1; x <= MapInfo.Dimension.Width * MapInfo.Dimension.Height; x++) {
				PictureBox box = Boxes[x];
				data += ((byte)box.Image.Tag).ToString("X");
			}

			bool result = DataHandler.SetMapData(CurrentMap, data);
			if (result) {
				MessageBox.Show("Successfully wrote ROM.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
			} else {
				MessageBox.Show("Failed to write ROM.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void PopulateComboBoxTileTypes() {
			comboBoxTileTypes.DataSource = new BindingSource(TileNames[MapInfo.TileSet], null);
			comboBoxTileTypes.DisplayMember = "Value";
			comboBoxTileTypes.ValueMember = "Key";
		}

		private void LoadMap(object sender, EventArgs e) {
			loadMap();
		}

		private void SetTile(object sender, EventArgs e) {
			if (sender is PictureBox) {
				byte index = (byte)comboBoxTileTypes.SelectedValue;
				PictureBox box = ((PictureBox)sender);

				box.Image = TileImages[MapInfo.TileSet][index];
				box.Image.Tag = index;
				box.Refresh();
				box.SizeMode = PictureBoxSizeMode.StretchImage;
				box.Visible = true;
			}
		}

		private void SetupLayout() {
			Boxes = new List<PictureBox>();
			Size size = new Size(24, 24);
			MapArea.Controls.Clear();

			for (int y = 0; y < MapInfo.Dimension.Height; y++) {
				for (int x = 0; x < MapInfo.Dimension.Width; x++) {
					PictureBox box = new PictureBox() {
						Location = new Point(6 + (x * 30), 19 + (y * 30)),
						Size = size
					};
					box.Click += new EventHandler(this.SetTile);

					Boxes.Add(box);
					MapArea.Controls.Add(box);
				}
			}
		}

		private void SetupTilePalette() {
			Dictionary<byte, Image> tileset = TileImages[MapInfo.TileSet];
			Size size = new Size(32, 32);
			TilePaletteArea.Controls.Clear();

			for (byte i = 0; i < tileset.Count; i++) {
				PictureBox box = new PictureBox() {
					Location = new Point(6, 10 + (i * 38)),
					Size = size,
					Image = tileset[i],
					Tag = i
				};
				box.Click += new EventHandler(this.TilePaletteButton_Click);

				TilePaletteArea.Controls.Add(box);
			}
		}

		private void TilePaletteButton_Click(object sender, EventArgs e) {
			PictureBox box = ((PictureBox)sender);
			comboBoxTileTypes.SelectedIndex = (byte)box.Tag;
		}

		private void buttonWriteROM_Click(object sender, EventArgs e) {
			SaveMap();
		}
	}
}
