using System;
using System.Text;

namespace zz_Cs2GenLinqToXml_code
{
	[Serializable]
	public class students
	{
		private studentCollection _students;

		[System.ComponentModel.Browsable(true)]
		public studentCollection students
		{
			get { return _students; }
			set { _students = value; }
		}

		public students()
        {       
			this.students = new studentCollection();
		}
		public students(studentCollection students)
		{
			this.students = students;
		}

	}
}
