using BTech.DataAccess.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace BTech.TestesUnitarios
{
    public class BaseTests
    {
		public BTContext db;

		public BaseTests()
		{
			db = new BTContext();
			MockData.AddMockData(db);
		}
	}
}
