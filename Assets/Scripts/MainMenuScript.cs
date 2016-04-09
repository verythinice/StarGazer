using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenuScript : MonoBehaviour {

	public string gameSceneName;
    public GameObject mainMenu;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void StartGameScene () {
		SceneManager.LoadScene (gameSceneName);
	}

	public static void EndGame () {
		Application.Quit ();
	}

    public void ToggleMenuItem(GameObject menu)
    {
        mainMenu.SetActive(!mainMenu.activeSelf);
        menu.SetActive(!menu.activeSelf);
    }
}
