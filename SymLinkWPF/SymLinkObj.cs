using System.Collections.Generic;

namespace SymLinkWPF
{
	internal class Enumerations
	{
		internal enum MessageType
		{
			SystemError,
			Info,
			ErrorDetail
		}
	}

	internal class SymLinkObj
	{
		#region Properties
		public string Link { get; set; }
		public string Target { get; set; }
		public bool IsDirJunction { get; set; }

		public List<string> Messages { get; set; }
		//public Dictionary<Enumerations.MessageType, string> Messages { get; set; }
		#endregion

		#region Constructors
		public SymLinkObj(bool isDirJunction = true)
		{
			IsDirJunction = isDirJunction ? true : false;
			//			Messages = new Dictionary<Enumerations.MessageType, string>();
			Messages = new List<string>();
		}

		public SymLinkObj(string link, string target, bool isDirJunction = true)
		{
			Link = link;
			Target = target;
			IsDirJunction = isDirJunction ? true : false;
			//Messages = new Dictionary<Enumerations.MessageType, string>();
			Messages = new List<string>();
		}
		#endregion

		#region Mutators
		public string RetrieveCommandString()
		{
			return ("/c mklink " + (IsDirJunction ? "/d " : "") + Link + " " + Target);
		}
		#endregion
	}
}
