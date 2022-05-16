using System.Threading.Tasks;

namespace Fotball_App.Contracts.Services
{
    public interface IActivationService
    {
        Task ActivateAsync(object activationArgs);
    }
}
