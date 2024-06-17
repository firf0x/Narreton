using UnityEngine;

public class Map : MonoBehaviour, IInitialize {
    
    public static bool IsVillage;
    public UnityInputSystem inputSystem;

    public void Initialize()
    {
        IsVillage = false;
    }
}