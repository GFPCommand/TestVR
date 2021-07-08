using UnityEngine;

public class CameraLook : MonoBehaviour
{
    public Transform playerBody, cameraPosition;
    float xRot = 0f;

    void Start()
    {
        
    }

    void Update()
    {
        trans();
    }

    void trans()
    {
        float mouseX = cameraPosition.rotation.x;
        float mouseY = cameraPosition.rotation.y;

        xRot -= mouseY;
        xRot = Mathf.Clamp(xRot, 0f, 0f);

        Vector3 rot = new Vector3(0f, xRot, 0f);

        //transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);
        playerBody.Rotate(rot);
    }
}
