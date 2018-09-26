using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
	public TriggerWrapper inter;

	void OnEnable()
	{
		var foundObjects = FindObjectsOfType<DeathTrigger>();
		foreach (var deathTrigger in foundObjects)
		{
			deathTrigger.CharacterSmashed += OnCharacterDied;
		}
		inter.CharactersInsideChanged += CheckLvlCompletion;
	}

	void OnDisable()
	{
		var foundObjects = FindObjectsOfType<DeathTrigger>();
		foreach (var deathTrigger in foundObjects)
		{
			deathTrigger.CharacterSmashed -= OnCharacterDied;
		}
		inter.CharactersInsideChanged -= CheckLvlCompletion;
	}

	public void OnCharacterDied()
	{
		Debug.Log("Ooops");
		LoadMainScene();
	}

	public void CheckLvlCompletion(int n)
	{
		if (n >= 2)
		{
			Debug.Log("Yay");
			LoadMainScene();
		}
	}

	private void LoadMainScene()
	{
		SceneManager.LoadScene(Constants.MainMenuSceneName);
	}
}
