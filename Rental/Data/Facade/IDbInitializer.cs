namespace Rental.Data.Facade
{
    public interface IDbInitializer
    {
        void Initialize(RentalContext context);
    }
}
