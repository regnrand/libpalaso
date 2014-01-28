﻿using System;
using System.Collections.Generic;

namespace SIL.Archiving.IMDI.Lists
{
	/// <summary>
	///
	/// </summary>
	public static class ListConstructor
	{
		private static readonly Dictionary<string, IMDIItemList> _loadedLists = new Dictionary<string, IMDIItemList>();

		/// ---------------------------------------------------------------------------------------
		/// <summary>Constructs a list of IMDIListItems that can be used as the data source of a
		/// combo or list box</summary>
		/// <param name="listName">Name of the XML file that contains the desired list. It is suggested to
		///     use values from IMDI_Schema.ListTypes class. If not found on the local system, we will attempt
		///     to download from http://www.mpi.nl/IMDI/Schema.
		/// </param>
		/// <param name="uppercaseFirstCharacter">Make first character of each item uppercase</param>
		/// <param name="localize">Delegate to use for getting localized versions of the Text and
		/// Definition of list items. The parameters are: 1) the list name; 2) list item value;
		/// 3) "Definition" or "Text"; 4) default (English) value.</param>
		public static IMDIItemList GetList(string listName, bool uppercaseFirstCharacter, Func<string, string, string, string, string> localize)
		{
			listName = ListNameWithXmlExtension(listName);
			IMDIItemList list;

			if (!_loadedLists.TryGetValue(listName, out list))
			{
				list = new IMDIItemList(listName, uppercaseFirstCharacter);
				_loadedLists.Add(listName, list);
			}

			list.Localize(localize);

			return list;
		}

		/// ---------------------------------------------------------------------------------------
		/// <summary>>Returns a list of IMDIListItems that can also be used as the data source of a combo or list box</summary>
		/// <param name="listName"></param>
		/// <returns></returns>
		public static IMDIItemList GetClosedList(string listName, bool uppercaseFirstCharacter = true)
		{
			var list = GetList(listName, uppercaseFirstCharacter, null);
			// make sure this is a closed list
			list.Closed = true;
			return list;
		}

		/// ---------------------------------------------------------------------------------------
		internal static string ListNameWithXmlExtension(string listName)
		{
			if (!listName.EndsWith(".xml"))
				listName += ".xml";
			return listName;
		}
	}
}
