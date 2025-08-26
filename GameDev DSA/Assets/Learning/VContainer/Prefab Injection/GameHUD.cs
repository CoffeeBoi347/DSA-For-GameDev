using UnityEngine;
using VContainer;

public class GameHUD : MonoBehaviour
{
    private _IAnalyticsService analyticsService;
    private _IAudioService audioService;
    private _IScoreService scoreService;

    [Inject]
    public void Construct(_IScoreService _scoreService, _IAnalyticsService _analyticsService, _IAudioService _audioService)
    {
        this.scoreService = _scoreService;
        this.analyticsService = _analyticsService;
        this.audioService = _audioService;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            scoreService.Add(10);
            analyticsService.eventName = "InputPressed";
            audioService.Play("Jump");
        }
    }
}