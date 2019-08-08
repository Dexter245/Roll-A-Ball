using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    const float MAX_ROTATION = 30f;
    public GameObject player;

    private Vector3 offset;
    private Quaternion initRotation;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;
        initRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        transform.position = player.transform.position + offset;
        float rotateHorizontal = Input.GetAxis("Horizontal2");
        float rotateVertical = Input.GetAxis("Vertical2");
        Vector3 rotation = new Vector3(-rotateVertical * MAX_ROTATION, rotateHorizontal * MAX_ROTATION, 0f);
        //Debug.Log("h2: " + rotateHorizontal + ", v2: " + rotateVertical);
        Debug.Log("rotation: " + rotation);
        transform.rotation = initRotation;
        //transform.Rotate(rotation, Space.Self);
        transform.RotateAround(player.transform.position, Vector3.up, rotateHorizontal * MAX_ROTATION);
        transform.RotateAround(player.transform.position, Vector3.right, rotateVertical * MAX_ROTATION);
    }
}
