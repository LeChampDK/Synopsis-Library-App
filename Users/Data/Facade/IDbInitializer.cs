namespace Users.Data.Facade
{
    public interface IDbInitializer
    {
        void Initialize(UserContext context);
    }
}
