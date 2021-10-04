namespace KSU.CIS300.ConnectFour
{
    partial class UserInterface
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
            this.uxTopContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.uxTurnLabel = new System.Windows.Forms.Label();
            this.uxPlayerLabel = new System.Windows.Forms.Label();
            this.uxPlaceButtonContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.uxBoardContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.uxTopContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // uxTopContainer
            // 
            this.uxTopContainer.Controls.Add(this.uxTurnLabel);
            this.uxTopContainer.Controls.Add(this.uxPlayerLabel);
            this.uxTopContainer.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.uxTopContainer.Location = new System.Drawing.Point(9, 2);
            this.uxTopContainer.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.uxTopContainer.Name = "uxTopContainer";
            this.uxTopContainer.Size = new System.Drawing.Size(394, 26);
            this.uxTopContainer.TabIndex = 0;
            // 
            // uxTurnLabel
            // 
            this.uxTurnLabel.AutoSize = true;
            this.uxTurnLabel.BackColor = System.Drawing.Color.White;
            this.uxTurnLabel.Location = new System.Drawing.Point(358, 0);
            this.uxTurnLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.uxTurnLabel.Name = "uxTurnLabel";
            this.uxTurnLabel.Size = new System.Drawing.Size(34, 13);
            this.uxTurnLabel.TabIndex = 0;
            this.uxTurnLabel.Text = "         ";
            // 
            // uxPlayerLabel
            // 
            this.uxPlayerLabel.AutoSize = true;
            this.uxPlayerLabel.Location = new System.Drawing.Point(283, 0);
            this.uxPlayerLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.uxPlayerLabel.Name = "uxPlayerLabel";
            this.uxPlayerLabel.Size = new System.Drawing.Size(71, 13);
            this.uxPlayerLabel.TabIndex = 1;
            this.uxPlayerLabel.Text = "Player\'s Turn:";
            this.uxPlayerLabel.Click += new System.EventHandler(this.label2_Click);
            // 
            // uxPlaceButtonContainer
            // 
            this.uxPlaceButtonContainer.Location = new System.Drawing.Point(9, 32);
            this.uxPlaceButtonContainer.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.uxPlaceButtonContainer.Name = "uxPlaceButtonContainer";
            this.uxPlaceButtonContainer.Size = new System.Drawing.Size(394, 20);
            this.uxPlaceButtonContainer.TabIndex = 1;
            // 
            // uxBoardContainer
            // 
            this.uxBoardContainer.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.uxBoardContainer.Location = new System.Drawing.Point(9, 56);
            this.uxBoardContainer.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.uxBoardContainer.Name = "uxBoardContainer";
            this.uxBoardContainer.Size = new System.Drawing.Size(394, 334);
            this.uxBoardContainer.TabIndex = 2;
            // 
            // UserInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 401);
            this.Controls.Add(this.uxPlaceButtonContainer);
            this.Controls.Add(this.uxBoardContainer);
            this.Controls.Add(this.uxTopContainer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "UserInterface";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.uxTopContainer.ResumeLayout(false);
            this.uxTopContainer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel uxTopContainer;
        private System.Windows.Forms.Label uxTurnLabel;
        private System.Windows.Forms.Label uxPlayerLabel;
        private System.Windows.Forms.FlowLayoutPanel uxPlaceButtonContainer;
        private System.Windows.Forms.FlowLayoutPanel uxBoardContainer;
    }
}

