/* Modified By: Michael Keleti
 * 
 */
namespace KSU.CIS300.ConnectFour
{
    //
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
            this.uxTopContainer.Location = new System.Drawing.Point(12, 2);
            this.uxTopContainer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.uxTopContainer.Name = "uxTopContainer";
            this.uxTopContainer.Size = new System.Drawing.Size(525, 23);
            this.uxTopContainer.TabIndex = 0;
            // 
            // uxTurnLabel
            // 
            this.uxTurnLabel.AutoSize = true;
            this.uxTurnLabel.BackColor = System.Drawing.Color.White;
            this.uxTurnLabel.Location = new System.Drawing.Point(478, 0);
            this.uxTurnLabel.Name = "uxTurnLabel";
            this.uxTurnLabel.Size = new System.Drawing.Size(44, 17);
            this.uxTurnLabel.TabIndex = 0;
            this.uxTurnLabel.Text = "         ";
            // 
            // uxPlayerLabel
            // 
            this.uxPlayerLabel.AutoSize = true;
            this.uxPlayerLabel.Location = new System.Drawing.Point(376, 0);
            this.uxPlayerLabel.Name = "uxPlayerLabel";
            this.uxPlayerLabel.Size = new System.Drawing.Size(96, 17);
            this.uxPlayerLabel.TabIndex = 1;
            this.uxPlayerLabel.Text = "Player\'s Turn:";
            // 
            // uxPlaceButtonContainer
            // 
            this.uxPlaceButtonContainer.Location = new System.Drawing.Point(12, 29);
            this.uxPlaceButtonContainer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.uxPlaceButtonContainer.Name = "uxPlaceButtonContainer";
            this.uxPlaceButtonContainer.Size = new System.Drawing.Size(525, 35);
            this.uxPlaceButtonContainer.TabIndex = 1;
            // 
            // uxBoardContainer
            // 
            this.uxBoardContainer.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.uxBoardContainer.Location = new System.Drawing.Point(12, 69);
            this.uxBoardContainer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.uxBoardContainer.Name = "uxBoardContainer";
            this.uxBoardContainer.Size = new System.Drawing.Size(525, 411);
            this.uxBoardContainer.TabIndex = 2;
            // 
            // UserInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(552, 494);
            this.Controls.Add(this.uxPlaceButtonContainer);
            this.Controls.Add(this.uxBoardContainer);
            this.Controls.Add(this.uxTopContainer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "UserInterface";
            this.Text = "Form1";
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

