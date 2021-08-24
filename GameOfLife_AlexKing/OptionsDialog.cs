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
    public partial class OptionsDialog : Form
    {
        public int xAxis, yAxis, interval;
        public bool toroidal;
        public OptionsDialog(bool isToroidal, int intrvl, int x, int y)
        {
            InitializeComponent();
            toroidal = isToroidal;
            interval = intrvl;
            xAxis = x;
            yAxis = y;
            this.intervalNumericUpDown.Value = interval;
            this.xAxisNumericUpDown.Value = xAxis;
            this.yAxisNumericUpDown.Value = yAxis;

            if (toroidal == true)
            {
                boundaryComboBox.SelectedIndex = 0;
            }
            else boundaryComboBox.SelectedIndex = 1;
        }
        private void intervalNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            interval = (int)this.intervalNumericUpDown.Value;
        }

        private void xAxisNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            xAxis = (int)this.xAxisNumericUpDown.Value;
        }

        private void yAxisNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            yAxis = (int)this.yAxisNumericUpDown.Value;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (boundaryComboBox.SelectedIndex == 0)
            {
                toroidal = true;
            }
            else toroidal = false;
        }
    }
}
