using GeometryGym.Ifc;
using System;
using System.Collections.Generic;

namespace IFC_Converter.ClassLibrary
{
	public class IfcFilter
	{
		public string SearchString { get; set; }
		public NameChecker Checker { get; set; }

		public int FilterAndSaveFile(string ifcPath)
		{
			try
			{
				DatabaseIfc db = new DatabaseIfc(ifcPath);

				DuplicateOptions options = new DuplicateOptions(db.Tolerance);
				options.DuplicateDownstream = false;
				DatabaseIfc newDb = new DatabaseIfc(db);
				IfcProject project = newDb.Factory.Duplicate(db.Project, options) as IfcProject;

				options.DuplicateDownstream = true;

				List<IfcBuiltElement> modelElements = db.Project.Extract<IfcBuiltElement>();
				int count = 0;
				foreach(IfcBuiltElement el in modelElements)
				{
					if (Checker.Check(el.Name, SearchString))
					{
						count++;
						newDb.Factory.Duplicate(el, options);
					}
				}
				modelElements.Clear();

				if (count > 0)
				{
					newDb.WriteFile(FileIfc.AppendNameWithPostfix(ifcPath, FileIfc.CleanFileName(SearchString)));
				}
				db.Dispose();
				newDb.Dispose();
				return count;
			}
			catch
			{
				return 0;
			}
		}

	}
}
