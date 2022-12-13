namespace VierGewinnt
{
    public partial class Form_VierGewinnt : Form
    {
        public Form_VierGewinnt()
        {
            InitializeComponent();

            PlayField.Visible = false;
            RadioButton_StartFirstPlayer.Checked = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (IsPlayerInputValid(TextBox_PlayerOne.Text, TextBox_PlayerTwo.Text))
                InitalizePlayfield();
        }

        private bool IsPlayerInputValid(string playerOne, string playerTwo)
        {
            return !String.IsNullOrWhiteSpace(playerOne) && !String.IsNullOrWhiteSpace(playerTwo);
        }

        private void InitalizePlayfield()
        {
            PlayerInput.Visible = false;
            PlayField.Visible = true;

            foreach (Control x in PlayField.Controls)
            {
                if (x is TextBox)
                {
                    ((TextBox)x).Enabled = false;
                }
            }
        }
 
    }
}