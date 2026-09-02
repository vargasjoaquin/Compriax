namespace CompriaxSystem.Application.Interfaces.Services
{
    public interface ICurrentUserService
    {
        UserSessionDto? CurrentUser { get; set; }
        OperationalContextDto? OperationalContext { get; set; }
        bool IsAuthenticated => CurrentUser != null;
        bool HasRegisterAssigned => OperationalContext != null && OperationalContext.CashRegisterId > 0;
        void SetCashRegister(int registerId, int number, string name);
    }
}
