using UnityEngine;
using System.Collections;
	
/// <summary>
/// Link canvas button class; manage external links.
/// </summary>
public class LinkButton : MonoBehaviour 
{
	public string 		link		=	"";

	/// <summary>
	/// Action this instance.
	/// </summary>
	public void action()
	{
		Application.OpenURL(link);
	}
}