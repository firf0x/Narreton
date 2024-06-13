using UnityEngine;
using UnityEngine.Tilemaps;

public static class InterfaceManager{
    ///<summary>
    /// [Initialize(none);] none parametrs
    ///</summary>
    public static void Initialize(IInitialize initialize) => initialize.Initialize();
}