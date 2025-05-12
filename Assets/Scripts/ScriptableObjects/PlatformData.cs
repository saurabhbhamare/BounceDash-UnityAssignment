using UnityEngine;

[CreateAssetMenu(fileName = "PlatformData", menuName = "Scriptable Objects/PlatformData")]
public class PlatformData : ScriptableObject
{
    public int StartingPlatformCount;
    public float PlatformSpawnDistacne;
    public float LowestPlatformY;
    public float HighestPlatformY;
    public float ItemSpawnProbability;
    public float MinPlatformWidth;
    public float MaxPlatformWidth;
    public float ItemSpawnOffset;
    public float PlatformYScale;
    public float InitialHighestPlatformY;
    public float YOffsetBetweenTwoPlatforms;
    public float MinRandomPlatformSpawn;
    public float MaxRandomPlatformSpawn;
}
