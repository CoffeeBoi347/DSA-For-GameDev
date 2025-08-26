using UnityEngine;
using VContainer.Unity;

public class BasicTickable : ITickable
{
    public void Tick()
    {
        Debug.Log("Unity is calling me each frame!");
    }
}