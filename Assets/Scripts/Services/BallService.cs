using UnityEngine;
using Unity.Cinemachine;

public class BallService
{

    private BallDataSO ballDataSO;
    private BallView ballView;
    private BallController ballController;
    private CinemachineCamera followCam;
    private ScoreService scoreService;
    private LevelUI levelUI;
    public BallService(BallDataSO ballDataSO, BallView ballView, ScoreService scoreService, LevelUI levelUI)
    {
        this.ballDataSO = ballDataSO;
        this.ballView = ballView;
        this.scoreService = scoreService;
        this.levelUI = levelUI;
        SpawnBall();
    }
    private void SpawnBall()
    {
        ballController = new BallController(ballView, followCam, scoreService, levelUI, ballDataSO);
    }
}
