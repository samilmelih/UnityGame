using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public GameObject storeUI;
    public GameObject inventoryUI;
    public GameObject mainMenuUI;
    public Transform loadingScreen;
    public Slider sldrLoading;
    public Text txtLoadingPerc;
    public Text txtLoadingText;

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
        storeUI.SetActive(true);
    }

    public void OpenInventory()
    {
        inventoryUI.SetActive(true);
    }
}
