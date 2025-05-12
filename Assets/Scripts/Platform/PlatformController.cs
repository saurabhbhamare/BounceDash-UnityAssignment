using UnityEngine;

public class PlatformController
{

    private PlatformView platformView;
    public PlatformService platformService;
    public PlatformController(PlatformView platformPrefab, PlatformService platformService)
    {
        platformView = Object.Instantiate(platformPrefab);
        this.platformService = platformService;
        platformView.SetPlatformController(this);
    }
    public PlatformView GetPlatformView()
    {
        return platformView;
    }
    public void OnPlatformRemoval()
    {
        platformView.gameObject.SetActive(false);
        platformService.ReturnInvisiblePlatformToPool(this);
    }
}
