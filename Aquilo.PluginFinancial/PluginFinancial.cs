using Aquilo.Common.interfaces;

namespace Aquilo.PluginFinancial
{
    public class PluginFinancial : IPluginApi
    {
        public Task<string> GetDataAsync() =>
            Task.FromResult("Data from plugin Financal!");
    }
}
