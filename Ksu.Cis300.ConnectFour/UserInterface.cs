/* UserInterface.cs
 * Modified by: Michael Keleti
 */

using System;
using System.Drawing;
using System.Windows.Forms;

namespace KSU.CIS300.ConnectFour
{
    /// <summary>
    /// Class that defines the user interface show the the player.
    /// </summary>
    public partial class UserInterface : Form
    {
        /// <summary>
        /// The game in which the player is currently playing. Initializes a new
        /// game objec in which methods and variables are stored.
        /// </summary>
        private Game _game = new Game();

        /// <summary>
        /// The number of columns that are full.
        /// </summary>
        private int DisabledColumns = 0;

        /// <summary>
        /// Constructs a new User Interface to display to the user.
        /// </summary>
        public UserInterface()
        {
            InitializeComponent();
            MakeUI();
        }

        /// <summary>
        /// Sets the color of a label on the board to any specified color.
        /// </summary>
        /// <param name="id">id of the label to set the color of</param>
        /// <param name="color">color in which to set the label to</param>
        private void SetColor(string id, Color color)
        {
            Control[] Controls = uxBoardContainer.Controls.Find(id, false);

            Label FoundLabel = (Label)Controls[0];
            FoundLabel.BackColor = color;
        }

        /// <summary>
        /// Event handling method for the click of any of the place buttons. Will place a
        /// piece at the top of the selected buttons column.
        /// </summary>
        /// <param name="sender">Button that was pressed</param>
        /// <param name="e">Argument passed with event</param>
        private void uxPlaceButtonClick(object sender, EventArgs e)
        {
            Button PlaceButton = (Button)sender;
            int row = 0;
            string PreviousTurn = Convert.ToString(_game.Turn);
            if (_game.Turn == PlayersTurn.Red)
            {
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

        /// <summary>
        ///  Creates the User interface at the beginning of the game. Responsible for
        ///  setting each of the buttons and labels in their respective flowlayouts.
        /// </summary>
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
                for (int i = Game.ColumnSize; i > 0; i--)
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
    }
}