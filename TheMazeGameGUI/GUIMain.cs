using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheMazeGameDLL;

namespace TheMazeGameGUI
{
    public partial class GUIMain : Form
    {
        private Player _steve;
        private Item _sword;
        private Item _bread;
        private Item _potion;
        private Item _torch;
        private Bag _backpack;
        private Location _cave;
        private Location _dungeon;
        private Path _caveNorth;
        private Path _dungeonSouth;
        private CommandProcessor _command;

        public GUIMain()
        {
            InitializeComponent();
            _steve = new Player("Steve", "The dude from minecraft!");
            _sword = new Item(new string[] { "sword", "blade" }, "sword", "This is a sharp blade than can cut through most materials.");
            _bread = new Item(new string[] { "bread" }, "bread", "A yummy warm bread made from 3 wheat");
            _potion = new Item(new string[] { "potion", "elixer" }, "potion", "A small glass flask containg a purple liquid... who knows what it does?!?");
            _torch = new Item(new string[] { "torch", "light" }, "torch", "A small handheld torch that can emit light if lit on fire");
            _backpack = new Bag(new string[] { "backpack", "bag" }, "backpack", "A useful bag that can be worn on your back");
            _cave = new Location(new string[] { "cave", "hole" }, "cave", "A dark gloomy cave that is bound to be dangerous, there appears to be an exit to the north");
            _dungeon = new Location(new string[] { "dungeon", "arena" }, "dungeon", "A dark room, it has loot but also dangerous enemies. There appears to be no more advancing paths");
            _caveNorth = new Path(new string[] { "north" }, "north", "You move through a tiny crack in the wall", _dungeon);
            _dungeonSouth = new Path(new string[] { "south" }, "south", "You move through a tiny crack in the wall", _cave);
            _command = new CommandProcessor();
            _steve.Location = _cave;
            _cave.AddPath(_caveNorth);
            _dungeon.AddPath(_dungeonSouth);
            _steve.Inventory.Put(_sword);
            _steve.Inventory.Put(_bread);
            _steve.Inventory.Put(_backpack);
            _backpack.Inventory.Put(_potion);
            _cave.Inventory.Put(_torch);
        }

        private void btnNorth_Click(object sender, EventArgs e)
        {
            txtGame.Text = _command.Execute(_steve, new string[] { "move", "north" });
        }

        private void btnEast_Click(object sender, EventArgs e)
        {
            txtGame.Text = _command.Execute(_steve, new string[] { "move", "east" });
        }

        private void btnSouth_Click(object sender, EventArgs e)
        {
            txtGame.Text = _command.Execute(_steve, new string[] { "move", "south" });
        }

        private void btnWest_Click(object sender, EventArgs e)
        {
            txtGame.Text = _command.Execute(_steve, new string[] { "move", "west" });
        }

        private void btnLook_Click(object sender, EventArgs e)
        {
            txtGame.Text = _command.Execute(_steve, new string[] { "look" });
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            string input = txtInput.Text;
            txtInput.Text = "";
            txtGame.Text = _command.Execute(_steve, input.Split(" "));
        }

        private void txtInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)13)
            {
                string input = txtInput.Text;
                txtInput.Text = "";
                txtGame.Text = _command.Execute(_steve, input.Split(" "));
            }
        }

        private void txtInput_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
