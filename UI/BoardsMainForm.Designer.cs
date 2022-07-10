
namespace UI
{
    partial class BoardsMainForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonPlaceFleet = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.labelShipsLeftHuman = new System.Windows.Forms.Label();
            this.labelLastTargetHuman = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(550, 66);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(517, 421);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "My Evidence";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // buttonPlaceFleet
            // 
            this.buttonPlaceFleet.Location = new System.Drawing.Point(447, 503);
            this.buttonPlaceFleet.Margin = new System.Windows.Forms.Padding(2);
            this.buttonPlaceFleet.Name = "buttonPlaceFleet";
            this.buttonPlaceFleet.Size = new System.Drawing.Size(82, 19);
            this.buttonPlaceFleet.TabIndex = 127;
            this.buttonPlaceFleet.Text = "Place Fleet";
            this.buttonPlaceFleet.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(550, 503);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(82, 19);
            this.button1.TabIndex = 128;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(12, 66);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(517, 421);
            this.groupBox2.TabIndex = 129;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "My Fleet";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // labelShipsLeftHuman
            // 
            this.labelShipsLeftHuman.AutoSize = true;
            this.labelShipsLeftHuman.Location = new System.Drawing.Point(261, 23);
            this.labelShipsLeftHuman.Name = "labelShipsLeftHuman";
            this.labelShipsLeftHuman.Size = new System.Drawing.Size(50, 13);
            this.labelShipsLeftHuman.TabIndex = 131;
            this.labelShipsLeftHuman.Text = "Ships left";
            // 
            // labelLastTargetHuman
            // 
            this.labelLastTargetHuman.AutoSize = true;
            this.labelLastTargetHuman.Location = new System.Drawing.Point(101, 23);
            this.labelLastTargetHuman.Name = "labelLastTargetHuman";
            this.labelLastTargetHuman.Size = new System.Drawing.Size(57, 13);
            this.labelLastTargetHuman.TabIndex = 130;
            this.labelLastTargetHuman.Text = "Last target";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(822, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 133;
            this.label1.Text = "Ships left";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(662, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 132;
            this.label2.Text = "Last target";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1079, 555);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelShipsLeftHuman);
            this.Controls.Add(this.labelLastTargetHuman);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonPlaceFleet);
            this.Controls.Add(this.groupBox1);
            this.Name = "Battleship";
            this.Text = "Battleship";
            this.Load += new System.EventHandler(this.BoardsMainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonPlaceFleet;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label labelShipsLeftHuman;
        private System.Windows.Forms.Label labelLastTargetHuman;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

