﻿using System;
using NUnit.Framework;

namespace SIL.TestUtilities
{
	/// <summary>
	/// A NUnit action attribute that enables offline mode for the SLDR during unit tests. This attribute can be
	/// placed on a test fixture, test assembly, or test to disable online access to the live SLDR server.
	/// </summary>
	[AttributeUsage(AttributeTargets.Method | AttributeTargets.Class | AttributeTargets.Interface | AttributeTargets.Assembly, AllowMultiple = true)]
	public class OfflineSldrAttribute : Attribute, ITestAction
	{
		private OfflineSldr _offlineSldr;
		private int _refCount;

		public void BeforeTest(TestDetails testDetails)
		{
			if (_refCount == 0)
				_offlineSldr = new OfflineSldr();
			_refCount++;
		}

		public void AfterTest(TestDetails testDetails)
		{
			_refCount--;
			if (_refCount == 0)
			{
				_offlineSldr.Dispose();
				_offlineSldr = null;
			}
		}

		/// <summary>
		/// Provides the target for the action attribute. This action will be run on all tests and suites (fixtures/assemblies).
		/// </summary>
		public ActionTargets Targets
		{
			get { return ActionTargets.Test | ActionTargets.Suite; }
		}
	}
}
