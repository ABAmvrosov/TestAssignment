using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour {
	
	public GameObject MainMenu;
    public GameObject SelectLevelMenu;
    //public GameObject OptionsMenu;
    //public GameObject AboutMenu;
    public GameObject OptionsButton;
    public GameObject AboutButton;
    public Text TitleText;

	private string mainTitle;

	void Awake() {
		mainTitle = TitleText.text;
		ShowMenu("mainMenu");
	}

	public void ShowMenu(string name) {
        MainMenu.SetActive(false);
        SelectLevelMenu.SetActive(false);
        //OptionsMenu.SetActive(false);
        //AboutMenu.SetActive(false);
        AboutButton.GetComponent<Button>().interactable = false;
        OptionsButton.GetComponent<Button>().interactable = false;

        switch (name) {
		    case "mainMenu":
			    MainMenu.SetActive (true);
			    TitleText.text = mainTitle;
			    break;
		    case "optionsMenu":
			    //OptionsMenu.SetActive(true);
			    TitleText.text = "Options";
			    break;
		    case "about":
			    //AboutMenu.SetActive(true);
			    TitleText.text = "About";
			    break;
            case "selectLevel":
                SelectLevelMenu.SetActive(true);
                TitleText.text = "Select Level";
                break;
		}
	}

	public void LoadLevel(string levelToLoad) {
        Messenger<string>.Broadcast("LoadLevel", levelToLoad);
    }

	public void QuitGame() {
		Application.Quit ();
	}
}
