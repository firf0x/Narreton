using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Tilemaps;

public static class InterfaceManager{
    ///<summary>
    /// [Initialize(none);] none parametrs
    ///</summary>
    public static void Initialize(IInitialize initialize) => initialize.Initialize();
    public static async Task InitializeAsync(IInitialize initialize) => initialize.Initialize();
}