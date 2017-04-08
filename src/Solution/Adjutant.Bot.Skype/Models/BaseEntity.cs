using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Adjutant.Bot.Skype.Models
{
    public class BaseEntity
    {
        public ActionEnum Action { get; set; }
    }

    public enum ActionEnum
    {
        Connect,
        Status,
        PullRequest
    }
}