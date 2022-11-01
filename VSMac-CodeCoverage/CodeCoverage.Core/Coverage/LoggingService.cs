﻿using System;

namespace CodeCoverage.Core
{
	public interface ILoggingService
	{
    string Log { get; }
    event EventHandler<string> Logged;
    event EventHandler Cleared;
    void Clear();
		void Info(string message);
		void Warn(string message);
		void Error(string message);
		void Echo(string message);
	}

	public class LoggingService : ILoggingService
	{
		const string Copyright = "Made by Arthur Demanuele - 2021 \n Updated by Alex Sorokoletov - 2022 \n";

		public string Log { get; private set; } = Copyright;
		public event EventHandler<string> Logged;
		public event EventHandler Cleared;

		public void Clear()
		{
			Log = Copyright;
			Cleared?.Invoke(this, new EventArgs());
		}

		public void Info(string message)
		{
			var m = $"\n{message}";
			Log += m;
			Logged?.Invoke(this, m);
		}

		public void Warn(string message)
		{
			var m = $"\nWARN:\n{message}";
			Log += m;
			Logged?.Invoke(this, m);
		}

		public void Error(string message)
		{
			var m = $"\nERROR:\n{message}";
			Log += m;
			Logged?.Invoke(this, m);
		}

		public void Echo(string message)
		{
			var m = $"\nECHO:\n{message}";
			Log += m;
			Logged?.Invoke(this, m);
		}
	}
}
