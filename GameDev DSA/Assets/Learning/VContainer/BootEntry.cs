using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public class BootEntry : IStartable
{
    //private IScoreService _service;
    private BootExit bootExit;
    public BootEntry(BootExit service)
    {
        this.bootExit = service;
        //_service = service;
    }

    public void Start()
    {
        Debug.Log("BootExit.Timer() has started!");
        //_service.AddScore(10);
        //Debug.Log($"Score: {_service._score}");
    }
}
