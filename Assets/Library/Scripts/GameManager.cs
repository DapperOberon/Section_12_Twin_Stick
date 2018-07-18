using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

public class GameManager : MonoBehaviour {

	public bool bIsRecording = true;
	public bool bIsPaused = false;
	private float fixedDeltaTime;

	private void Start()
	{
		fixedDeltaTime = Time.fixedDeltaTime;
	}

	// Update is called once per frame
	void Update () {
		if (CrossPlatformInputManager.GetButton("Fire1")){
			bIsRecording = false;
		}
		else
		{
			bIsRecording = true;
		}

		if (CrossPlatformInputManager.GetButtonDown("Pause"))
		{
			bIsPaused = !bIsPaused;
		}

		PauseSystem();
	}

	private void PauseSystem()
	{
		if (bIsPaused)
		{
			Time.timeScale = 0;
			Time.fixedDeltaTime = 0;
		} else
		{
			Time.timeScale = 1;
			Time.fixedDeltaTime = fixedDeltaTime;
		}
	}

	private void OnApplicationPause(bool pause)
	{
		bIsPaused = pause;
	}
}
