using Database;

namespace WebApi.Models.Villages
{
    public class VillageRepository : Store<Village,string>, IVillageRepository
    {
        public VillageRepository() : base(v=>v.Name)
        {
        }
    }
}