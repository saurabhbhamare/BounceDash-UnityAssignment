using UnityEngine;

[CreateAssetMenu(fileName = "BallDataSO", menuName = "Scriptable Objects/BallDataSO")]
public class BallDataSO : ScriptableObject
{
    public float MoveSpeed;
    public float BounceForce;
    public float GameOverThreshold;
    public float ExtendedBounceForce;
}
