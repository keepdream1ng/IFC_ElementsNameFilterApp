using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace IFC_Converter.ClassLibrary
{
	public static class FileIfc
	{
		public static bool Exists(string filename)
		{
			var file = new FileInfo(filename);
			if (file.Exists &&  file.Extension.ToLower() == ".ifc")
			{
				return true;
			}
			return false;
		}

		public static string AppendNameWithPostfix(string fullPath, string postfix)
		{
			string directory = Path.GetDirectoryName(fullPath);
			string fileName = Path.GetFileNameWithoutExtension(fullPath);
			string extension = Path.GetExtension(fullPath);

			string newFileName = fileName + postfix + extension;
			return Path.Combine(directory, newFileName);
		}

		public static string CleanFileName(string fileName)
		{
			// Remove invalid characters from file name
			string invalidCharsRegex = string.Join("", Path.GetInvalidFileNameChars());
			string cleanedFileName = Regex.Replace(fileName, $"[{Regex.Escape(invalidCharsRegex)}]", "");

			// Remove leading and trailing whitespaces
			cleanedFileName = cleanedFileName.Trim();

			// Replace multiple spaces with a single space
			cleanedFileName = Regex.Replace(cleanedFileName, @"\s+", "_");

			int maxLength = 20;
			if (cleanedFileName.Length > maxLength)
			{
				cleanedFileName = cleanedFileName.Substring(0, maxLength);
			}

			return cleanedFileName;
		}
	}
}
