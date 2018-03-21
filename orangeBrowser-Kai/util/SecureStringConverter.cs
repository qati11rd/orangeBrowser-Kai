using System;
using System.Runtime.InteropServices;
using System.Security;

namespace orangeBrowser_Kai.util
{
	class SecureStringConverter : IDisposable
	{
		private bool useUnicode;

		private IntPtr pointer;
		private char[] buffer;
		private string convertedResult;

		public SecureStringConverter(SecureString secureString, bool useUnicode = true)
		{
			this.useUnicode = useUnicode;

			this.buffer = new char[secureString.Length];

			if (this.useUnicode)
			{
				this.pointer = Marshal.SecureStringToCoTaskMemUnicode(secureString);
			}
			else
			{
				this.pointer = Marshal.SecureStringToCoTaskMemAnsi(secureString);
			}

			Marshal.Copy(this.pointer, this.buffer, 0, this.buffer.Length);

			this.convertedResult = new string(this.buffer);
		}

		public char[] GetBuffer()
		{
			return this.buffer;
		}

		public string GetString()
		{
			return this.convertedResult;
		}

		public void Dispose()
		{
			if (this.useUnicode)
			{
				Marshal.ZeroFreeCoTaskMemUnicode(this.pointer);
			}
			else
			{
				Marshal.ZeroFreeCoTaskMemAnsi(this.pointer);
			}
		}
	}
}
