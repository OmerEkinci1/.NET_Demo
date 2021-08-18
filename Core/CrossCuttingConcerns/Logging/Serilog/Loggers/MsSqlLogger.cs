using Core.CrossCuttingConcerns.Logging.Log4Net;
using Core.Utilities.IoC;
using Microsoft.Extensions.Configuration;
using global::Serilog;
using Serilog.Sinks.MSSqlServer;
using System;
using System.Collections.Generic;
using System.Text;
using Core.CrossCuttingConcerns.Logging.Serilog.ConfigurationModels;

namespace Core.CrossCuttingConcerns.Logging.Serilog.Loggers
{
	public class MsSqlLogger : LoggerServiceBase
	{
		public MsSqlLogger()
		{
			var configuration = ServiceTool.ServiceProvider.GetService<IConfiguration>();

			var logConfig = configuration.GetSection("SeriLogConfigurations:MsSqlConfiguration")
					.Get<MsSqlConfiguration>() ?? throw new Exception(Utilities.Messages.SerilogMessages.NullOptionsMessage);
			var sinkOpts = new MSSqlServerSinkOptions { TableName = "Logs", AutoCreateSqlTable = true };

			var columnOpts = new ColumnOptions();
			columnOpts.Store.Remove(StandardColumn.Message);
			columnOpts.Store.Remove(StandardColumn.Properties);

			var seriLogConfig = new LoggerConfiguration()
					.WriteTo.MSSqlServer(connectionString: logConfig.ConnectionString, sinkOptions: sinkOpts, columnOptions: columnOpts)
					.CreateLogger();

			Logger = seriLogConfig;
		}
	}
}
