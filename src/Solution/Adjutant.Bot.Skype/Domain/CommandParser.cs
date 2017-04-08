using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;
using Adjutant.Bot.Skype.Models;

namespace Adjutant.Bot.Skype.Domain
{
    public class CommandParser
    {
        //commad
        public string command;
        public string command_connect = "connect";

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
                    break;

                case "pull_request":

                    break;
            }

            return default(BaseEntity);
        }

        public BaseEntity CreateCommandModel(string[] commandArgs)
        {
            var result = new ConnectRequetsModel();
            string repository = null;
            string owner = null;
            string alias = null;
            string repositoryName = null;

            string gitHost = ".git";
            bool noName = false;
            string tempAlise = "";
            if (commandArgs.Length < 3)
                noName = !noName;

            foreach (string arg in commandArgs)
            {
                if (arg.Contains("http") && arg.Contains(gitHost))
                {
                    repository = arg;
                    String[] elementsUrl = Regex.Split(arg, "/");
                    owner = elementsUrl[3];
                    tempAlise = elementsUrl[4];
                    repositoryName = elementsUrl[4].Replace(gitHost, "");
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

            return result;
        }
    }
}