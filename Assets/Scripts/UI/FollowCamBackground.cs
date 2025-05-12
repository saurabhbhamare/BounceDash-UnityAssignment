using UnityEngine.UI;
using Unity;
using UnityEngine;

public class FollowCamBackground : MonoBehaviour
{
    //Move Background according to camera view
    public Transform cameraTransform;
    public float yOffset = -2.5f;

    private void Update()
    {
        transform.position = new Vector3(cameraTransform.position.x, cameraTransform.position.y + yOffset, transform.position.z);
    }
}
