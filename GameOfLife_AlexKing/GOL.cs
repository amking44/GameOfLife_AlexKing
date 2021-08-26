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
using System.IO;

namespace GameOfLife_AlexKing
{


    public partial class GOLForm : Form
    {
        struct cell
        {
            public bool isOn;
            public int liveNeighborCount;
        }

        //Various settings
        int seed, univX, univY, timeInt;
        Random rand = new Random();
        bool toroidalUniverse = true;
        bool gridOn = true;
        bool HUDon = true;
        bool neighborCountOn = true;
        bool tenGridOn = true;

        // The universe array
        cell[,] universe;
        cell[,] scratchPad;

        // Drawing colors
        Color gridColor, cellColor, backgroundColor, tenGridColor;

        // The Timer class
        Timer timer = new Timer();

        // Generation count
        ushort generations = 0;
        ushort cellsAlive = 0;

        public GOLForm()
        {
            InitializeComponent();

            timeInt = Properties.Settings.Default.timerInterval;
            seed = Properties.Settings.Default.seed;
            tenGridColor = Properties.Settings.Default.tenGridColor;
            gridColor = Properties.Settings.Default.gridColor;
            cellColor = Properties.Settings.Default.cellColor;
            backgroundColor = Properties.Settings.Default.backgroundColor;
            univX = Properties.Settings.Default.universeX;
            univY = Properties.Settings.Default.universeY;
            universe = new cell[univX, univY];
            scratchPad = new cell[univX, univY];
            graphicsPanel1.BackColor = backgroundColor;
            // Setup the timer
            timer.Interval = timeInt; // milliseconds
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

            //Setting universe to updated universe(scratchPad)
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
            Pen tenGridPen = new Pen(tenGridColor, 2);

            // A Brush for filling living cells interiors (color)
            Brush cellBrush = new SolidBrush(cellColor);
            Brush numberBrush = new SolidBrush(Color.Black);
            Brush textBrush = new SolidBrush(Color.FromArgb(128, Color.Red));


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
            if (tenGridOn == true)
            {
                for (int i = 1; i < universe.GetLength(0); i++)
                {
                    if (i % 10 == 0)
                    {
                        e.Graphics.DrawLine(tenGridPen, i * cellWidth, 0, i * cellWidth, graphicsPanel1.ClientSize.Height);
                        e.Graphics.DrawLine(tenGridPen, 0, i * cellHeight, graphicsPanel1.ClientSize.Width, i * cellHeight);
                    }
                }
            }

            //HUD drawing
            if (HUDon == true)
            {
                Font hudFont = new Font("Courier", 20);
                StringFormat stringFormat = new StringFormat();
                stringFormat.Alignment = StringAlignment.Near;
                stringFormat.LineAlignment = StringAlignment.Far;

                string hud = "Generation = " + generations + "\nInterval = " + timeInt + " ms/generation\nCells Alive = " + cellsAlive + "\nToroidal universe = " + toroidalUniverse.ToString() + "\nUniverse Size = [" + univX + ", " + univY + "]"; 

                e.Graphics.DrawString(hud, hudFont, textBrush, graphicsPanel1.ClientRectangle, stringFormat);
            }

            //toolStrip labels
            toolStripStatusLabelcellsAlive.Text = "Cells Alive = " + cellsAlive.ToString();
            toolStripStatusLabelTorodial.Text = "Toridial Boundary = " + toroidalUniverse.ToString();
            toolStripStatusLabelSeed.Text = "Seed = " + seed.ToString();

            // Cleaning up pens and brushes
            gridPen.Dispose();
            tenGridPen.Dispose();
            cellBrush.Dispose();
            numberBrush.Dispose();
            textBrush.Dispose();
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
            if (timeInt <= 1)
            {
                return;
            }
            timeInt /= 2;
            timer.Interval = timeInt;
            graphicsPanel1.Invalidate();
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
        private void tenGridToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tenGridToolStripMenuItem.Checked = !tenGridToolStripMenuItem.Checked;
            tenGridOn = tenGridToolStripMenuItem.Checked;
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
        private void byCurrentSeedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rand = new Random(seed);
            randomUniverse();
        }

        private void byTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            seed = Environment.TickCount;
            rand = new Random(seed);
            randomUniverse();
        }

        //++++++++++++++++++++++++++SETTINGS FUNCTIONS++++++++++++++++++++++++++
        private void backgroundColorToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            BackgroundColor();
        }

        private void cellColorToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            CellColor();
        }

        private void gridColorToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            GridColor();
        }

        //Context Menu Selections
        private void backgroundColorToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            BackgroundColor();
        }

        private void cellColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CellColor();
        }

        private void gridColorToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            GridColor();
        }

        //Color Functions
        private void BackgroundColor()
        {
            ColorDialog cd = new ColorDialog();

            cd.Color = graphicsPanel1.BackColor;

            if (DialogResult.OK == cd.ShowDialog())
            {
                backgroundColor = cd.Color;
                graphicsPanel1.BackColor = backgroundColor;
            }
        }

        private void CellColor()
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

        private void GridColor()
        {
            ColorDialog cd = new ColorDialog();

            cd.Color = gridColor;

            if (DialogResult.OK == cd.ShowDialog())
            {
                gridColor = cd.Color;
            }
            graphicsPanel1.Invalidate();
        }

        private void tenGridColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();

            cd.Color = tenGridColor;

            if (DialogResult.OK == cd.ShowDialog())
            {
                tenGridColor = cd.Color;
            }
            graphicsPanel1.Invalidate();
        }

        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Reset();
            seed = Properties.Settings.Default.seed;
            gridColor = Properties.Settings.Default.gridColor;
            tenGridColor = Properties.Settings.Default.tenGridColor;
            cellColor = Properties.Settings.Default.cellColor;
            backgroundColor = Properties.Settings.Default.backgroundColor;
            univX = Properties.Settings.Default.universeX;
            univY = Properties.Settings.Default.universeY;
            universe = new cell[univX, univY];
            scratchPad = new cell[univX, univY];
            graphicsPanel1.BackColor = backgroundColor;
            timeInt = Properties.Settings.Default.timerInterval; // milliseconds
            graphicsPanel1.Invalidate();
        }

        private void reloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Reload();
            seed = Properties.Settings.Default.seed;
            gridColor = Properties.Settings.Default.gridColor;
            tenGridColor = Properties.Settings.Default.tenGridColor;
            cellColor = Properties.Settings.Default.cellColor;
            backgroundColor = Properties.Settings.Default.backgroundColor;
            univX = Properties.Settings.Default.universeX;
            univY = Properties.Settings.Default.universeY;
            universe = new cell[univX, univY];
            scratchPad = new cell[univX, univY];
            graphicsPanel1.BackColor = backgroundColor;
            timeInt = Properties.Settings.Default.timerInterval; // milliseconds
            graphicsPanel1.Invalidate();
        }

        //Options menu
        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int xAxis = universe.GetLength(0);
            int yAxis = universe.GetLength(1);
            OptionsDialog od = new OptionsDialog(toroidalUniverse, timeInt, universe.GetLength(0), universe.GetLength(1));

            if (DialogResult.OK == od.ShowDialog())
            {
                if (xAxis != od.xAxis || yAxis != od.yAxis)
                {
                    univX = od.xAxis;
                    univY = od.yAxis;
                    universe = new cell[univX, univY];
                    scratchPad = new cell[univX, univY];
                }
                timeInt = od.interval;
                timer.Interval = timeInt;
                toroidalUniverse = od.toroidal;
            }
            graphicsPanel1.Invalidate();
        }

        //++++++++++++++++++++++++++OPEN/SAVE FUNCTIONS++++++++++++++++++++++++++
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "All Files|*.*|Cells|*.cells";
            dlg.FilterIndex = 2;

            if (DialogResult.OK == dlg.ShowDialog())
            {
                StreamReader reader = new StreamReader(dlg.FileName);

                // Create a couple variables to calculate the width and height
                // of the data in the file.
                int maxWidth = 0;
                int maxHeight = 0;
                int y = 0;

                // Iterate through the file once to get its size.
                while (!reader.EndOfStream)
                {
                    // Read one row at a time.
                    string row = reader.ReadLine();

                    // If the row begins with '!' then it is a comment
                    // and should be ignored.
                    if (row[0] == '!')
                    {
                        continue;
                    }
                    // If the row is not a comment then it is a row of cells.
                    // Increment the maxHeight variable for each row read.
                    // Get the length of the current row string
                    // and adjust the maxWidth variable if necessary.
                    else
                    {
                        maxHeight++;
                        maxWidth = row.Length;
                    }
                }

                // Resize the current universe and scratchPad
                // to the width and height of the file calculated above.
                universe = new cell[maxWidth, maxHeight];

                // Reset the file pointer back to the beginning of the file.
                reader.BaseStream.Seek(0, SeekOrigin.Begin);

                // Iterate through the file again, this time reading in the cells.
                while (!reader.EndOfStream)
                {
                    // Read one row at a time.
                    string row = reader.ReadLine();

                    // If the row begins with '!' then
                    // it is a comment and should be ignored.
                    if (row[0] == '!')
                    {
                        continue;
                    }
                    else
                    {
                        // If the row is not a comment then 
                        // it is a row of cells and needs to be iterated through.
                        for (int xPos = 0; xPos < row.Length; xPos++)
                        {
                            // If row[xPos] is a 'O' (capital O) then cell == alive
                            // If row[xPos] is a '.' (period) then cell == dead
                            if (row[xPos] == 'O')
                            {
                                universe[xPos, y].isOn = true;
                            }
                            else if (row[xPos] == '.')
                            {
                                universe[xPos, y].isOn = false;
                            }
                        }
                        y++;
                    }
                }
                // Close the file.
                reader.Close();
                graphicsPanel1.Invalidate();
            }
        }

        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "All Files|*.*|Cells|*.cells";
            dlg.FilterIndex = 2;

            if (DialogResult.OK == dlg.ShowDialog())
            {
                StreamReader reader = new StreamReader(dlg.FileName);

                // Create a couple variables to calculate the width and height
                // of the data in the file.
                int y = 0;

                // Reset the file pointer back to the beginning of the file.
                reader.BaseStream.Seek(0, SeekOrigin.Begin);

                // Iterate through the file again, this time reading in the cells.
                while (y < universe.GetLength(1))
                {
                    // Read one row at a time.
                    string row = reader.ReadLine();

                    // If the row begins with '!' then
                    // it is a comment and should be ignored.
                    if (row[0] == '!')
                    {
                        continue;
                    }
                    else
                    {
                        // If the row is not a comment then 
                        // it is a row of cells and needs to be iterated through.
                        for (int xPos = 0; xPos < universe.GetLength(0); xPos++)
                        {
                            // If row[xPos] is a 'O' (capital O) then cell == alive
                            // If row[xPos] is a '.' (period) then cell == dead
                            if (row[xPos] == 'O')
                            {
                                universe[xPos, y].isOn = true;
                            }
                            else if (row[xPos] == '.')
                            {
                                universe[xPos, y].isOn = false;
                            }
                        }
                        y++;
                    }
                }
                // Close the file.
                reader.Close();
                graphicsPanel1.Invalidate();
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "All Files|*.*|Cells|*.cells";
            dlg.FilterIndex = 2; dlg.DefaultExt = "cells";


            if (DialogResult.OK == dlg.ShowDialog())
            {
                StreamWriter writer = new StreamWriter(dlg.FileName);

                // Write any comments you want to include first.
                // Prefix all comment strings with an exclamation point.
                // Use WriteLine to write the strings to the file. 
                writer.WriteLine("!This is my comment.");

                // Iterate through the universe one row at a time.
                for (int y = 0; y < universe.GetLength(1); y++)
                {
                    // Create a string to represent the current row.
                    String currentRow = string.Empty;

                    // Iterate through the current row one cell at a time.
                    for (int x = 0; x < universe.GetLength(0); x++)
                    {
                        // If the universe[x,y] is alive then append 'O' (capital O)
                        // Else if the universe[x,y] is dead then append '.' (period)
                        if (universe[x, y].isOn == true)
                        {
                            currentRow += 'O';
                        }
                        else if (universe[x, y].isOn == false)
                        {
                            currentRow += '.';
                        }
                    }
                    // Once the current row has been read through and the 
                    // string constructed then write it to the file using WriteLine.
                    writer.WriteLine(currentRow);
                }

                // After all rows and columns have been written then close the file.
                writer.Close();
            }
            graphicsPanel1.Invalidate();
        }

        //Closing function, updates all settings
        private void GOLForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Properties.Settings.Default.timerInterval = timeInt;
            Properties.Settings.Default.seed = seed;
            Properties.Settings.Default.gridColor = gridColor;
            Properties.Settings.Default.tenGridColor = tenGridColor;
            Properties.Settings.Default.cellColor = cellColor;
            Properties.Settings.Default.backgroundColor = backgroundColor;
            Properties.Settings.Default.universeX = univX;
            Properties.Settings.Default.universeY = univY;
            Properties.Settings.Default.Save();
        }
    }
}