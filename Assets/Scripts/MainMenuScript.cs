using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenuScript : MonoBehaviour {

	public string gameSceneName;
    public GameObject mainMenu;
    public GameObject title;

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

    public void ToggleMenuItemWithTitle(GameObject menu)
    {
        title.SetActive(!title.activeSelf);
        ToggleMenuItem(menu);
    }

    public void StartGameWithLevel(int i)
    {
        Application.LoadLevel(i);
    }

    public void StartGameWithName(string name)
    {
        Application.LoadLevel(name);
    }
}
