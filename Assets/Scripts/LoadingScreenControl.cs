using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScreenControl : MonoBehaviour {

    public GameObject loadingScreen;
    public Slider loadingSlider;
    public int lvl;

    AsyncOperation async;

    void Start()
    {
        StartCoroutine(LoadingScreen(lvl));
    }

    IEnumerator LoadingScreen(int lvl)
    {
        loadingScreen.SetActive(true);
        async = SceneManager.LoadSceneAsync(lvl);
        async.allowSceneActivation = false;

        while (async.isDone == false)
        {
            loadingSlider.value = async.progress;
            if (async.progress == 0.9f)
            {
                loadingSlider.value = 1f;
                async.allowSceneActivation = true;
            }
            yield return null;
        }
    }
}
