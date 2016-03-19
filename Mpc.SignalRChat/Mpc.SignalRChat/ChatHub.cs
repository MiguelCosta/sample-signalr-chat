using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using Mpc.SignalRChat.ChatModels;

namespace Mpc.SignalRChat
{
    [HubName("chat")]
    public class ChatHub : Hub
    {
        public void SendMessage(string message)
        {
            Clients.All.newMessage(message);
        }

        public void SendMessageData(SendData data)
        {
            // process incoming data...
            // transform data...
            // craft new data...
            Clients.All.newData(data);
        }

        //public Task<int> SendDataAsync()
        //{
        //    // async... work...
        //}
    }
}
