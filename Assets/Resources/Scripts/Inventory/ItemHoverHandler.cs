using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using Assets.Resources.Scripts.Inventory.Items;
using TMPro;

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
            if(item.gameObject.name == "Item")
            {
                _panelItemInfo.transform.position = mainCamera.ScreenToWorldPoint(new Vector3(vector.x, vector.y, 10));
                _panelItemInfo.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = $":Name:\n{item.gameObject.GetComponent<CellInventory>().item.Stats.Info.Name}";
                _panelItemInfo.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = $"Description : {item.gameObject.GetComponent<CellInventory>().item.Stats.Info.Description}";
            
                _panelItemInfo.SetActive(true);
                break;
            }
            else
                _panelItemInfo.SetActive(false);
        }
    }

    private void OnDisable() {
        _panelItemInfo.SetActive(false);
    }

    private void OnDestroy() => inputSystem.MousePositionEvent -= VisibleDescription;
}