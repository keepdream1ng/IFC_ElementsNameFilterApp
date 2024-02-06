using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace IFC_Converter.ClassLibrary
{
	public class NameChecker
	{
		public NameFilterType FilterType
		{
			get { return _nameFilterType; }
			set
			{
				switch (value)
				{
					case NameFilterType.Equals:
						CheckDelegate = EqualsCheck;
						break;
					case NameFilterType.Contains:
						CheckDelegate = ContainsCheck;
						break;
					case NameFilterType.Contains_Any:
						CheckDelegate = ContainsAnyCheck;
						break;
					case NameFilterType.Regex_expression:
						CheckDelegate = CheckRegex;
						break;
					default:
						throw new NotImplementedException();
				}
				_nameFilterType = value;
			}
		}
		private NameFilterType _nameFilterType;
		private delegate bool FilterNameCheckerDelegate(string name, string searchString);
		private FilterNameCheckerDelegate CheckDelegate;
		private Dictionary<string, Regex> _regexCache = new Dictionary<string, Regex>();

		public bool Check(string name, string searchString)
		{
			return CheckDelegate(name, searchString);
		}

		private bool EqualsCheck(string name, string searchString)
		{
			return name == searchString;
		}

		private bool ContainsCheck(string name, string searchString)
		{
			return name.Contains(searchString);
		}
		private bool ContainsAnyCheck(string name, string searchString)
		{
			// Split the search string into words
			string[] searchWords = searchString.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
			
			// Check if any of the words from the search string are present in the name
			foreach (string word in searchWords)
			{
				if (name.Contains(word))
				{
					return true;
				}
			}
			
			return false;
		}

		private bool CheckRegex(string name, string searchString)
		{
			if (!_regexCache.TryGetValue(searchString, out Regex regex))
			{
				regex = new Regex(searchString);
				_regexCache[searchString] = regex;
			}

			return regex.IsMatch(name);
		}
	}
}
