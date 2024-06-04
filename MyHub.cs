using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

public class MyHub : Hub
{
  public async Task SendUpdate(string update)
  {
    await Clients.All.SendAsync("ReceiveUpdate", update);
  }
}