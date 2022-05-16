using System;

namespace Fotball_App.Contracts.Services
{
    public interface IPageService
    {
        Type GetPageType(string key);
    }
}
