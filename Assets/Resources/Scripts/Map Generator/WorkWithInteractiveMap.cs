using System;
using UnityEngine;
using UnityEngine.Tilemaps;

// working with Interactive Actions
public class WorkWithInteractiveMap : MonoBehaviour, IInitialize {
    
    public GameObject CameraObj;
    public GameObject ImageUI;
    public GameObject ImageTalk;

    public GameObject CaveTileMap;
    public GameObject VillageTileMap;
    private static GameObject caveTileMap;
    private static GameObject villageTileMap;

    private static Vector2Int position;

    public void Initialize()
    {
        caveTileMap = CaveTileMap;
        villageTileMap = VillageTileMap;
    }
    public void VisiblePick(Vector2Int coordinates)
    {
        position = coordinates;
        if(CellList.cellList[position.x, position.y].IsVillage == true)
            ImageUI.SetActive(true);
        else
            ImageUI.SetActive(false);
    }

    public void TalkPick(Vector2Int coordinates)
    {
        if(CellList.villageCellList[coordinates.x, coordinates.y].IsTalk == true)
            ImageTalk.SetActive(true);
        else
            ImageTalk.SetActive(false);
    }

    public void SwitchTileMap()
    {   
        if(Map.IsVillage == false && CellList.cellList[position.x, position.y].IsVillage == true)
        {
            caveTileMap.SetActive(false);
            villageTileMap.SetActive(true);
            CameraObj.transform.position = new Vector3(PlayerController.CurrentPositionInVillage.x, PlayerController.CurrentPositionInVillage.y, -10);
            Map.IsVillage = true;
        }
        else
        {
            caveTileMap.SetActive(true);
            villageTileMap.SetActive(false);
            CameraObj.transform.position = new Vector3(PlayerController.CurrentPosition.x, PlayerController.CurrentPosition.y, -10);
            Map.IsVillage = false;
        }
    }
}