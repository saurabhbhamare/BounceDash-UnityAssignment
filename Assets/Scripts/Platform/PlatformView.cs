using UnityEngine;

public class PlatformView : MonoBehaviour
{
    PlatformController platformController;
    private void Update()
    {
        CheckIfOutOfCamera();
    }
    private void CheckIfOutOfCamera()
    {
        if (this.transform.position.y < Camera.main.transform.position.y - 5f)
        {
            platformController.OnPlatformRemoval();
        }
    }
    public void SetPlatformController(PlatformController platformController)
    {
        this.platformController = platformController;
    }
}
