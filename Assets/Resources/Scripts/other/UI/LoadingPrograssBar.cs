using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingPrograssBar : MonoBehaviour
{
    public Image image;
    private void Awake() {
        image = GetComponent<Image>();
    }

    private void Update() {
        image.fillAmount = AsynLoaderScene.GetLoadingProgress();
    }
}
