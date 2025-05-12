using UnityEngine;
using Unity.Cinemachine;

public class BallController
{
    private BallView ballView;
    private BallModel ballModel;
    private CinemachineCamera mainCam;
    public ScoreService scoreService;
    public LevelUI levelUI;

    public BallController(BallView ballView, CinemachineCamera mainCam, ScoreService scoreService, LevelUI levelUI, BallDataSO ballDataSO)
    {
        this.scoreService = scoreService;
        this.ballModel = new BallModel(ballDataSO);
        this.mainCam = mainCam;
        this.ballView = ballView;
        this.levelUI = levelUI;
        this.ballView.SetBallController(this);

    }
    //Movement Handling
    public void MoveLeft()
    {
        ballView.GetRigidbody().linearVelocity = new Vector2(-ballModel.moveSpeed, ballView.GetRigidbody().linearVelocity.y);
    }
    public void MoveRight()
    {
        ballView.GetRigidbody().linearVelocity = new Vector2(ballModel.moveSpeed, ballView.GetRigidbody().linearVelocity.y);
    }
    //Bounce Implementation
    public void Bounce()
    {
        this.ballView.GetRigidbody().AddForce(new Vector2(0, 1) * ballModel.bounceForce);
    }
    //ExtranBounce Implementation 
    public void ExtendedBounce()
    {
        this.ballView.GetRigidbody().AddForce(new Vector2(0, 1) * ballModel.bounceForce * 2);
    }
    //Screen Wrapping
    public void WrapBall(bool isLeftSide)
    {
        Vector3 newPosition = ballView.transform.position;

        if (isLeftSide)
        {
            newPosition.x = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;
        }
        else
        {
            newPosition.x = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
        }
        ballView.gameObject.transform.position = newPosition;

    }
    //Get BallPosition for ScreenWrapping
    public void CheckBallPositionOnTheScreen()
    {
        Vector3 screenPosition = Camera.main.WorldToViewportPoint(ballView.gameObject.transform.position);
        if (screenPosition.x < 0)
        {
            WrapBall(true);
        }
        else if (screenPosition.x > 1)
        {
            WrapBall(false);
        }
    }
    public BallModel GetBallModel()
    {
        return this.ballModel;
    }
}
