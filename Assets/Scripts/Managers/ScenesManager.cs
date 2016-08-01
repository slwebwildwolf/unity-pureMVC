using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ScenesManager  {


	public static void LoadScene(string sceneName)
	{
		SceneManager.LoadScene (sceneName);
	}
	public static void LoadScene(int sceneBuildIndex)
	{
		SceneManager.LoadScene (sceneBuildIndex);
	}
}
