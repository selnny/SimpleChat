namespace ClientApp
{
    public partial class frmJoin : Form
    {
        public frmJoin()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnJoin_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                AppSession.Username = txtUsername.Text.Trim();
                this.DialogResult = DialogResult.OK;
                this.Close();

            }
            else
            {
                MessageBox.Show("Enter a username.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
