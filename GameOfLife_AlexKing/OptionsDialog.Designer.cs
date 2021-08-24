
namespace GameOfLife_AlexKing
{
    partial class OptionsDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.OK = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.intervalNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.xAxisNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.yAxisNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.boundaryComboBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.intervalNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xAxisNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yAxisNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // OK
            // 
            this.OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OK.Location = new System.Drawing.Point(148, 200);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(75, 23);
            this.OK.TabIndex = 0;
            this.OK.Text = "OK";
            this.OK.UseVisualStyleBackColor = true;
            // 
            // Cancel
            // 
            this.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel.Location = new System.Drawing.Point(229, 200);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(75, 23);
            this.Cancel.TabIndex = 1;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            // 
            // intervalNumericUpDown
            // 
            this.intervalNumericUpDown.Location = new System.Drawing.Point(109, 30);
            this.intervalNumericUpDown.Maximum = new decimal(new int[] {
            -1981284352,
            -1966660860,
            0,
            0});
            this.intervalNumericUpDown.Name = "intervalNumericUpDown";
            this.intervalNumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.intervalNumericUpDown.TabIndex = 4;
            this.intervalNumericUpDown.ValueChanged += new System.EventHandler(this.intervalNumericUpDown_ValueChanged);
            // 
            // xAxisNumericUpDown
            // 
            this.xAxisNumericUpDown.Location = new System.Drawing.Point(109, 56);
            this.xAxisNumericUpDown.Name = "xAxisNumericUpDown";
            this.xAxisNumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.xAxisNumericUpDown.TabIndex = 5;
            this.xAxisNumericUpDown.ValueChanged += new System.EventHandler(this.xAxisNumericUpDown_ValueChanged);
            // 
            // yAxisNumericUpDown
            // 
            this.yAxisNumericUpDown.Location = new System.Drawing.Point(109, 82);
            this.yAxisNumericUpDown.Name = "yAxisNumericUpDown";
            this.yAxisNumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.yAxisNumericUpDown.TabIndex = 6;
            this.yAxisNumericUpDown.ValueChanged += new System.EventHandler(this.yAxisNumericUpDown_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Interval";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(55, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "X-Axis";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(55, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Y-Axis";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Boundary Type";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(236, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "(milliseconds)";
            // 
            // boundaryComboBox
            // 
            this.boundaryComboBox.DisplayMember = "Torodial";
            this.boundaryComboBox.FormattingEnabled = true;
            this.boundaryComboBox.Items.AddRange(new object[] {
            "Toroidal",
            "Finite"});
            this.boundaryComboBox.Location = new System.Drawing.Point(109, 123);
            this.boundaryComboBox.Name = "boundaryComboBox";
            this.boundaryComboBox.Size = new System.Drawing.Size(121, 21);
            this.boundaryComboBox.TabIndex = 12;
            this.boundaryComboBox.ValueMember = "Toroidal";
            this.boundaryComboBox.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // OptionsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(316, 235);
            this.Controls.Add(this.boundaryComboBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.yAxisNumericUpDown);
            this.Controls.Add(this.xAxisNumericUpDown);
            this.Controls.Add(this.intervalNumericUpDown);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.OK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "OptionsDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Options";
            ((System.ComponentModel.ISupportInitialize)(this.intervalNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xAxisNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yAxisNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OK;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.NumericUpDown intervalNumericUpDown;
        private System.Windows.Forms.NumericUpDown xAxisNumericUpDown;
        private System.Windows.Forms.NumericUpDown yAxisNumericUpDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox boundaryComboBox;
    }
}