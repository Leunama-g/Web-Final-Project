using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Clinic_Patient_Info_Management_System.Hubs
{
    [HubName("receptinistHub")]
    public class ReceptinistHub : Hub
    {

        [HubMethodName("SendNotifications")]
        public void SendNotifications(string message)
        {
            Clients.All.receiveNotification(message);
        }
    }
}