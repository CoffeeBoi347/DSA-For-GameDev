using UnityEngine;

public interface _IScoreService { public int Score { get; set; } public void Add(int points); }
public interface _IAnalyticsService { public string eventName { get; set; } }
public interface _IAudioService { public void Play(string sfxName); }

public class _ScoreService : _IScoreService
{
    public int Score { get; set; }
    public void Add(int points)
    {
        Score += points;
    }

    public _ScoreService()
    {
        Debug.Log($"Current Score: {Score}");
    }
}

public class _AnalyticsService : _IAnalyticsService
{
    public string eventName { get; set; } 

    public _AnalyticsService()
    {
        Debug.Log($"Event called: {eventName}");
    }
}

public class _AudioService : _IAudioService
{
    public void Play(string sfxName) => Debug.Log($"Playing {sfxName}");

    public _AudioService()
    {
        Debug.Log("Audio Service initialized!");
    }
}