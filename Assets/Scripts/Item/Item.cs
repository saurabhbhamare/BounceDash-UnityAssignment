using UnityEngine;

public class Item : MonoBehaviour
{
    public SpawnItemType itemType;
    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
