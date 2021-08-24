using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace GameOfLife_AlexKing
{


    public partial class GOL : Form
    {
        struct cell
        {
            public bool isOn;
            public int liveNeighborCount;
        }

        //Various settings
        Random rand = new Random();
        int seed = 44;
        bool toroidalUniverse = true;
        bool gridOn = true;
        bool HUDon = true;
        bool neighborCountOn = true;

        // The universe array
        cell[,] universe = new cell[30, 30];
        cell[,] scratchPad = new cell[30, 30];

        // Drawing colors
        Color gridColor = Color.Black;
        Color cellColor = Color.DarkGray;

        // The Timer class
        Timer timer = new Timer();

        // Generation count
        ushort generations = 0;
        ushort cellsAlive = 0;

        public GOL()
        {
            InitializeComponent();

            // Setup the timer
            timer.Interval = 100; // milliseconds
            timer.Tick += Timer_Tick;
            timer.Enabled = false; // start timer running
        }

        // Calculate the next generation of cells
        private void NextGeneration()
        {
            cell[,] tmp = universe;
            scratchPad = tmp;
            for (int y = 0; y < universe.GetLength(1); y++)
            {
                for (int x = 0; x < universe.GetLength(0); x++)
                {
                    if (((universe[x, y].liveNeighborCount == 2 || tmp[x, y].liveNeighborCount == 3) && tmp[x, y].isOn == true) || (tmp[x, y].liveNeighborCount == 3 && tmp[x, y].isOn == false))
                    {
                        scratchPad[x, y].isOn = true;
                    }

                    if (tmp[x, y].liveNeighborCount < 2 || tmp[x, y].liveNeighborCount > 3)
                    {
                        scratchPad[x, y].isOn = false;
                        cellsAlive--;
                    }
                    scratchPad[x, y].liveNeighborCount = CountNeighborsToroidal(x, y, tmp);
                }
            }

            universe = scratchPad;

            // Increment generation count
            generations++;

            // Update status strip generations
            toolStripStatusLabelGenerations.Text = "Generations = " + generations.ToString();

            graphicsPanel1.Invalidate();
        }

        // The event called by the timer every Interval milliseconds.
        private void Timer_Tick(object sender, EventArgs e)
        {
            NextGeneration();
        }

        private void graphicsPanel1_Paint(object sender, PaintEventArgs e)
        {
            // Calculate the width and height of each cell in pixels
            // CELL WIDTH = WINDOW WIDTH / NUMBER OF CELLS IN X
            float cellWidth = graphicsPanel1.ClientSize.Width / (float)universe.GetLength(0);
            // CELL HEIGHT = WINDOW HEIGHT / NUMBER OF CELLS IN Y
            float cellHeight = graphicsPanel1.ClientSize.Height / (float)universe.GetLength(1);

            // A Pen for drawing the grid lines (color, width)
            Pen gridPen = new Pen(gridColor, 1);

            // A Brush for filling living cells interiors (color)
            Brush cellBrush = new SolidBrush(cellColor);
            Brush numberBrush = new SolidBrush(Color.Black);


            //Font format for neighborCount
            Font font = new Font("Courier New", 10);
            StringFormat strFormat = new StringFormat();
            strFormat.LineAlignment = StringAlignment.Center;
            strFormat.Alignment = StringAlignment.Center;

            // Iterate through the universe in the y, top to bottom
            for (int y = 0; y < universe.GetLength(1); y++)
            {
                // Iterate through the universe in the x, left to right
                for (int x = 0; x < universe.GetLength(0); x++)
                {
                    if (toroidalUniverse == true)
                    {
                        universe[x, y].liveNeighborCount = CountNeighborsToroidal(x, y, universe);
                    } else universe[x, y].liveNeighborCount = CountNeighborsFinite(x, y, universe);

                    // A rectangle to represent each cell in pixels
                    RectangleF cellRect = RectangleF.Empty;
                    cellRect.X = x * cellWidth;
                    cellRect.Y = y * cellHeight;
                    cellRect.Width = cellWidth;
                    cellRect.Height = cellHeight;

                    // Fill the cell with a brush if alive
                    if (universe[x, y].isOn == true)
                    {
                        e.Graphics.FillRectangle(cellBrush, cellRect);
                    }

                    // Outline the cell with a pen
                    if (gridOn == true)
                    {
                        e.Graphics.DrawRectangle(gridPen, cellRect.X, cellRect.Y, cellRect.Width, cellRect.Height);
                    }

                    //Pen color changes for cells to be alive next gen(green) or die/wont be alive yet(if not populated) next gen(red)
                    if (((universe[x, y].liveNeighborCount == 2 || universe[x, y].liveNeighborCount == 3) && universe[x, y].isOn == true) || (universe[x, y].liveNeighborCount == 3 && universe[x, y].isOn == false))
                    {
                        numberBrush = new SolidBrush(Color.Green);
                    }
                    else numberBrush = new SolidBrush(Color.Red);

                    if (neighborCountOn == true)
                    {
                        if (universe[x, y].liveNeighborCount > 0)
                        {
                            //Debug.WriteLine(universe[x, y].liveNeighborCount);    //to make sure neighborCount is being counted properly
                            e.Graphics.DrawString(universe[x, y].liveNeighborCount.ToString(), font, numberBrush, cellRect, strFormat);
                        }
                    }
                }
            }

            //Total cell count
            cellsAlive = 0;
            for (int y = 0; y < universe.GetLength(1); y++)
            {
                for (int x = 0; x < universe.GetLength(0); x++)
                {
                    if (universe[x, y].isOn == true)
                    {
                        cellsAlive++;
                    }
                }
            }

            //x10 line drawings
            if (gridOn == true)
            {
                for (int i = 1; i < universe.GetLength(0); i++)
                {
                    if (i % 10 == 0)
                    {
                        gridPen.Width = 2;
                        e.Graphics.DrawLine(gridPen, i * cellWidth, 0, i * cellWidth, graphicsPanel1.ClientSize.Height);
                        e.Graphics.DrawLine(gridPen, 0, i * cellHeight, graphicsPanel1.ClientSize.Width, i * cellHeight);
                    }
                }
                gridPen.Width = 1;
            }

            //toolStrip labels
            toolStripStatusLabelcellsAlive.Text = "Cells Alive = " + cellsAlive.ToString();
            toolStripStatusLabelTorodial.Text = "Toridial Boundary = " + toroidalUniverse.ToString();
            toolStripStatusLabelSeed.Text = "Seed = " + seed.ToString();

            // Cleaning up pens and brushes
            gridPen.Dispose();
            cellBrush.Dispose();
            numberBrush.Dispose();
        }

        private void graphicsPanel1_MouseClick(object sender, MouseEventArgs e)
        {
            // If the left mouse button was clicked
            if (e.Button == MouseButtons.Left)
            {
                // Calculate the width and height of each cell in pixels
                float cellWidth = graphicsPanel1.ClientSize.Width / (float)universe.GetLength(0);
                float cellHeight = graphicsPanel1.ClientSize.Height / (float)universe.GetLength(1);

                // Calculate the cell that was clicked in
                // CELL X = MOUSE X / CELL WIDTH
                int x = (int)(e.X / cellWidth);
                // CELL Y = MOUSE Y / CELL HEIGHT
                int y = (int)(e.Y / cellHeight);

                // Toggle the cell's state
                universe[x, y].isOn = !universe[x, y].isOn;

                // Tell Windows you need to repaint
                graphicsPanel1.Invalidate();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UniverseReset()
        {
            for (int y = 0; y < universe.GetLength(1); y++)
            {
                for (int x = 0; x < universe.GetLength(0); x++)
                {
                    universe[x, y].isOn = false;
                    universe[x, y].liveNeighborCount = 0;
                }
            }
        }


        //++++++++++++++++++++++++++NEIGHBOR COUNT FUNCTIONS++++++++++++++++++++++++++
        private int CountNeighborsToroidal(int x, int y, cell[,] focus)
        {
            int count = 0;
            int xLen = universe.GetLength(0);
            int yLen = universe.GetLength(1);

            for (int yOffset = -1; yOffset <= 1; yOffset++)
            {
                for (int xOffset = -1; xOffset <= 1; xOffset++)
                {
                    int xCheck = x + xOffset;
                    int yCheck = y + yOffset;

                    if (xOffset == 0 && yOffset == 0)
                    {
                        continue;
                    }

                    if (xCheck < 0)
                    {
                        xCheck = xLen - 1;
                    }

                    if (yCheck < 0)
                    {
                        yCheck = yLen - 1;
                    }

                    if (xCheck >= xLen)
                    {
                        xCheck = 0;
                    }

                    if (yCheck >= yLen)
                    {
                        yCheck = 0;
                    }
                    if (focus[xCheck, yCheck].isOn == true) count++;
                }
            }
            return count;
        }

        private int CountNeighborsFinite(int x, int y, cell[,] focus)
        {
            int count = 0;
            int xLen = universe.GetLength(0);
            int yLen = universe.GetLength(1);

            for (int yOffset = -1; yOffset <= 1; yOffset++)
            {
                for (int xOffset = -1; xOffset <= 1; xOffset++)
                {
                    int xCheck = x + xOffset;
                    int yCheck = y + yOffset;

                    if ((xOffset == 0 && yOffset == 0) || (xCheck < 0) || (yCheck < 0) || (xCheck >= xLen) || (yCheck >= yLen))
                    {
                        continue;
                    }

                    if (focus[xCheck, yCheck].isOn == true) count++;
                }
            }
            return count;
        }

        //++++++++++++++++++++++++++TOOL STRIP BUTTONS++++++++++++++++++++++++++
        private void GridClear_Click(object sender, EventArgs e)
        {
            timer.Stop();
            UniverseReset();
            generations = 0;
            cellsAlive = 0;
            toolStripStatusLabelGenerations.Text = "Generations = " + generations.ToString();
            toolStripStatusLabelcellsAlive.Text = "Cells Alive = " + cellsAlive.ToString();
            toolStripStatusLabelTorodial.Text = "Toridial Boundary = " + toroidalUniverse.ToString();
            toolStripStatusLabelSeed.Text = "Seed = " + seed.ToString();
            graphicsPanel1.Invalidate();
        }
        //pause
        private void Pause_Click(object sender, EventArgs e)
        {
            timer.Stop();
        }

        //play
        private void Play_Click(object sender, EventArgs e)
        {
            timer.Start();
        }

        //next gen
        private void NextGen_Click(object sender, EventArgs e)
        {
            NextGeneration();
        }
        private void doubleSpeedButton_Click(object sender, EventArgs e)
        {
            timer.Interval *= 2;
        }

        //++++++++++++++++++++++++++VIEW FUNCTIONS++++++++++++++++++++++++++
        private void gridToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gridToolStripMenuItem.Checked = !gridToolStripMenuItem.Checked;
            gridOn = gridToolStripMenuItem.Checked;
            graphicsPanel1.Invalidate();
        }

        private void neighborCountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            neighborCountToolStripMenuItem.Checked = !neighborCountToolStripMenuItem.Checked;
            neighborCountOn = neighborCountToolStripMenuItem.Checked;
            graphicsPanel1.Invalidate();
        }

        private void hUDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hUDToolStripMenuItem.Checked = !hUDToolStripMenuItem.Checked;
            HUDon = hUDToolStripMenuItem.Checked;
            graphicsPanel1.Invalidate();
        }

        //++++++++++++++++++++++++++RANDOMIZATION FUNCTIONS++++++++++++++++++++++++++
        private void randomUniverse()
        {
            UniverseReset();
            for (int y = 0; y < universe.GetLength(1); y++)
            {
                for (int x = 0; x < universe.GetLength(0); x++)
                {
                    if (rand.Next() % 2 == 0)
                    {
                        universe[x, y].isOn = true;
                    }
                }
            }
            graphicsPanel1.Invalidate();
        }

        private void bySeedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RandomSeedDialog rsd = new RandomSeedDialog(seed);

            if (DialogResult.OK == rsd.ShowDialog())
            {
                rand = new Random(rsd.seed);
                seed = rsd.seed;
                randomUniverse();
            }
        }

        private void byTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rand = new Random();
            randomUniverse();
        }

        //++++++++++++++++++++++++++COLOR CHANGE FUNCTIONS++++++++++++++++++++++++++
        private void backgroundColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();

            cd.Color = graphicsPanel1.BackColor;

            if (DialogResult.OK == cd.ShowDialog())
            {
                graphicsPanel1.BackColor = cd.Color;
            }
        }

        private void cellColorToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();

            cd.Color = cellColor;
            cd.CustomColors = new int[] { ColorTranslator.ToOle(cellColor) };

            if (DialogResult.OK == cd.ShowDialog())
            {
                cellColor = cd.Color;
            }
            graphicsPanel1.Invalidate();
        }

        private void gridColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();

            cd.Color = gridColor;

            if (DialogResult.OK == cd.ShowDialog())
            {
                gridColor = cd.Color;
            }
            graphicsPanel1.Invalidate();
        }

        //Options menu
        private void optionsToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            int xAxis = universe.GetLength(0);
            int yAxis = universe.GetLength(1);
            OptionsDialog od = new OptionsDialog(toroidalUniverse, timer.Interval, universe.GetLength(0), universe.GetLength(1));

            if (DialogResult.OK == od.ShowDialog())
            {
                if (xAxis != od.xAxis || yAxis != od.yAxis)
                {
                    universe = new cell[od.xAxis, od.yAxis];
                    scratchPad = new cell[od.xAxis, od.yAxis];
                }
                timer.Interval = od.interval;
                toroidalUniverse = od.toroidal;
            }
            graphicsPanel1.Invalidate();
        }
    }
}