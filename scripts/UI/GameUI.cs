using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
	public string menuLevel;
	[SerializeField] GameObject PausePanel;
	private bool isPaused;
	public void Restart()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
	
	public void GoMenu()
	{
		SceneManager.LoadScene(menuLevel);
	}
	
	public void PauseOn()
	{
		Time.timeScale = 0f;
		PausePanel.SetActive(true);
		isPaused = true;
	}
	public void PauseOff()
	{
		Time.timeScale = 1f;
		PausePanel.SetActive(false);
		isPaused = false;
	}
	
	// Update is called every frame, if the MonoBehaviour is enabled.
	protected void Update()
	{
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			if(isPaused)
			{
				PauseOff();
			}
			else
			{
				PauseOn();
			}
		}
	}
}
