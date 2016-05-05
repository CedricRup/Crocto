namespace WebApi.Models.Villages
{
    public interface IVillageRepository
    {
        Village Get(string villageName);
        void Register(Village village);
    }
}