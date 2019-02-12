if ( LoadRequiredAddOn ("Item_Skis") == $Error::None )
{
	exec ("./Support_Lightning.cs");
}
else
{
	error ("ERROR: Missing required add-on Item_Skis!");
	messageAll ('', "Support_Lightning - ERROR: Missing required add-on Item_Skis!");
}
