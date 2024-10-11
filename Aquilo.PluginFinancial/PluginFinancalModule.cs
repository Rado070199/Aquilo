using Autofac;

namespace Aquilo.PluginFinancial
{
    public sealed class PluginFinancalModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<PluginFinancial>()
                .AsImplementedInterfaces()
                .SingleInstance();
        }
    }
}
