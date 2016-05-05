using System;
using Database;

namespace WebApi.Models.Rituals
{
    public class RitualRepository : Store<Ritual,string>, IRitualRepository
    {
        public RitualRepository() : base(e=>e.Name)
        {
        }
    }
}