namespace SymLinkWPF
{
	internal class SymLinkProcessor
	{

		internal static SymLinkObj Process_DEBUG(SymLinkObj symLink)
		{
			using (System.Diagnostics.Process process = new System.Diagnostics.Process())
			{
				process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
				process.StartInfo.FileName = "cmd.exe";
				process.StartInfo.Verb = "runas";
				process.StartInfo.Arguments = symLink.RetrieveCommandString();
				process.StartInfo.UseShellExecute = false;
				process.StartInfo.RedirectStandardOutput = true;
				process.StartInfo.RedirectStandardError = true;
				//* Set your output and error (asynchronous) handlers
				//process.OutputDataReceived += (s, e) => symLink.Messages.Add(Enumerations.MessageType.SystemError, e.Data);
				//process.ErrorDataReceived += (s, e) => symLink.Messages.Add(Enumerations.MessageType.Info, e.Data);
				process.OutputDataReceived += (s, e) => symLink.Messages.Add(e.Data);
				process.ErrorDataReceived += (s, e) => symLink.Messages.Add(e.Data);
				//* Start process and handler
				process.Start();
				process.BeginOutputReadLine();
				process.BeginErrorReadLine();
				process.WaitForExit();
			}
			return symLink;
		}
		//internal static string TryProcess(SymLinkObj symLink)
		//{
		//	(string outputMessage, string errorMessage) messages;
		//	(bool isLinkValid, bool isTargetValid) = ValidatePath(symLink);
		//	if (isLinkValid && isTargetValid)
		//	{
		//		messages = Process(symLink);
		//		return ProcessMessages(messages);
		//	}
		//	else
		//	{
		//		return "";
		//		//if (!isLinkValid && !isTargetValid)
		//		//{
		//		//	return "Invalid link and target";
		//		//}
		//		//else if ()
		//		//{

		//		//}
		//	}
		//}

		//private static string ProcessMessages((string outputMessage, string errorMessage) messages)
		//{
		//	string message = string.Empty;
		//	if (string.IsNullOrEmpty(messages.errorMessage))
		//	{
		//		message += "ERROR: " + messages.errorMessage;
		//	}
		//	if (string.IsNullOrEmpty(messages.outputMessage))
		//	{
		//		message += "INFO: " + messages.outputMessage;
		//	}

		//	return message;
		//}

		//internal static SymLinkObj Process(SymLinkObj symLink)
		//{
		//	using (System.Diagnostics.Process process = new System.Diagnostics.Process())
		//	{
		//		process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
		//		process.StartInfo.FileName = "cmd.exe";
		//		process.StartInfo.Verb = "runas";
		//		process.StartInfo.Arguments = symLink.RetrieveCommandString();
		//		process.StartInfo.UseShellExecute = false;
		//		process.StartInfo.RedirectStandardOutput = true;
		//		process.StartInfo.RedirectStandardError = true;
		//		//* Set your output and error (asynchronous) handlers
		//		process.OutputDataReceived += (s, e) => symLink.Messages.Add(Enumerations.MessageType.SystemError, e.Data);
		//		process.ErrorDataReceived += (s, e) => symLink.Messages.Add(Enumerations.MessageType.Info, e.Data);
		//		//* Start process and handler
		//		process.Start();
		//		process.BeginOutputReadLine();
		//		process.BeginErrorReadLine();
		//		process.WaitForExit();
		//	}
		//	return symLink;
		//}

		//internal static SymLinkObj ValidatePath(SymLinkObj symLink)
		//{
		//	switch (symLink.IsDirJunction)
		//	{
		//		case true:
		//			ValidateAsDirJunction();
		//			break;
		//		case false:
		//			ValidateAsFileJunction();
		//			break;
		//		default:
		//			break;
		//	}

		//	return symLink;

		//	void ValidateAsDirJunction()
		//	{
		//		if (System.IO.Directory.Exists(symLink.Link))
		//		{
		//			symLink.Messages.Add(Enumerations.MessageType.ErrorDetail, MessageStrings.LinkAlreadyExists);
		//		}
		//		if (System.IO.Directory.Exists(symLink.Target))
		//		{
		//			symLink.Messages.Add(Enumerations.MessageType.ErrorDetail, MessageStrings.TargetAlreadyExists);
		//		}
		//	}

		//	void ValidateAsFileJunction()
		//	{
		//		if (System.IO.File.Exists(symLink.Link))
		//		{
		//			symLink.Messages.Add(Enumerations.MessageType.ErrorDetail, MessageStrings.LinkAlreadyExists);
		//		}
		//		if (System.IO.File.Exists(symLink.Target))
		//		{
		//			symLink.Messages.Add(Enumerations.MessageType.ErrorDetail, MessageStrings.TargetAlreadyExists);
		//		}
		//	}
		//}
	}
}
