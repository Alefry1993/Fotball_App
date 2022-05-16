using System.Collections.Generic;
using System.Threading.Tasks;

using Fotball_App.Core.Models;

namespace Fotball_App.Core.Contracts.Services
{
    // Remove this class once your pages/features are using your data.
    public interface ISampleDataService
    {
        Task<IEnumerable<SampleOrder>> GetListDetailsDataAsync();
    }
}
