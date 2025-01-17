using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManagemnet : MonoBehaviour
{
	public GameObject ControllersPanel, aboutGamePanel, MainPanel;
	public string menuLevel, gameLevel;
    // Start is called before the first frame update
    void Start()
	{
		if(SceneManager.GetActiveScene().name == menuLevel)
		{
			ControllersPanel.SetActive(false);
	    	aboutGamePanel.SetActive(false);
		}
	    
    }

	public void Play()
	{
		SceneManager.LoadScene(gameLevel);
	}
	
	public void ControllersShow()
	{
		MainPanel.SetActive(false);
		ControllersPanel.SetActive(true);
	}
	
	public void CloseControllers()
	{
		ControllersPanel.SetActive(false);
		MainPanel.SetActive(true);
	}
	public void aboutGameShow()
	{
		MainPanel.SetActive(false);
		aboutGamePanel.SetActive(true);
	}
	
	public void CloseAboutGame()
	{
		aboutGamePanel.SetActive(false);
		MainPanel.SetActive(true);
	}
	
	public void Exit()
	{
		Application.Quit();
	}

}
