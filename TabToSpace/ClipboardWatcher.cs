using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

internal sealed class ClipboardWatcher : Control
{
	[DllImport( "user32.dll", SetLastError = true )]
	private static extern void AddClipboardFormatListener( IntPtr hwnd );

	[DllImport( "user32.dll", SetLastError = true )]
	private static extern void RemoveClipboardFormatListener( IntPtr hwnd );

	private readonly Action<string> m_onChange;

	public ClipboardWatcher( Action<string> onChange )
	{
		m_onChange = onChange;
		AddClipboardFormatListener( Handle );
	}

	public void End()
	{
		RemoveClipboardFormatListener( Handle );
	}

	protected override void WndProc( ref Message m )
	{
		if ( m.Msg == 0x31D )
		{
			m_onChange?.Invoke( Clipboard.GetText() );
			m.Result =  IntPtr.Zero;
		}
		else
		{
			base.WndProc( ref m );
		}
	}
}