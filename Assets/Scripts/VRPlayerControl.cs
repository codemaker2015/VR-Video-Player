// Copyright @ 2020 VSoft Technologies 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OmniVirt;

public class VRPlayerControl : MonoBehaviour
{

	VRPlayer vrPlayer;

	// Use this for initialization
	void Start ()
	{
		// Create VR Player instance
		vrPlayer = new VRPlayer ();

		// Register Callback for Video Playing Completion Event
		vrPlayer.OnVideoEnd += OnVRPlayerEnded;
		vrPlayer.OnUnloaded += OnVRPlayerUnloaded;

		// Play
		vrPlayer.LoadAndPlay (47793, true);  // Use your Content ID here
	}

	// Update is called once per frame
	void Update ()
	{

	}

	/*************************
    	 Callback for VR Player
    	*************************/

	// Video Playing Completion Event
	void OnVRPlayerEnded ()
	{
		// Automatically close the player after played
		if (vrPlayer != null)
			vrPlayer.Unload ();
	}

	// VR Player Unloaded Event
	void OnVRPlayerUnloaded ()
	{
		vrPlayer = null;		
	}
}