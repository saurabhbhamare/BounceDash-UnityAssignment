using UnityEngine;

public class PlatformService
{
    private PlatformData platformData;
    private PlatformPool platformPool;
    private int startingPlatformCount;
    private SpawnItemSO spawnItemSO;

    PlatformView platformViewPrefab;
    private BallView ballView;

    //Platform Properties
    float spawnDistance;
    float highestPlatformY;
    float lowestPlatformY;
    float minPlatformWidth;
    float maxPlatformWidth;
    float itemSpawnOffset;
    float platformYScale;
    float itemSpawnProbability;
    float yOffsetBetweenTwoPlatforms;
    float minRandomPlatformSpawn;
    float maxRandomPlatformSpawn;

    int itemSpawnPlatformNumber;
    public PlatformService(PlatformView platformViewPrefab, Item gem, SpawnItemSO spawnItemSO, PlatformData platformData)
    {
        this.spawnItemSO = spawnItemSO;
        this.platformData = platformData;
        platformPool = new PlatformPool(platformViewPrefab, this);
        SetPlatformData(platformData);
        SpawnInitialPlatforms();
    }
    private void SetPlatformData(PlatformData platformData)
    {
        itemSpawnPlatformNumber = 0;
        startingPlatformCount = platformData.StartingPlatformCount;
        spawnDistance = platformData.PlatformSpawnDistacne;
        minPlatformWidth = platformData.MinPlatformWidth;
        maxPlatformWidth = platformData.MaxPlatformWidth;
        itemSpawnOffset = platformData.ItemSpawnOffset;
        platformYScale = platformData.PlatformYScale;
        itemSpawnProbability = platformData.ItemSpawnProbability;
        highestPlatformY = platformData.InitialHighestPlatformY;
        yOffsetBetweenTwoPlatforms = platformData.YOffsetBetweenTwoPlatforms;
        minRandomPlatformSpawn = platformData.MinRandomPlatformSpawn;
        maxRandomPlatformSpawn = platformData.MaxRandomPlatformSpawn;
    }
    //StartingPlatforms Spawning
    public void SpawnInitialPlatforms()
    {
        for (int i = 0; i < startingPlatformCount; i++)
        {
            SpawnPlatform();
        }
    }
    //Return Platform To the ObjectPool
    public void ReturnInvisiblePlatformToPool(PlatformController platformController)
    {
        platformPool.ReturnItem(platformController);
        SpawnPlatform();
    }
    public int GetPoolSizes()
    {
        return platformPool.PooledItems.Count;
    }
    //Level PlatformSpawing
    public void SpawnPlatform()
    {
        highestPlatformY += yOffsetBetweenTwoPlatforms;
        PlatformController platform = platformPool.GetPlatform();

        float randomX = Random.Range(minRandomPlatformSpawn, maxRandomPlatformSpawn);
        platform.GetPlatformView().transform.position = new Vector2(randomX, highestPlatformY);
        platform.GetPlatformView().gameObject.SetActive(true);

        // Randomize the width of the platform within a range
        float randomWidth = Random.Range(minPlatformWidth, maxPlatformWidth);
        platform.GetPlatformView().transform.localScale = new Vector3(randomWidth, platformYScale, 1f);
        itemSpawnPlatformNumber++;

        if (Random.value < itemSpawnProbability && itemSpawnPlatformNumber > 6) // 35% chance to spawn an item
        {
            SpawnRandomItem(platform);
        }
    }
    //Select Rendom Item and Spawning
    private void SpawnRandomItem(PlatformController platform)
    {
        if (spawnItemSO == null || spawnItemSO.Items.Length == 0)
        {
            Debug.LogError("spawnSO is null or contains no items!");
            return;
        }

        // Pick a random item from the array items
        int randomIndex = Random.Range(0, spawnItemSO.Items.Length);
        Item selectedItem = spawnItemSO.Items[randomIndex];
        Vector2 spawnPosition = platform.GetPlatformView().transform.position + new Vector3(0, itemSpawnOffset, 0);
        GameObject.Instantiate(selectedItem, spawnPosition, Quaternion.identity);
    }

}
