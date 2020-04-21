using System.Threading.Tasks;

namespace ChuckNorrisFacts
{
    public interface ILoginProvider
    {
        Task<string> LoginAsync();
    }
}