using System;
using System.Text;

namespace zz_Cs2GenLinqToXml_code
{
	[Serializable]
	public class student
	{
		private int _id;

		[System.ComponentModel.Browsable(true)]
		public int id
		{
			get { return _id; }
			set { _id = value; }
		}

		private string _name;

		[System.ComponentModel.Browsable(true)]
		public string name
		{
			get { return _name; }
			set { _name = value; }
		}

		public student()
		{
		}
		public student(int id,string name)
		{
			this.id = id;
			this.name = name;
		}

		public override string ToString()
		{
			return this.name;
		}
		public class nameComparer : System.Collections.Generic.IComparer<student>
		{
			public SorterMode SorterMode;
			public nameComparer()
			{ }
			public nameComparer(SorterMode SorterMode)
			{
				this.SorterMode = SorterMode;
			}
			#region IComparer<student> Membres
			int System.Collections.Generic.IComparer<student>.Compare(student x, student y)
			{
				if (SorterMode == SorterMode.Ascending)
				{
					return y.name.CompareTo(x.name);
				}
				else
				{
					return x.name.CompareTo(y.name);
				}
			}
			#endregion
		}
	}
}
