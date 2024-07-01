using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using Assets.Resources.Scripts.Inventory.Items;

public class ItemHoverHandler : MonoBehaviour
{
    [SerializeField] GameObject _panelItemInfo;
    [SerializeField] UnityInputSystem inputSystem;
    [SerializeField] Camera mainCamera;
    private Item localItem;

    private void Awake() {
        _panelItemInfo.SetActive(false);
        inputSystem.MousePositionEvent += VisibleDescription; 
    }

    private void VisibleDescription(Vector2 vector)
    {
        _panelItemInfo.SetActive(false);

        PointerEventData eventData = new PointerEventData(EventSystem.current);
        eventData.position = vector;
        
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);

        foreach (var item in results)
        {
            Debug.Log(item.gameObject.name);
            if(item.gameObject.name == "case")
            {
                _panelItemInfo.transform.position = mainCamera.ScreenToWorldPoint(new Vector3(vector.x, vector.y, 0));
                _panelItemInfo.SetActive(true);
                break;
            }
            else
                _panelItemInfo.SetActive(false);
        }
    }

    private void OnDestroy() => inputSystem.MousePositionEvent -= VisibleDescription;
}