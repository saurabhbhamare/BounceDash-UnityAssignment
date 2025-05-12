using UnityEngine;
public class PlatformPool : GenericObjectPool<PlatformController>
{
    private PlatformView platformViewPrefab;
    private PlatformService platformService;

    public PlatformPool(PlatformView platformViewPrefab, PlatformService platformService)
    {
        this.platformViewPrefab = platformViewPrefab;
        this.platformService = platformService;
    }
    public PlatformController GetPlatform() => GetItem<PlatformController>();
    protected override PlatformController CreateItem<T>() => new PlatformController(platformViewPrefab, platformService);
}
