function defaultLightningSetting ( %prefName, %prefValue )
{
	if ( $Server::Lightning["::" @ %prefName] $= "" )
	{
		$Server::Lightning["::" @ %prefName] = %prefValue; 
	}
}

// Use this to change lightning settings
function changeLightningSetting ( %prefName, %prefValue )
{
	$Server::Lightning["::" @ %prefName] = %prefValue;

	if ( !isObject (Lightning) )
	{
		return;
	}

	// color, fadeColor, and position require you to recreate the lightning object in order to take effect

	if ( %prefName $= "Color"  ||  %prefName $= "FadeColor"  ||  %prefName $= "Position" )
	{
		createLightning (Lightning.getDataBlock ());
		return;
	}

	switch$ ( %prefName )
	{
		case "Scale":
			// setScale is not limited to 5 5 5 like it is for players
			Lightning.setScale (%prefValue);

		case "StrikesPerMinute":
			Lightning.strikesPerMinute = %prefValue;

		case "StrikeWidth":
			Lightning.strikeWidth = %prefValue;

		case "StrikeRadius":
			Lightning.strikeRadius = %prefValue;

		case "BoltStartRadius":
			Lightning.boltStartRadius = %prefValue;

		case "UseFog":
			Lightning.useFog = %prefValue;
	}
}


// Support_Lightning fields

defaultLightningSetting ("DamageTimeout", 10000);

defaultLightningSetting ("DamagePlayers", true);
defaultLightningSetting ("DamageVehicles", true);
defaultLightningSetting ("DamageItems", true);

defaultLightningSetting ("PlayerDamageAmount", 50);
defaultLightningSetting ("VehicleDamageAmount", 199);
defaultLightningSetting ("ItemDamageAmount", 100);

defaultLightningSetting ("DamageMiniGameOnly", false);

defaultLightningSetting ("TumblePlayers", true);

defaultLightningSetting ("BurnPlayers", true);
defaultLightningSetting ("PlayerBurnTime", 3);


// Actual engine-defined lightning fields

defaultLightningSetting ("Scale", "512 512 300");
defaultLightningSetting ("Position", "0 0 0");             // You need to recreate the lightning object to change this

defaultLightningSetting ("Color", "1.0 1.0 1.0 1.0");      // Same as above
defaultLightningSetting ("FadeColor", "0.1 0.1 1.0 1.0");  // Same as above

defaultLightningSetting ("BoltStartRadius", 20);           // How far away from the center the lightning starts to strike

defaultLightningSetting ("StrikesPerMinute", 12);
defaultLightningSetting ("StrikeWidth", 2.5);
defaultLightningSetting ("StrikeRadius", 20);              // How far away from the strike the lightning will be able 
                                                           // to hurt you

defaultLightningSetting ("ChanceToHitTarget", 0.5);        // Chance an object has of getting struck when targetted by 
                                                           // the lightning

defaultLightningSetting ("UseFog", true);                  // ???
