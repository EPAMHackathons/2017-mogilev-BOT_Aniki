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
                    return CreatePullRequestsModel(commandArgs);
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
                    //repositoryName = elementsUrl[4].Replace(gitHost, "");
                }
                else
                {
                    if (!arg.Contains(command_connect))
                        alias = arg;
                }
            }

            if (noName)
                alias = tempAlise;

            result.Action = ActionEnum.Connect;
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


            alias = commandArgs[1];

            if (alias.Contains("http://") || alias.Contains("https://"))
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

                //ограничение по времени 99часов или 99дней
                string pattern_time = "\\d*d";
                string pattern_date = "\\d*d";

                Regex regex_time = new Regex(pattern_time);
                Regex regex_date = new Regex(pattern_date);
                if (regex_time.IsMatch(arg) || regex_date.IsMatch(arg))
                    timePeriod = GetTimeInString(arg);

            }

            result.Action = ActionEnum.Status;
            result.Alias = alias;
            result.Owner = owner;
            result.RepositoryUrl = repositoryUrl;
            result.RepositoryName = repositoryName;
            result.TimePeriod = timePeriod;
            result.Users = users;

            return result;
        }

        public BaseEntity CreatePullRequestsModel(string[] commandArgs)
        {
            var result = new ConnectRequetsModel();
            int idPrid = 0;
            string alias = null;
            int timePeriod = 0;

            alias = commandArgs[1];

            foreach (string arg in commandArgs)
            {
                string pattern_time = "\\d*d";
                string pattern_date = "\\d*d";

                Regex regex_time = new Regex(pattern_time);
                Regex regex_date = new Regex(pattern_date);
                if (regex_time.IsMatch(arg) || regex_date.IsMatch(arg))
                    timePeriod = GetTimeInString(arg);

                string patternId = "#\\d*";

                Regex regex = new Regex(patternId);
                if (regex.IsMatch(arg))
                    idPrid = Int32.Parse(arg.Replace("#",""));
            }

            result.Action = ActionEnum.PullRequest;
            result.iDUserPrid = idPrid;
            result.Alias = alias;
            result.TimePeriod = timePeriod;

            return result;
        }


        public int GetTimeInString(string arg)
        {
            string hourIndex = "h";
            string dayIndex = "d";
            int time = 0;

            if (arg.Length < 4)
            {
                if (arg.Contains(hourIndex))
                {
                    string str_val_time = arg.Replace(hourIndex, "");
                    time = Int32.Parse(str_val_time);
                }

                if (arg.Contains(dayIndex))
                {
                    string str_val_time = arg.Replace(dayIndex, "");
                    time = Int32.Parse(str_val_time) * 24;
                }
            }
            return time;
        }
    }
}