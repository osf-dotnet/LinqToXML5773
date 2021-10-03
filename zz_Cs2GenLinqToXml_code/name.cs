using System;
using System.Text;

namespace zz_Cs2GenLinqToXml_code
{
	[Serializable]
	public class name
	{
		private string _firstName;

		[System.ComponentModel.Browsable(true)]
		public string firstName
		{
			get { return _firstName; }
			set { _firstName = value; }
		}

		private string _lastName;

		[System.ComponentModel.Browsable(true)]
		public string lastName
		{
			get { return _lastName; }
			set { _lastName = value; }
		}

		public name()
		{
		}
		public name(string firstName,string lastName)
		{
			this.firstName = firstName;
			this.lastName = lastName;
		}

		public override string ToString()
		{
			return this.firstName + " " + this.lastName;
		}
		public class firstNameComparer : System.Collections.Generic.IComparer<name>
		{
			public SorterMode SorterMode;
			public firstNameComparer()
			{ }
			public firstNameComparer(SorterMode SorterMode)
			{
				this.SorterMode = SorterMode;
			}
			#region IComparer<name> Membres
			int System.Collections.Generic.IComparer<name>.Compare(name x, name y)
			{
				if (SorterMode == SorterMode.Ascending)
				{
					return y.firstName.CompareTo(x.firstName);
				}
				else
				{
					return x.firstName.CompareTo(y.firstName);
				}
			}
			#endregion
		}
		public class lastNameComparer : System.Collections.Generic.IComparer<name>
		{
			public SorterMode SorterMode;
			public lastNameComparer()
			{ }
			public lastNameComparer(SorterMode SorterMode)
			{
				this.SorterMode = SorterMode;
			}
			#region IComparer<name> Membres
			int System.Collections.Generic.IComparer<name>.Compare(name x, name y)
			{
				if (SorterMode == SorterMode.Ascending)
				{
					return y.lastName.CompareTo(x.lastName);
				}
				else
				{
					return x.lastName.CompareTo(y.lastName);
				}
			}
			#endregion
		}
	}
}
