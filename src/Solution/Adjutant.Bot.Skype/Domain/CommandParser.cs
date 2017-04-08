using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;

namespace Adjutant.Bot.Skype.Domain
{
	public class CommandParser
	{
		//commad
		public string command;
		public string owner;
		public string repository;
		public string alias;

		public int Parse(string commandsLine)
		{
			string pattern = " ";
			String[] commandArgs = Regex.Split(commandsLine, pattern);
			command = commandArgs[0];

			switch (command.ToLower())
			{
				case "connect":
					GetArgumentsConnect(commandArgs);
					break;

				case "status":

					break;

				case "pull_request":

					break;
			}

			return default(int);
		}
		string GetArgumentsConnect(string[] commandArgs)
		{
			bool noName = false;
			string tempAlise = "";
			if (commandArgs.Length < 3)
				noName = !noName;

			foreach (string arg in commandArgs)
			{
				if (arg.Contains("http") && arg.Contains(".git"))
				{
					repository = arg;
					String[] elementsUrl = Regex.Split(arg, "/");
					owner = elementsUrl[3];
					tempAlise = elementsUrl[4];
				} else
				{
					if (!arg.Contains("connect"))
						alias = arg;
				}
			}

			if (noName)
				alias = tempAlise;

			return "";
		}
	}
}