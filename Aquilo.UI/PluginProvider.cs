﻿using Aquilo.Common.interfaces;
using Autofac;

namespace Aquilo.UI
{
    public class PluginProvider
    {
        private readonly Lazy<IReadOnlyList<IPluginApi>> _lazyPlugins;

        public PluginProvider(Lazy<IEnumerable<IPluginApi>> lazyPlugins)
        {
            _lazyPlugins = new(lazyPlugins.Value.ToArray());
        }

        public IReadOnlyList<IPluginApi> GetPlugins()
        {
            return _lazyPlugins.Value;
        }
    }
    public sealed class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<PluginProvider>()
                .SingleInstance();
        }
    }
}
