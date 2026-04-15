using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    public Transform cameraTransform;
    public float parallaxFactor = 0.5f;

    private float spriteWidth;
    private Vector3 lastCameraPosition;

    void Start()
    {
        spriteWidth = GetComponent<SpriteRenderer>().bounds.size.x;
        lastCameraPosition = cameraTransform.position;
    }

    void LateUpdate()
    {
        Vector3 delta = cameraTransform.position - lastCameraPosition;

        transform.position += new Vector3(delta.x * parallaxFactor, 0, 0);

        lastCameraPosition = cameraTransform.position;

        if (cameraTransform.position.x - transform.position.x >= spriteWidth)
        {
            transform.position += new Vector3(spriteWidth * 2f, 0, 0);
        }
        else if (cameraTransform.position.x - transform.position.x <= -spriteWidth)
        {
            transform.position -= new Vector3(spriteWidth * 2f, 0, 0);
        }
    }
}