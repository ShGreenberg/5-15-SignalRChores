using _5_15_SignalRTasks.data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _5_15_SignalRTasks.web
{
    public class ChoresHub: Hub
    {
        private string _connString;
        public ChoresHub(IConfiguration configuration)
        {
            _connString = configuration.GetConnectionString("ConStr");
        }

        public void AddChore(string name)
        {
            ChoresRepository rep = new ChoresRepository(_connString);
            rep.AddChore(name);
            Clients.All.SendAsync("AddChore");
        }

        public void StartChore(Chore chore)
        {
            ChoresRepository rep = new ChoresRepository(_connString);
            rep.ChangeStatus(chore);
            Clients.All.SendAsync("StartChore");

        }

        public void CompleteChore(Chore chore)
        {
            ChoresRepository rep = new ChoresRepository(_connString);
            rep.ChangeStatus(chore);
            Clients.All.SendAsync("CompleteChore");
        }
    }
}
