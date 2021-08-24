using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameOfLife_AlexKing
{
    public partial class RandomSeedDialog : Form
    {
        public int seed;
        public RandomSeedDialog()
        {
            InitializeComponent();
            this.Seed.Value = seed;
        }

        public RandomSeedDialog(int currentSeed)
        {
            InitializeComponent();
            seed = currentSeed;
            this.Seed.Value = seed;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random rand = new Random();
            seed = rand.Next();
            this.Seed.Value = seed;
        }

        private void Seed_ValueChanged(object sender, EventArgs e)
        {
            seed = (int)this.Seed.Value;
        }
    }
}
