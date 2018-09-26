using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
	public void OnStartButtonPressed()
	{
		SceneManager.LoadScene(Constants.MainSceneName);
	}

	public void OnExitButtonPressed()
	{
		Debug.Log("GG");
		Application.Quit();
	}
}
