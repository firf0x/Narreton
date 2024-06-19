using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class AsynLoaderScene
{
    private class LoadingMonoBehaviour : MonoBehaviour {}
    public enum Scene
    {
        MainScene,
        LoadScene,
        MenuScene,
    }

    public static Action onLoaderCallback;
    public static AsyncOperation loadingAsyncOperation;

    public static void Load(Scene scene)
    {
        onLoaderCallback = () => {
            GameObject loadingGameObject = new GameObject("Loading GameObject");
            loadingGameObject.AddComponent<LoadingMonoBehaviour>().StartCoroutine(LoadSceneAsync(scene));
            
        };
    }

    private static IEnumerator LoadSceneAsync(Scene scene)
    {  
        yield return null;
        loadingAsyncOperation = SceneManager.LoadSceneAsync(scene.ToString());
        while (!loadingAsyncOperation.isDone)
        {
            yield return null;
        }
    }

    public static float GetLoadingProgress()
    {
        if(loadingAsyncOperation != null)
        {
            return loadingAsyncOperation.progress;
        }
        else
        {
            return 1f;
        }
    }

    public static void LoaderCallback()
    {
        if(onLoaderCallback != null)
        {
            onLoaderCallback();
            onLoaderCallback = null;
        }
    }
}
