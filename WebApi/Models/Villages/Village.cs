using System.Collections.Generic;
using WebApi.Models.ActionPlans;
using WebApi.Models.Rituals;

namespace WebApi.Models.Villages
{
    public class Village
    {
        public string Name { get; set; }
        public List<string> Villagers { get; set; }

        public Ritual Ritual { get; set; }

        public virtual void GiveActionPlan(ActionPlan actionPlan)
        {
            throw new System.NotImplementedException();
        }
    }
}