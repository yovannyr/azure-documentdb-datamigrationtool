﻿using Microsoft.DataTransfer.Basics;
using Microsoft.DataTransfer.WpfHost.Extensibility.Basics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace Microsoft.DataTransfer.MongoDb.Wpf.Source.Mongoexport
{
    sealed class MongoexportFileSourceAdapterInternalConfigurationProvider : DataAdapterValidatableConfigurationProviderBase<MongoexportFileSourceAdapterConfiguration>
    {
        protected override UserControl CreatePresenter(MongoexportFileSourceAdapterConfiguration configuration)
        {
            return new MongoexportFileSourceAdapterConfigurationPage() { DataContext = configuration };
        }

        protected override UserControl CreateSummaryPresenter(MongoexportFileSourceAdapterConfiguration configuration)
        {
            return new MongoexportFileSourceAdapterConfigurationSummaryPage { DataContext = configuration };
        }

        protected override MongoexportFileSourceAdapterConfiguration CreateValidatableConfiguration()
        {
            return new MongoexportFileSourceAdapterConfiguration();
        }

        protected override void PopulateCommandLineArguments(MongoexportFileSourceAdapterConfiguration configuration, IDictionary<string, string> arguments)
        {
            Guard.NotNull("configuration", configuration);
            Guard.NotNull("arguments", arguments);

            arguments.Add(MongoexportFileSourceAdapterConfiguration.FilesPropertyName, String.Join(";", configuration.Files.Select(f => f.Replace(";", @"\;"))));
        }
    }
}
