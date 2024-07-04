namespace DetailTest
{
    partial class ProgramWindow
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
            this.lenght2D = new System.Windows.Forms.TextBox();
            this.thickness2D = new System.Windows.Forms.TextBox();
            this.add2D = new System.Windows.Forms.Button();
            this.load2D = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.file2D = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.file3D = new System.Windows.Forms.TextBox();
            this.load3D = new System.Windows.Forms.Button();
            this.add3D = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.baseLength = new System.Windows.Forms.TextBox();
            this.baseWidth = new System.Windows.Forms.TextBox();
            this.baseHeight = new System.Windows.Forms.TextBox();
            this.circleRad = new System.Windows.Forms.TextBox();
            this.circleHaight = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.holeRad = new System.Windows.Forms.TextBox();
            this.holeBigRad = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lenght2D
            // 
            this.lenght2D.Location = new System.Drawing.Point(162, 65);
            this.lenght2D.Name = "lenght2D";
            this.lenght2D.Size = new System.Drawing.Size(92, 20);
            this.lenght2D.TabIndex = 0;
            // 
            // thickness2D
            // 
            this.thickness2D.Location = new System.Drawing.Point(162, 94);
            this.thickness2D.Name = "thickness2D";
            this.thickness2D.Size = new System.Drawing.Size(92, 20);
            this.thickness2D.TabIndex = 1;
            // 
            // add2D
            // 
            this.add2D.Location = new System.Drawing.Point(95, 331);
            this.add2D.Name = "add2D";
            this.add2D.Size = new System.Drawing.Size(108, 39);
            this.add2D.TabIndex = 3;
            this.add2D.Text = "Добавить 2 д деталь";
            this.add2D.UseVisualStyleBackColor = true;
            this.add2D.Click += new System.EventHandler(this.building_Click);
            // 
            // load2D
            // 
            this.load2D.Location = new System.Drawing.Point(95, 374);
            this.load2D.Name = "load2D";
            this.load2D.Size = new System.Drawing.Size(108, 42);
            this.load2D.TabIndex = 7;
            this.load2D.Text = "Загрузить 2д деталь";
            this.load2D.UseVisualStyleBackColor = true;
            this.load2D.Click += new System.EventHandler(this.load_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 306);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(162, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Ввведите название 2д детали:";
            // 
            // file2D
            // 
            this.file2D.Location = new System.Drawing.Point(177, 303);
            this.file2D.Name = "file2D";
            this.file2D.Size = new System.Drawing.Size(100, 20);
            this.file2D.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(128, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "2д примитив";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(515, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "3д примитив";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "длинна плечей креста";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "толщина плечей креста";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(386, 306);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(162, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Ввведите название 3д детали:";
            // 
            // file3D
            // 
            this.file3D.Location = new System.Drawing.Point(554, 303);
            this.file3D.Name = "file3D";
            this.file3D.Size = new System.Drawing.Size(100, 20);
            this.file3D.TabIndex = 16;
            // 
            // load3D
            // 
            this.load3D.Location = new System.Drawing.Point(478, 399);
            this.load3D.Name = "load3D";
            this.load3D.Size = new System.Drawing.Size(106, 42);
            this.load3D.TabIndex = 15;
            this.load3D.Text = "Загрузить 3д деталь";
            this.load3D.UseVisualStyleBackColor = true;
            this.load3D.Click += new System.EventHandler(this.load3D_Click);
            // 
            // add3D
            // 
            this.add3D.Location = new System.Drawing.Point(478, 352);
            this.add3D.Name = "add3D";
            this.add3D.Size = new System.Drawing.Size(108, 41);
            this.add3D.TabIndex = 14;
            this.add3D.Text = "Добавить 3д деталь";
            this.add3D.UseVisualStyleBackColor = true;
            this.add3D.Click += new System.EventHandler(this.add3D_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(592, 32);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 13);
            this.label7.TabIndex = 21;
            this.label7.Text = "Цылиндр";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(392, 32);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "Основание";
            // 
            // baseLength
            // 
            this.baseLength.Location = new System.Drawing.Point(375, 97);
            this.baseLength.Name = "baseLength";
            this.baseLength.Size = new System.Drawing.Size(92, 20);
            this.baseLength.TabIndex = 19;
            // 
            // baseWidth
            // 
            this.baseWidth.Location = new System.Drawing.Point(375, 68);
            this.baseWidth.Name = "baseWidth";
            this.baseWidth.Size = new System.Drawing.Size(92, 20);
            this.baseWidth.TabIndex = 18;
            // 
            // baseHeight
            // 
            this.baseHeight.Location = new System.Drawing.Point(375, 123);
            this.baseHeight.Name = "baseHeight";
            this.baseHeight.Size = new System.Drawing.Size(92, 20);
            this.baseHeight.TabIndex = 22;
            // 
            // circleRad
            // 
            this.circleRad.Location = new System.Drawing.Point(571, 68);
            this.circleRad.Name = "circleRad";
            this.circleRad.Size = new System.Drawing.Size(92, 20);
            this.circleRad.TabIndex = 23;
            // 
            // circleHaight
            // 
            this.circleHaight.Location = new System.Drawing.Point(571, 97);
            this.circleHaight.Name = "circleHaight";
            this.circleHaight.Size = new System.Drawing.Size(92, 20);
            this.circleHaight.TabIndex = 24;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(584, 163);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 13);
            this.label9.TabIndex = 25;
            this.label9.Text = "Отверстия";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // holeRad
            // 
            this.holeRad.Location = new System.Drawing.Point(557, 199);
            this.holeRad.Name = "holeRad";
            this.holeRad.Size = new System.Drawing.Size(115, 20);
            this.holeRad.TabIndex = 26;
            // 
            // holeBigRad
            // 
            this.holeBigRad.Location = new System.Drawing.Point(557, 228);
            this.holeBigRad.Name = "holeBigRad";
            this.holeBigRad.Size = new System.Drawing.Size(115, 20);
            this.holeBigRad.TabIndex = 27;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(321, 71);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(48, 13);
            this.label10.TabIndex = 28;
            this.label10.Text = "ширина:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(321, 99);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(46, 13);
            this.label11.TabIndex = 29;
            this.label11.Text = "длинна:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(321, 126);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(47, 13);
            this.label12.TabIndex = 30;
            this.label12.Text = "высота:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(491, 72);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(45, 13);
            this.label13.TabIndex = 31;
            this.label13.Text = "радиус:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(491, 104);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(47, 13);
            this.label14.TabIndex = 32;
            this.label14.Text = "высота:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(454, 231);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(97, 13);
            this.label15.TabIndex = 33;
            this.label15.Text = "радиус большого:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(470, 202);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(81, 13);
            this.label16.TabIndex = 34;
            this.label16.Text = "радиус малых:";
            this.label16.Click += new System.EventHandler(this.label16_Click);
            // 
            // ProgramWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(728, 461);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.holeBigRad);
            this.Controls.Add(this.holeRad);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.circleHaight);
            this.Controls.Add(this.circleRad);
            this.Controls.Add(this.baseHeight);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.baseLength);
            this.Controls.Add(this.baseWidth);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.file3D);
            this.Controls.Add(this.load3D);
            this.Controls.Add(this.add3D);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.file2D);
            this.Controls.Add(this.load2D);
            this.Controls.Add(this.add2D);
            this.Controls.Add(this.thickness2D);
            this.Controls.Add(this.lenght2D);
            this.Name = "ProgramWindow";
            this.Text = "ProgramWindow";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox lenght2D;
        private System.Windows.Forms.TextBox thickness2D;
        private System.Windows.Forms.Button add2D;
        private System.Windows.Forms.Button load2D;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox file2D;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox file3D;
        private System.Windows.Forms.Button load3D;
        private System.Windows.Forms.Button add3D;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox baseLength;
        private System.Windows.Forms.TextBox baseWidth;
        private System.Windows.Forms.TextBox baseHeight;
        private System.Windows.Forms.TextBox circleRad;
        private System.Windows.Forms.TextBox circleHaight;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox holeRad;
        private System.Windows.Forms.TextBox holeBigRad;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
    }
}