using Adjutant.Bot.Skype.Domain;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adjutant.Bot.Skype.Tests
{
	[TestFixture]
	public class CommandParserTests
	{
		[Test]
		public void GetIssuesTest()
		{
			var instance = new CommandParser();
			var result = instance.Parse("connect https://github.com/EPAMHackathons/2017-mogilev-BOT_Aniki.git BotAniki");
		} 
	}
}
