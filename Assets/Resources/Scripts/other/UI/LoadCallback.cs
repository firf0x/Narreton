using UnityEngine;

public class LoadCallback : MonoBehaviour {
    private bool isFirstUpdate = true;

    private void Update() {
        if (isFirstUpdate) 
        {
            AsynLoaderScene.LoaderCallback();
            isFirstUpdate = false;
        }
    }
}