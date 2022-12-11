using Microsoft.AspNetCore.SignalR;

namespace VolsWebApp.Hubs
{
    public class VolHub : Hub
    {

        public async Task SendMessage(DateTime prevu, DateTime revise, string compagnie, string provenance, string etat)
        {
            await Clients.All.SendAsync("ReceiveMessage", prevu, revise, compagnie, provenance, etat);
        }

        //public async Task SendMessage()
        //{
        //    await Clients.All.SendAsync("ReceiveMessage");
        //}
    }
}

