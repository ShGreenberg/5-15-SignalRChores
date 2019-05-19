using Newtonsoft.Json;
using System;

namespace _5_15_SignalRTasks.data
{
    public class Chore
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Status Status { get; set; }
    
        public User User { get; set; }
    }
}
