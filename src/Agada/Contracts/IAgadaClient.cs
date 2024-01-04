namespace Agada.Contracts
{
    public interface IAgadaClient
    {
        IAdmService Adm { get; }
        IGameService Game { get; }
        IPromotionService Promotion { get; }
        ISmartDealsService SmartDeals { get; }
    }
}