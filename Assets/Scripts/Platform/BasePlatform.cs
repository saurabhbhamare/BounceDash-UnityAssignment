using UnityEngine;

public class BasePlatform : MonoBehaviour
{
    private void Update()
    {
        CheckIfOutOfCamera();
    }
    private void CheckIfOutOfCamera()
    {
        if (this.transform.position.y < Camera.main.transform.position.y - 5f)
        {
            Destroy(this.gameObject);
        }
    }
}
