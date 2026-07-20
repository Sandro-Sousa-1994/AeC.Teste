namespace AeC.Teste.Web.Services.Interfaces
{
    public interface ICsvService
    {
        byte[] GenerateCsv<T>(IEnumerable<T> data) where T : class;
    }
}
