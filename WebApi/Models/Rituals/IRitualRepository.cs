namespace WebApi.Models.Rituals
{
    public  interface IRitualRepository
    {
        void Register(Ritual ritual);
        Ritual Get(string id);
    }
}