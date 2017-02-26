using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class eventracker : MonoBehaviour, ITrackableEventHandler
{
	private TrackableBehaviour mTrackableBehaviour;
	public Plane hud;

	void Start()
	{
		mTrackableBehaviour = GetComponent<TrackableBehaviour>();
		if (mTrackableBehaviour)
		{
			mTrackableBehaviour.RegisterTrackableEventHandler(this);
		}
	}

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
		}
		else
		{
			var player = GameObject.FindWithTag("quad");
			player.transform.position = new Vector3 (0, 0, 20);
		}
	}   
}