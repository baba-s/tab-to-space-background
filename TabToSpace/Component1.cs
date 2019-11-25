using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace TabToSpace
{
	public partial class Component1 : Component
	{
		public Action mOnExit;
		
		public Component1()
		{
			InitializeComponent();
		}

		public Component1( IContainer container )
		{
			container.Add( this );

			InitializeComponent();
		}

		private void contextMenuStrip1_Click( object sender, EventArgs e )
		{
			if ( !( sender is ContextMenuStrip ) ) return;
			
			mOnExit?.Invoke();
		}
	}
}