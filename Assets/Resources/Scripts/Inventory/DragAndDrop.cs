using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;


namespace Assets.Resources.Scripts.Inventory
{
    public class DragAndDrop : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler {
        [SerializeField] private GameObject _Case;
        [SerializeField] private UnityEngine.Camera mainCamera;
        [SerializeField] private GameObject hoverHandler;
        [SerializeField] private Transform parentDrag;

        public void OnDrag(PointerEventData eventData)
        {
            hoverHandler.SetActive(false);

            _Case.transform.position = mainCamera.ScreenToWorldPoint(new Vector3(eventData.position.x, eventData.position.y, 1));
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            Debug.Log("Begin Drag");
    
            hoverHandler.SetActive(false);

            List<RaycastResult> results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(eventData, results);

            foreach (var item in results)
            {                
                if(item.gameObject.name == "Item")
                {
                    _Case = item.gameObject;
                    break;
                }
            }

            parentDrag = _Case.transform.parent;
            _Case.transform.SetParent(transform.root);
            _Case.transform.SetAsLastSibling();
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            Debug.Log("End Drag");
         
            hoverHandler.SetActive(true);
         
            _Case.transform.SetParent(parentDrag);
        }
    }
}