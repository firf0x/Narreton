using System;
using UnityEngine;

// working with Interactive Actions
public class WorkWithInteractiveMap : MonoBehaviour {
    
    public GameObject ImageUI;
    
    public void VisiblePick(Vector2Int coordinates)
    {
        if(CellList.cellList[coordinates.x, coordinates.y].IsVillage == true)
            ImageUI.SetActive(true);
        else
            ImageUI.SetActive(false);
    }
}