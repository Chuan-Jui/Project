using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ButtonManager : MonoBehaviour {


	public void NewGameBtn(string newGamelevel)
	{
		SceneManager.LoadScene (newGamelevel);
    }

	public void ExitGameBtn()
	{
		Application.Quit();
    }
}