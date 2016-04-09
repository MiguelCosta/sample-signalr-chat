using Microsoft.AspNet.SignalR.Client;
using System;
using System.Windows.Forms;

namespace Mpc.SignalRWinForms
{
    public partial class MainForm : Form
    {
        private IHubProxy chat;

        public MainForm()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            var hubConnection = new HubConnection(txtUrl.Text);
            chat = hubConnection.CreateHubProxy("chat");

            chat.On("newMessage", NewMessage());
            hubConnection.Start();
        }

        private void btnJoin_Click(object sender, EventArgs e)
        {
            chat.Invoke<string>("joinRoom", txtRoom.Text);
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            chat.Invoke<string>("sendMessage", txtMessage.Text);
        }

        private void btnSendPM_Click(object sender, EventArgs e)
        {
            chat.Invoke<string>("sendMessageToRoom", txtRoom.Text, txtMessage.Text);
        }

        private Action<string> NewMessage()
        {
            return msg => txtMessages.Invoke(new Action(() => AppendMessage(msg)));
        }

        private void AppendMessage(string msg)
        {
            txtMessages.AppendText($"{msg}{Environment.NewLine}");
        }
    }
}
