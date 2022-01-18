using UnityEngine;
using System.Collections;
namespace game_core{
/// <summary>
/// Object fade behaviour.
/// </summary>
public class objectFade : MonoBehaviour {

	public Vector3 	startMarker;
	public Vector3 	endMarker;
	public float 	speed = 1.0F;
	
	private float startTime;
	private float journeyLength;
	
	/// <summary>
	/// Use this for initialization.
	/// </summary>
	void Start() {
		startTime = Time.time;
		journeyLength = Vector3.Distance(startMarker, endMarker);
	}
	
	/// <summary>
	/// This method  is called once per frame.
	/// </summary>
	void Update() {
		float distCovered = (Time.time - startTime) * speed;
		float fracJourney = distCovered / journeyLength;
		transform.position = Vector3.Lerp(startMarker, endMarker,Mathf.SmoothStep(0.0f,1.0f,fracJourney));
	}
}
}