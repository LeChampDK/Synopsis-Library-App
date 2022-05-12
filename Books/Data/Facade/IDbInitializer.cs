namespace Books.Data.Facade
{
    public interface IDbInitializer
    {
        void Initialize(BookContext context);
    }
}
