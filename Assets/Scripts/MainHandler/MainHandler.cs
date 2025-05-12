using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Cinemachine;
using UnityEngine.UI;
using TMPro;
public class MainHandler : MonoBehaviour
{
    [Header("Prefab Views & Items")]
    [SerializeField] private PlatformView platformViewPrefab;
    [SerializeField] private BallView ballView;
    [SerializeField] private BallDataSO ballDataSO;
    [SerializeField] private PlatformData platformDataSO;
    //[SerializeField] private CinemachineCamera followCam;
    [SerializeField] private Item gem;

    [SerializeField] private SpawnItemSO spawnItemSO;

    [Header("Level UI")]
    [SerializeField] private LevelUI levelUI;
    // [SerializeField] GameObject gameOverPanel;

    [Header("Services")]
    private BallService ballService;
    private PlatformService platformService;
    private ScoreService scoreService;
    void Start()
    {
        SetTimeScale();
        InitializeServices();
    }
    //Services Initialization
    private void InitializeServices()
    {
        scoreService = new ScoreService(levelUI);
        ballService = new BallService(ballDataSO, ballView, scoreService, levelUI);
        platformService = new PlatformService(platformViewPrefab, gem, spawnItemSO, platformDataSO);
    }
    private void SetTimeScale()
    {
        Time.timeScale = 1;
    }
}
