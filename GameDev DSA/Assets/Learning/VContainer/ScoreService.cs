using UnityEngine;

public class ScoreService : IScoreService
{
    private int score;
    public int _score => score;

    public void AddScore(int x) => score += x;
}

public interface IScoreService
{
    int _score { get; }
    void AddScore(int x);
}