using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KSU.CIS300.ConnectFour
{
    public partial class UserInterface : Form
    {
        private Game _game = new Game();
        private int DisabledColumns = 0;
        public UserInterface()
        {
            InitializeComponent();
            MakeUI();
        }

        private void SetColor(string id, Color color)
        {
            Control[] Controls = uxBoardContainer.Controls.Find(id, false);
            
            Label FoundLabel = (Label)Controls[0];
            FoundLabel.BackColor = color;
        }

        private void uxPlaceButtonClick(object sender, EventArgs e)
        {
            Button PlaceButton = (Button)sender;
            int row = 0;
            string PreviousTurn = Convert.ToString(_game.Turn);
            if (_game.Turn == PlayersTurn.Red) {
                string Id = _game.PlaceNewPiece(Color.Red, PlaceButton.Text, out row);
                SetColor(Id, Color.Red);
                _game.Turn = PlayersTurn.Black;
            }
            else
            {
                string Id = _game.PlaceNewPiece(Color.Black, PlaceButton.Text, out row);
                SetColor(Id, Color.Black);
                _game.Turn = PlayersTurn.Red;
            }
            DoubleLinkedListCell<GamePiece> LastPlaced;
            _game.FindCell(Convert.ToChar(PlaceButton.Text), row, out LastPlaced);
            if (_game.CheckWin(LastPlaced))
            {
                MessageBox.Show(PreviousTurn + " Wins!");
                Environment.Exit(0);
            }

            if (row == Game.ColumnSize)
            {
                PlaceButton.Enabled = false;
                DisabledColumns += 1;
            }
            if (DisabledColumns == 7)
            {
                MessageBox.Show("Game was a Draw!");
                Environment.Exit(0);
            }

        }

        private void MakeUI()
        {
            char[] Labels = Game.ColumnLabels.ToCharArray();
            foreach (char label in Labels)
            {
                Button theButton = new Button();
                theButton.Text = label.ToString();
                theButton.Width = 45;
                theButton.Height = 20;
                theButton.Margin = new Padding(5, 5, 5, 5);
                theButton.Click += new EventHandler(uxPlaceButtonClick);
                uxPlaceButtonContainer.Controls.Add(theButton);
                for(int i = Game.ColumnSize; i > 0; i--)
                {
                    Label PlaceLabel = new Label();
                    PlaceLabel.Width = 45;
                    PlaceLabel.Height = 45;
                    PlaceLabel.Margin = new Padding(5, 5, 5, 5);
                    PlaceLabel.BackColor = Color.White;
                    PlaceLabel.Name = label.ToString() + Convert.ToString(i);
                    uxBoardContainer.Controls.Add(PlaceLabel);
                }
            }
            uxTurnLabel.Text = "Red";
            uxTurnLabel.BackColor = Color.Red;
            uxTurnLabel.ForeColor = Color.Black;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
