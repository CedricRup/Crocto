using System.Collections.Generic;

namespace WebApi.Models.Rituals
{
    public class Ritual
    {
        public Ritual()
        {
            Actions = new List<RitualAction>();
        }
        public string Name { get; set; }
        public List<RitualAction> Actions { get; set; }
    }
}