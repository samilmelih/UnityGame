using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public GameObject storeUI;
    public GameObject mainMenuUI;
    public Transform loadingScreen;
    public Slider sldrLoading;
    public Text txtLoadingPerc;
    public Text txtLoadingText;

    void Start()
    {
        loadingScreen.gameObject.SetActive(false);
    }

    public void StartGame(int sceneIndex)
	{
        StartCoroutine(LoadingScreen(sceneIndex));
        loadingScreen.gameObject.SetActive(true);
        mainMenuUI.SetActive(false);
        txtLoadingText.text = "Loading!";
	}

    IEnumerator LoadingScreen(int sceneIndex)
    {
        AsyncOperation op = SceneManager.LoadSceneAsync(sceneIndex);

        while (!op.isDone)
        {
            float progressOp = Mathf.Clamp01(op.progress / .9f);
            sldrLoading.value = progressOp;
            txtLoadingPerc.text = progressOp * 100 + "%";
            yield return null;
        }

        txtLoadingText.text = "Loaded!";
    }

    public void OpenStore()
    {
        mainMenuUI.SetActive(false);
        storeUI.SetActive(true);
    }
}
