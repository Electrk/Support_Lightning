exec ("./settings.cs");
exec ("./lightningHit.cs");


function createLightning ( %dataBlock )
{
	destroyLightning ();

	// See settings.cs for a more detailed description of some of these fields
	%lightning = new Lightning (Lightning)
	{
		dataBlock         = %dataBlock;

		position          = $Server::Lightning::Position;

		scale             = $Server::Lightning::Scale;

		color             = $Server::Lightning::Color;
		fadeColor         = $Server::Lightning::FadeColor;

		boltStartRadius   = $Server::Lightning::BoltStartRadius;

		strikesPerMinute  = $Server::Lightning::StrikesPerMinute;
		strikeWidth       = $Server::Lightning::StrikeWidth;
		strikeRadius      = $Server::Lightning::StrikeRadius;

		chanceToHitTarget = $Server::Lightning::ChanceToHitTarget;

		useFog            = $Server::Lightning::UseFog;
	};
	MissionGroup.add (%lightning);
}

function destroyLightning ()
{
	%i = 1000;  // juuuust in case

	while ( isObject (Lightning)  &&  %i > 0 )
	{
		Lightning.delete ();
		%i--;
	}
}
