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

	return %lightning;
}

function destroyLightning ()
{
	%safety = 1000;  // juuuust in case

	while ( isObject (Lightning)  &&  %safety > 0 )
	{
		Lightning.delete ();
		%safety--;
	}

	if ( %safety <= 0 )
	{
		error ("ERROR: destroyLightning () - 1000 or more Lightning objects!");
	}
}

// Clone current object (by McTwist)
function SimObject::clone ( %this, %name )
{
	%this    = %this.getID ();
	%oldName = %this.getName ();
	%name    = %name !$= "" ? %name : %oldName;

	%this.setName (__CLONE_OBJECT__);
	%obj = new (%this.getClassName ()) (%name : __CLONE_OBJECT__);
	%this.setName (%oldName);

	return %obj;
}
