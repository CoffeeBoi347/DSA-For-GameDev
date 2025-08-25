using System;
using UnityEngine;
public class BootExit : IDisposable
{
    private readonly float startTime;

    public BootExit()
    {
        startTime = Time.time;
        Debug.Log($"BootExit -> Timer started! {startTime}.");
    }

    public void Dispose()
    {
        Debug.Log($"Dispose called! Timer ran for {Time.time - startTime} seconds.");
    }
}
