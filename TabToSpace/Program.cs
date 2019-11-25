using System;
using System.Windows.Forms;
using TabToSpace;

internal static class Program
{
	[STAThread]
	private static void Main()
	{
		var watcher   = new ClipboardWatcher( OnChange );
		var component = new Component1();

		component.mOnExit += () =>
		{
			watcher.End();
			Application.Exit();
		};

		Application.Run();
	}

	private static void OnChange( string text )
	{
		var result = TabToSpaceConvertor.Process( text, 4 );

		if ( text == result ) return;

		Clipboard.SetText( result );
	}
}