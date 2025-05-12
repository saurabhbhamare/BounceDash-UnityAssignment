using UnityEngine;

public class BallModel
{

    //Ball Data
    public float gameOverThreshold;
    public float highestYReached;
    public float moveSpeed;
    public float bounceForce;
    public float extentedBounceForce;
    public float yCollisionNormalBounce;
    public BallModel(BallDataSO ballDataSO)
    {
        gameOverThreshold = ballDataSO.GameOverThreshold;
        moveSpeed = ballDataSO.MoveSpeed;
        bounceForce = ballDataSO.BounceForce;
        highestYReached = 0f;
        extentedBounceForce = ballDataSO.ExtendedBounceForce;
        yCollisionNormalBounce = 0.5f;
    }
}
