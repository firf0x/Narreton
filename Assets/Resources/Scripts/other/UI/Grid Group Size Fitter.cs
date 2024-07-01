using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GridGroupSizeFitter : MonoBehaviour
{
    public Canvas canvas;
    public Vector2 baseCells = new Vector2(1920, 1080);
    private Vector2 baseCellSize; // In editor Cell Size for GridLayoutComponent
    private Vector2 baseCellSpacing; // In editor Cell Spacing for GridLayoutComponent
    private GridLayoutGroup layoutGroup; //Component
    private void Start()
    {
        layoutGroup = GetComponent<GridLayoutGroup>();
        baseCellSize = layoutGroup.cellSize;
        baseCellSpacing = layoutGroup.spacing;
    }
    
    private void Update()
    {
        Vector2 screenSize = new Vector2(Screen.width, Screen.height); // Current screen size
        layoutGroup.cellSize = (screenSize / baseCells) * baseCellSize;
        layoutGroup.spacing = (screenSize / baseCells) * baseCellSpacing;
    }
}
