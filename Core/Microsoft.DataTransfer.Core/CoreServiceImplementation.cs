﻿using Autofac;
using Autofac.Configuration;
using Microsoft.DataTransfer.Core.Autofac;
using Microsoft.DataTransfer.Core.Service;
using Microsoft.DataTransfer.Core.Statistics;
using Microsoft.DataTransfer.Extensibility;
using Microsoft.DataTransfer.ServiceModel;

namespace Microsoft.DataTransfer.Core
{
    /// <summary>
    /// Registrar of core data transfer service components implementation.
    /// </summary>
    public sealed class CoreServiceImplementation : Module
    {
        /// <summary>
        /// Registers components in the container.
        /// </summary>
        /// <param name="builder">The builder through which components can be registered.</param>
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterModule(new TypeLimitedComponentsConfigurationSettingsReader("dataTransfer.sources", typeof(IDataSourceAdapterFactory<>)))
                .RegisterModule(new TypeLimitedComponentsConfigurationSettingsReader("dataTransfer.sinks", typeof(IDataSinkAdapterFactory<>)));
            builder
                .RegisterSource(new DataAdapterFactoryAdaptersRegistrationSource());

            builder
                .RegisterType<TransferStatisticsFactory>()
                .As<ITransferStatisticsFactory>()
                .SingleInstance();

            builder
                .RegisterType<DataTransferAction>()
                .As<IDataTransferAction>()
                .SingleInstance();

            builder
                .RegisterType<DataTransferService>()
                .As<IDataTransferService>();
        }
    }
}
