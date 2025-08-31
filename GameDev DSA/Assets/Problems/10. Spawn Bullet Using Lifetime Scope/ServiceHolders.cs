public class ScoreServiceHolder : IScoreServiceHolder
{
    public int Score {  get; set; }
    public void AddScore(int score)
    {
        Score += score;
        UnityEngine.Debug.Log($"[ScoreService] Current Score: {Score}.");
    }
}

public class AnalyticsServiceHolder : IAnalyticsServiceHolder
{
    public string eventName { get; set; }
    public void ShowEvent(string eventName)
    {
        UnityEngine.Debug.Log($"[AnalyticsService] Performing {eventName} now.");
    }
}

public interface IScoreServiceHolder
{
    public int Score { get; set;  }

    public void AddScore(int score);
}

public interface IAnalyticsServiceHolder
{
    public string eventName { get; set; }
    
    public void ShowEvent(string eventName);
}