
## Support_Lightning

Adds the ability to create lightning with ease.  This is purely for modders so don't think it's some extensive mod with a GUI and slash commands and shit.  It's not.

If you want just basic lightning without having to create your own, or if you want a template to base yours off of, check out [Lightning_Default](https://github.com/electrk/Lightning_Default).


### Usage

| Function | Explanation |
|----------|-------------|
| `createLightning (dataBlock);` | Creates a new `Lightning` object, deleting any existing ones first. |
| `destroyLightning ();` | Destroys any existing `Lightning` objects. |
| `changeLightningSetting ("prefName", "prefValue");` | Changes a lightning setting.  **Highly recommended** to use this instead of setting the variables manually, because some settings require creating a new `Lightning` object entirely. |


### Settings

These are the available settings.  It is **highly recommended** you use `changeLightningSetting` to set these.

*Example:*  `changeLightningSetting ("DamageTimeout", 5000);`

---

| Preference | Default Value | Comments |
|------------|---------------|----------|
| $Server::Lightning::DamageTimeout | 10000 | Players will still smoke if `BurnPlayers` is set to `true`, but no damage will be dealt. |
| $Server::Lightning::DamagePlayers | true |  |
| $Server::Lightning::DamageVehicles | true |  |
| $Server::Lightning::DamageItems | true |  |
| $Server::Lightning::PlayerDamageAmount | 50 |  |
| $Server::Lightning::VehicleDamageAmount | 199 |  |
| $Server::Lightning::ItemDamageAmount | 100 |  |
| $Server::Lightning::DamageMiniGameOnly | false |  |
| $Server::Lightning::TumblePlayers | true |  |
| $Server::Lightning::BurnPlayers | true |  |
| $Server::Lightning::PlayerBurnTime | 3 |  |
| $Server::Lightning::Scale | 512 512 300 |  |
| $Server::Lightning::Position | 0 0 0 | Requires creating a new `Lightning` object. |
| $Server::Lightning::Color | 1.0 1.0 1.0 1.0 | Requires creating a new `Lightning` object. |
| $Server::Lightning::FadeColor | 0.1 0.1 1.0 1.0 | Requires creating a new `Lightning` object. |
| $Server::Lightning::BoltStartRadius | 20 | How far away from the center the lightning starts to strike. |
| $Server::Lightning::StrikesPerMinute | 12 |
| $Server::Lightning::StrikeWidth | 2.5 |
| $Server::Lightning::StrikeRadius | 20 | How far away from the strike the lightning will be able to hurt you. |
| $Server::Lightning::ChanceToHitTarget | 0.5 | Chance an object has of getting struck when targetted by the lightning. |
| $Server::Lightning::UseFog | true | ??? |
