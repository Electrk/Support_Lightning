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
	if ( isObject (Lightning) )
	{
		Lightning.delete ();
	}

	if ( isObject (Lightning) )
	{
		error ("ERROR: destroyLightning () - More than one Lightning object!");
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
