
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
            this.labelShipsLeftMyFleet = new System.Windows.Forms.Label();
            this.labelLastTargetMyFleet = new System.Windows.Forms.Label();
            this.labelShipsLeftMyEvidence = new System.Windows.Forms.Label();
            this.labelLastTargetMyEvidence = new System.Windows.Forms.Label();
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
            // labelShipsLeftMyFleet
            // 
            this.labelShipsLeftMyFleet.AutoSize = true;
            this.labelShipsLeftMyFleet.Location = new System.Drawing.Point(245, 23);
            this.labelShipsLeftMyFleet.Name = "labelShipsLeftMyFleet";
            this.labelShipsLeftMyFleet.Size = new System.Drawing.Size(50, 13);
            this.labelShipsLeftMyFleet.TabIndex = 131;
            this.labelShipsLeftMyFleet.Text = "Ships left";
            // 
            // labelLastTargetMyFleet
            // 
            this.labelLastTargetMyFleet.AutoSize = true;
            this.labelLastTargetMyFleet.Location = new System.Drawing.Point(85, 23);
            this.labelLastTargetMyFleet.Name = "labelLastTargetMyFleet";
            this.labelLastTargetMyFleet.Size = new System.Drawing.Size(57, 13);
            this.labelLastTargetMyFleet.TabIndex = 130;
            this.labelLastTargetMyFleet.Text = "Last target";
            // 
            // labelShipsLeftMyEvidence
            // 
            this.labelShipsLeftMyEvidence.AutoSize = true;
            this.labelShipsLeftMyEvidence.Location = new System.Drawing.Point(769, 23);
            this.labelShipsLeftMyEvidence.Name = "labelShipsLeftMyEvidence";
            this.labelShipsLeftMyEvidence.Size = new System.Drawing.Size(50, 13);
            this.labelShipsLeftMyEvidence.TabIndex = 133;
            this.labelShipsLeftMyEvidence.Text = "Ships left";
            // 
            // labelLastTargetMyEvidence
            // 
            this.labelLastTargetMyEvidence.AutoSize = true;
            this.labelLastTargetMyEvidence.Location = new System.Drawing.Point(609, 23);
            this.labelLastTargetMyEvidence.Name = "labelLastTargetMyEvidence";
            this.labelLastTargetMyEvidence.Size = new System.Drawing.Size(57, 13);
            this.labelLastTargetMyEvidence.TabIndex = 132;
            this.labelLastTargetMyEvidence.Text = "Last target";
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
            this.Controls.Add(this.labelShipsLeftMyEvidence);
            this.Controls.Add(this.labelLastTargetMyEvidence);
            this.Controls.Add(this.labelShipsLeftMyFleet);
            this.Controls.Add(this.labelLastTargetMyFleet);
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
        private System.Windows.Forms.Label labelShipsLeftMyFleet;
        private System.Windows.Forms.Label labelLastTargetMyFleet;
        private System.Windows.Forms.Label labelShipsLeftMyEvidence;
        private System.Windows.Forms.Label labelLastTargetMyEvidence;
        private System.Windows.Forms.GroupBox groupBox_MyFleet;
    }
}

