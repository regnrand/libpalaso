﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NUnit.Framework;
using Palaso.WritingSystems.Collation;

namespace Palaso.Tests.WritingSystems.Collation
{
	[TestFixture]
	public class SortingTests
	{
		[Test]
		public void IcuCollator_CBA_ABC()
		{
			var list = new List<string>();
			list.Add("c");
			list.Add("b");
			list.Add("a");
			list.Sort(new IcuRulesCollator(String.Empty));
			Assert.That(list[0], Is.EqualTo("a"));
			Assert.That(list[1], Is.EqualTo("b"));
			Assert.That(list[2], Is.EqualTo("c"));
		}

		[Test]
		public void System_CBA_ABC()
		{
			var list = new List<string>();
			list.Add("c");
			list.Add("b");
			list.Add("a");
			list.Sort(new SystemCollator(null));
			Assert.That(list[0], Is.EqualTo("a"));
			Assert.That(list[1], Is.EqualTo("b"));
			Assert.That(list[2], Is.EqualTo("c"));
		}

		[Test]
		public void IcuCollator_WithDashCBA_ABCDash()
		{
			var list = new List<string>();
			list.Add("-c");
			list.Add("c");
			list.Add("b");
			list.Add("a");
			list.Sort(new IcuRulesCollator(String.Empty));
			Assert.That(list[0], Is.EqualTo("a"));
			Assert.That(list[1], Is.EqualTo("b"));
			Assert.That(list[2], Is.EqualTo("c"));
			Assert.That(list[3], Is.EqualTo("-c"));
		}

		[Test]
		public void System_WithDashCBA_ABCDash()
		{
			var list = new List<string>();
			list.Add("-c");
			list.Add("c");
			list.Add("b");
			list.Add("a");
			list.Sort(new SystemCollator(null));
			Assert.That(list[0], Is.EqualTo("a"));
			Assert.That(list[1], Is.EqualTo("b"));
			Assert.That(list[2], Is.EqualTo("c"));
			Assert.That(list[3], Is.EqualTo("-c"));
		}

	}
}
