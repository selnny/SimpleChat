using System;
using System.Configuration;
using System.Text;
using TcpSharp;

namespace ClientApp
{
    public partial class frmChat : Form
    {
        private static frmChat? _instance;
        public static frmChat Instance
        {
            get
            {
                if (_instance == null || _instance.IsDisposed)
                {
                    _instance = new frmChat();
                }
                return _instance;
            }
        }

        private TcpSharpSocketClient _client;

        public frmChat()
        {
            InitializeComponent();
            _client = new TcpSharpSocketClient(ConfigurationManager.AppSettings["Host"], Int32.Parse(ConfigurationManager.AppSettings["Port"]!));
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtMessage.Text))
            {
                string targetUser = lstUsers.SelectedItem?.ToString();
                string message = txtMessage.Text.Trim();

                if (string.IsNullOrWhiteSpace(targetUser))
                {
                    _client.SendString($"MSG|ALL|{message}");
                    AppendLog($"To All: {message}");
                }
                else
                {
                    _client.SendString($"MSG|{targetUser}|{message}");
                    AppendLog($"To {targetUser}: {message}");
                }

                txtMessage.Clear();
            }
            else
            {
                MessageBox.Show("Enter a message.", "Error", MessageBoxButtons.OK);
            }
        }

        private void frmChat_Load(object sender, EventArgs e)
        {
            this.Text = $"Joined as: {AppSession.Username}";

            _client.OnConnected += _client_OnConnected;
            _client.OnDisconnected += _client_OnDisconnected;
            _client.OnDataReceived += _client_OnDataReceived;
            _client.Connect();
            //btnSend.Enabled = false; 
        }

        private void AppendLog(string message)
        {
            if (rtfLog.InvokeRequired)
            {
                rtfLog.Invoke(new Action(() =>
                {
                    rtfLog.AppendText($"[{DateTime.Now:HH:mm:ss}] {message}" + Environment.NewLine);
                    rtfLog.ScrollToCaret();
                }));
            }
            else
            {
                rtfLog.AppendText($"[{DateTime.Now:HH:mm:ss}] {message}" + Environment.NewLine);
                rtfLog.ScrollToCaret();
            }
        }

        private void _client_OnConnected(object? sender, OnClientConnectedEventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => _client_OnConnected(sender, e)));
            }
            else
            {
                AppendLog("Connected to server.");

                try
                {
                    string joinMessage = $"JOIN|{AppSession.Username}";
                    _client.SendString(joinMessage);
                    AppendLog($"Sent join message: {joinMessage}");
                    btnSend.Enabled = true;
                    AppendLog("Send button enabled.");
                }
                catch (Exception ex)
                {
                    AppendLog($"Error sending join message: {ex.Message}");
                    btnSend.Enabled = false;
                }

                txtMessage.Focus();
            }
        }

        private void _client_OnDisconnected(object? sender, OnClientDisconnectedEventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => _client_OnDisconnected(sender, e)));
            }
            else
            {
                AppendLog("Disconnected from server.");
                btnSend.Enabled = false;
                AppendLog("Send button disabled.");
            }
        }

        private void _client_OnDataReceived(object? sender, OnClientDataReceivedEventArgs e)
        {
            string msg = Encoding.UTF8.GetString(e.Data);

            if (msg.StartsWith("USERLIST|"))
            {
                string[] users = msg.Substring("USERLIST|".Length).Split(',');
                Invoke(new Action(() =>
                {
                    lstUsers.Items.Clear();
                    foreach (string user in users)
                    {
                        if (user != AppSession.Username && !string.IsNullOrWhiteSpace(user))
                        {
                            lstUsers.Items.Add(user);
                        }
                    }
                }));
            }
            else
            {
                AppendLog(msg);
            }
        }

        private void txtMessage_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtMessage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true; 
                btnSend_Click(sender, e);
            }
        }

        private void frmChat_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_client.Connected)
            {
                string leaveMessage = $"LEAVE|{AppSession.Username}";
                _client.SendString(leaveMessage);
                _client.Disconnect();
            }
        }

        private void rtfLog_TextChanged(object sender, EventArgs e)
        {

        }

        private void lstUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}