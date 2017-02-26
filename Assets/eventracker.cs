using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class eventracker : MonoBehaviour, ITrackableEventHandler
{
	private TrackableBehaviour mTrackableBehaviour;
	public Plane hud;
	public bool showing_target = false;

	void Start()
	{
		mTrackableBehaviour = GetComponent<TrackableBehaviour>();
		if (mTrackableBehaviour)
		{
			mTrackableBehaviour.RegisterTrackableEventHandler(this);
		}
	}

	void Update() {
		if (!showing_target) {

			var camera = GameObject.FindWithTag ("MainCamera");

			camera.transform.position = new Vector3 (0, 0, 0);
			camera.transform.rotation = new Quaternion (0, 0, 0, 0);
			camera.transform.localScale = new Vector3 (1, 1, 1);
			var arcamera = GameObject.FindWithTag("arcamera");

			arcamera.transform.position = new Vector3 (0,0,0);
			arcamera.transform.rotation = Quaternion.identity;
			arcamera.transform.localScale = new Vector3 (1, 1, 1);

		}}

	public void OnTrackableStateChanged(
		TrackableBehaviour.Status previousStatus,
		TrackableBehaviour.Status newStatus)
	{
		if (newStatus == TrackableBehaviour.Status.DETECTED ||
			newStatus == TrackableBehaviour.Status.TRACKED ||
			newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
		{
			var player = GameObject.FindWithTag("quad");
			player.transform.position = new Vector3 (900, 900, 900);
			showing_target = true;
		}
		else
		{
			showing_target = false;
			var player = GameObject.FindWithTag("quad");
			player.transform.position = new Vector3 (0, 0, 20);
			var camera = GameObject.FindWithTag("MainCamera");

			camera.transform.position = new Vector3 (0,0,0);
			camera.transform.rotation = Quaternion.identity;
			camera.transform.localScale = new Vector3 (1, 1, 1);
			var arcamera = GameObject.FindWithTag("arcamera");

			arcamera.transform.position = new Vector3 (0,0,0);
			arcamera.transform.rotation = Quaternion.identity;
			arcamera.transform.localScale = new Vector3 (1, 1, 1);
		}
	}   
}