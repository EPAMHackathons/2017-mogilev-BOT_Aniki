﻿using Adjutant.Bot.Skype.Domain;
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
			var result = instance.Parse("pull_request #254345 BotAniki 2d");
		} 
	}
}
