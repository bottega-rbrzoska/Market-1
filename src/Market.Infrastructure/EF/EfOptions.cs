namespace Market.Infrastructure.EF
{
    public class EfOptions
    {
        public string ConnectionString { get; set; }
        public bool InMemory { get; set; }
    }
}