AddDamageType ("LightningStrike", '<bitmap:Add-Ons/Support_Lightning/lightning_CI> %1', 
	'%2 <bitmap:Add-Ons/Support_Lightning/lightning_CI> %1', 1, 1);

// Only these three object types are able to be struck by lightning, according to the engine
$TypeMasks::Damageable = $TypeMasks::PlayerObjectType | $TypeMasks::VehicleObjectType | $TypeMasks::DamagableItemObjectType;


// This is called by the engine whenever an object is struck by lightning
// (Please note that bricks cannot be struck by lightning because Badspot didn't add that functionality)

function LightningData::applyDamage ( %this, %lightningObject, %hitObject, %position, %normal )
{
	if ( !(%hitObject.getType () & $TypeMasks::Damageable) )
	{
		return;
	}

	if ( $Server::Lightning::DamageMiniGameOnly  &&  !isObject (getMiniGameFromObject (%hitObject)) )
	{
		return;
	}

	%hitObject.onLightningHit (%this, %lightningObject, %position, %normal);
}


function Player::onLightningHit ( %this, %lightningData, %lightningObj, %position, %normal )
{
	if ( $Server::Lightning::BurnPlayers )
	{
		%this.burnPlayer ($Server::Lightning::PlayerBurnTime);
	}

	if ( %this.isDisabled ()  ||  %this.getState () $= "Dead"  ||  %this.invulnerable )
	{
		return;
	}

	if ( !$Server::Lightning::DamagePlayers  &&  !$Server::Lightning::TumblePlayers )
	{
		return;
	}

	if ( %this.lastLightningHit !$= ""  &&  getSimTime () - %this.lastLightningHit < $Server::Lightning::DamageTimeout )
	{
		return;
	}


	// Get the mount before we damage the player
	%mount = %this.getObjectMount ();
	%this.lastLightningHit = getSimTime ();

	if ( $Server::Lightning::DamagePlayers )
	{
		%this.damage (%lightningObj, %position, $Server::Lightning::PlayerDamageAmount, %lightningData.damageType);
	}

	if ( $Server::Lightning::TumblePlayers )
	{
		tumble (%this);
	}

	if ( isObject (%mount)  &&  %mount.getType () & $TypeMasks::Damageable )
	{
		%lightningData.applyDamage (%lightningObj, %mount, %position, %normal);
	}

	%count = %this.getMountedObjectCount ();

	for ( %i = %count - 1;  %i >= 0;  %i-- )
	{
		%mountedObject = %this.getMountedObject (%i);

		if ( isObject (%mountedObject)  &&  %mountedObject.getType () & $TypeMasks::Damageable )
		{
			%lightningData.applyDamage (%lightningObj, %mountedObject, %position, %normal);
		}
	}
}

function Vehicle::onLightningHit ( %this, %lightningData, %lightningObj, %position, %normal )
{
	if ( %this.getDataBlock () == deathVehicle.getId () )
	{
		return;
	}

	if ( %this.lastLightningHit !$= ""  &&  getSimTime () - %this.lastLightningHit < $Server::Lightning::DamageTimeout )
	{
		return;
	}

	if ( !$Server::Lightning::DamageVehicles )
	{
		return;
	}


	// Get the mount before we damage the vehicle
	%mount = %this.getObjectMount ();
	%this.lastLightningHit = getSimTime ();

	%this.damage (%lightningObj, %position, $Server::Lightning::VehicleDamageAmount, %lightningData.damageType);

	if ( isObject (%mount)  &&  %mount.getType () & $TypeMasks::Damageable )
	{
		%lightningData.applyDamage (%lightningObj, %mount, %position, %normal);
	}

	%vehicleData = %this.getDataBlock ();

	if ( %vehicleData.numMountpoints > 0 )
	{
		%count = %this.getMountedObjectCount ();

		for ( %i = %count - 1;  %i >= 0;  %i-- )
		{
			%mountedObject = %this.getMountedObject (%i);

			if ( isObject (%mountedObject)  &&  %mountedObject.getType () & $TypeMasks::Damageable )
			{
				%lightningData.applyDamage (%lightningObj, %mountedObject, %position, %normal);
			}
		}
	}
}

function Item::onLightningHit ( %this, %lightningData, %lightningObj, %position, %normal )
{
	if ( %this.lastLightningHit !$= ""  &&  getSimTime () - %this.lastLightningHit < $Server::Lightning::DamageTimeout )
	{
		return;
	}

	if ( !$Server::Lightning::DamageItems )
	{
		return;
	}

	%this.lastLightningHit = getSimTime ();

	// Items are damageable if they have the correct typemask, but Blockland has no default support for it
	%this.damage (%lightningObj, %position, $Server::Lightning::ItemDamageAmount, %lightningData.damageType);
}
