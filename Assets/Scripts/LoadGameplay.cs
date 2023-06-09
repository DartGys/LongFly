using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGameplay : MonoBehaviour
{
    public string SceneToLoad;

    void Start()
    {
        StartCoroutine("LoadAsync");
    }

    public IEnumerator LoadAsync()
    {
        yield return new WaitForSeconds(1.5f);
        AsyncOperation LoadingOperation = SceneManager.LoadSceneAsync(SceneToLoad);
        LoadingOperation.allowSceneActivation = false;

        while (!LoadingOperation.isDone)
        {
            if (LoadingOperation.progress >= .9f && !LoadingOperation.allowSceneActivation)
            {
                yield return new WaitForSeconds(1.5f);
                LoadingOperation.allowSceneActivation = true;
            }
            yield return null;
        }

    }
}
