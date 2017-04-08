using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;
using Adjutant.Bot.Skype.Models;
using System.Security.Policy;

namespace Adjutant.Bot.Skype.Domain
{
	public class CommandParser
	{
		//commad
		public string command;
		public string command_connect = "connect";
		string gitDom = ".git";

		public BaseEntity Parse(string commandsLine)
		{
			string pattern = " ";
			String[] commandArgs = Regex.Split(commandsLine, pattern);
			command = commandArgs[0];

			switch (command.ToLower())
			{
				case "connect":
					return CreateCommandModel(commandArgs);
				case "status":
					return CreateStatusModel(commandArgs);

				case "pull_request":

					break;
			}

			return default(BaseEntity);
		}

		public BaseEntity CreateCommandModel(string[] commandArgs)
		{
			var result = new ConnectRequetsModel();
			Url repository = null;
			string owner = null;
			string alias = null;
			string repositoryName = null;

			bool noName = false;
			string tempAlise = "";
			if (commandArgs.Length < 3)
				noName = !noName;

			foreach (string arg in commandArgs)
			{
				if (arg.Contains("http://") || arg.Contains("https://"))
				{
					repository = new Url(arg);
					String[] elementsUrl = Regex.Split(arg, "/");
					owner = elementsUrl[3];
					tempAlise = elementsUrl[4];
                    repositoryName = elementsUrl[4].Replace(gitDom, "");
                }
                else
				{
					if (!arg.Contains(command_connect))
						alias = arg;
				}
			}

			if (noName)
				alias = tempAlise;

			result.Alias = alias;
			result.Owner = owner;
			result.RepositoryUrl = repository;
			result.RepositoryName = repositoryName;

			return result;
		}

		public BaseEntity CreateStatusModel(string[] commandArgs)
		{
			var result = new ConnectRequetsModel();
			string alias = null;
			string owner = null;
			string repositoryName = null;
			Url repositoryUrl = null;
			int timePeriod = 0;
			List<string> users = new List<string>();

			string hourIndex = "h";
			string dayIndex = "d";

			alias = commandArgs[1];

			if (alias.Contains("http://")|| alias.Contains("https://"))
			{
				repositoryUrl = new Url(alias);
				String[] elementsUrl = Regex.Split(alias, "/");
				owner = elementsUrl[3];
				repositoryName = elementsUrl[4].Replace(gitDom, "");
				alias = repositoryName;
			}

			foreach (string arg in commandArgs)
			{
				if (arg.Contains("@"))
					users.Add(arg);

				//ограничение по времени 99ч или 99дней
				if (arg.Length < 4)
				{
					if (arg.Contains(hourIndex))
					{
						string str_val_time = arg.Replace(hourIndex, "");
						timePeriod = Int32.Parse(str_val_time);
					}

					if (arg.Contains(dayIndex))
					{
						string str_val_time = arg.Replace(dayIndex, "");
						timePeriod = Int32.Parse(str_val_time) * 24;
					}
				}
			}

			result.Alias = alias;
			result.Owner = owner;
			result.RepositoryUrl = repositoryUrl;
			result.RepositoryName = repositoryName;
			result.TimePeriod = timePeriod;
			result.Users = users;

			return result;
		}
    }
}