using System.Text;

internal static class TabToSpaceConvertor
{
	private static int GetNearestTabStop( int currentPosition, int tabLength )
	{
		if ( currentPosition % tabLength == 1 )
		{
			currentPosition += tabLength;
		}
		else
		{
			for ( int i = 0; i < tabLength; i++, currentPosition++ )
			{
				if ( ( currentPosition % tabLength ) == 1 )
				{
					break;
				}
			}
		}

		return currentPosition;
	}

	public static string Process( string input, int tabLength )
	{
		if ( string.IsNullOrEmpty( input ) ) return input;

		var output = new StringBuilder();

		int positionInOutput = 1;

		foreach ( var c in input )
		{
			switch ( c )
			{
				case '\t':
					int spacesToAdd = GetNearestTabStop( positionInOutput, tabLength ) - positionInOutput;
					output.Append( new string( ' ', spacesToAdd ) );
					positionInOutput += spacesToAdd;
					break;

				case '\n':
					output.Append( c );
					positionInOutput = 1;
					break;

				default:
					output.Append( c );
					positionInOutput++;
					break;
			}
		}
		return output.ToString();
	}
}