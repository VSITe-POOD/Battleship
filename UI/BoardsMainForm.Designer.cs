
using GUI_Boards;

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
            this.groupBox_MyEvidence = new System.Windows.Forms.GroupBox();
            this.buttonPlaceFleet = new System.Windows.Forms.Button();
            this.buttonStart = new System.Windows.Forms.Button();
            this.labelShipsLeftHuman = new System.Windows.Forms.Label();
            this.labelLastTargetHuman = new System.Windows.Forms.Label();
            this.labelShipsLeftComputer = new System.Windows.Forms.Label();
            this.labelLastTargetComputer = new System.Windows.Forms.Label();
            this.groupBox_MyFleet = new System.Windows.Forms.GroupBox();
            this.SuspendLayout();
            // 
            // groupBox_MyEvidence
            // 
            this.groupBox_MyEvidence.Location = new System.Drawing.Point(510, 66);
            this.groupBox_MyEvidence.Name = "groupBox_MyEvidence";
            this.groupBox_MyEvidence.Size = new System.Drawing.Size(480, 454);
            this.groupBox_MyEvidence.TabIndex = 0;
            this.groupBox_MyEvidence.TabStop = false;
            this.groupBox_MyEvidence.Text = "My Evidence";
            // 
            // buttonPlaceFleet
            // 
            this.buttonPlaceFleet.Location = new System.Drawing.Point(410, 525);
            this.buttonPlaceFleet.Margin = new System.Windows.Forms.Padding(2);
            this.buttonPlaceFleet.Name = "buttonPlaceFleet";
            this.buttonPlaceFleet.Size = new System.Drawing.Size(82, 19);
            this.buttonPlaceFleet.TabIndex = 127;
            this.buttonPlaceFleet.Text = "Place Fleet";
            this.buttonPlaceFleet.UseVisualStyleBackColor = true;
            this.buttonPlaceFleet.Click += new System.EventHandler(this.buttonPlaceFleet_Click);
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(510, 525);
            this.buttonStart.Margin = new System.Windows.Forms.Padding(2);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(82, 19);
            this.buttonStart.TabIndex = 128;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // labelShipsLeftHuman
            // 
            this.labelShipsLeftHuman.AutoSize = true;
            this.labelShipsLeftHuman.Location = new System.Drawing.Point(245, 23);
            this.labelShipsLeftHuman.Name = "labelShipsLeftHuman";
            this.labelShipsLeftHuman.Size = new System.Drawing.Size(50, 13);
            this.labelShipsLeftHuman.TabIndex = 131;
            this.labelShipsLeftHuman.Text = "Ships left";
            // 
            // labelLastTargetHuman
            // 
            this.labelLastTargetHuman.AutoSize = true;
            this.labelLastTargetHuman.Location = new System.Drawing.Point(85, 23);
            this.labelLastTargetHuman.Name = "labelLastTargetHuman";
            this.labelLastTargetHuman.Size = new System.Drawing.Size(57, 13);
            this.labelLastTargetHuman.TabIndex = 130;
            this.labelLastTargetHuman.Text = "Last target";
            // 
            // labelShipsLeftComputer
            // 
            this.labelShipsLeftComputer.AutoSize = true;
            this.labelShipsLeftComputer.Location = new System.Drawing.Point(769, 23);
            this.labelShipsLeftComputer.Name = "labelShipsLeftComputer";
            this.labelShipsLeftComputer.Size = new System.Drawing.Size(50, 13);
            this.labelShipsLeftComputer.TabIndex = 133;
            this.labelShipsLeftComputer.Text = "Ships left";
            // 
            // labelLastTargetComputer
            // 
            this.labelLastTargetComputer.AutoSize = true;
            this.labelLastTargetComputer.Location = new System.Drawing.Point(609, 23);
            this.labelLastTargetComputer.Name = "labelLastTargetComputer";
            this.labelLastTargetComputer.Size = new System.Drawing.Size(57, 13);
            this.labelLastTargetComputer.TabIndex = 132;
            this.labelLastTargetComputer.Text = "Last target";
            // 
            // groupBox_MyFleet
            // 
            this.groupBox_MyFleet.Location = new System.Drawing.Point(12, 66);
            this.groupBox_MyFleet.Name = "groupBox_MyFleet";
            this.groupBox_MyFleet.Size = new System.Drawing.Size(480, 454);
            this.groupBox_MyFleet.TabIndex = 134;
            this.groupBox_MyFleet.TabStop = false;
            this.groupBox_MyFleet.Text = "My Fleet";
            // 
            // BoardsMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1002, 555);
            this.Controls.Add(this.groupBox_MyFleet);
            this.Controls.Add(this.labelShipsLeftComputer);
            this.Controls.Add(this.labelLastTargetComputer);
            this.Controls.Add(this.labelShipsLeftHuman);
            this.Controls.Add(this.labelLastTargetHuman);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.buttonPlaceFleet);
            this.Controls.Add(this.groupBox_MyEvidence);
            this.Name = "BoardsMainForm";
            this.Text = "Battleship";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox_MyEvidence;
        private System.Windows.Forms.Button buttonPlaceFleet;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Label labelShipsLeftHuman;
        private System.Windows.Forms.Label labelLastTargetHuman;
        private System.Windows.Forms.Label labelShipsLeftComputer;
        private System.Windows.Forms.Label labelLastTargetComputer;
        private System.Windows.Forms.GroupBox groupBox_MyFleet;
    }
}

