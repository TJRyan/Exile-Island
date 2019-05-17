using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public Transform cameraTransform;
    private float angle = 0;

    void Update()
    {
        if (Input.GetKey("w")) {
            this.transform.position =
                new Vector3(transform.position.x , transform.position.y + 0.5f, transform.position.z );
        }
        if (Input.GetKey("s"))
        {
            this.transform.position =
                new Vector3(transform.position.x , transform.position.y - 0.5f, transform.position.z );
        }
        if (Input.GetKey("a"))
        {
            this.transform.position =
                new Vector3(transform.position.x - 0.5f, transform.position.y, transform.position.z);
        }
        if (Input.GetKey("d"))
        {
            this.transform.position =
                new Vector3(transform.position.x + 0.5f, transform.position.y, transform.position.z);
        }
        if (Input.GetKey("p"))
        {
            this.transform.position =
                new Vector3(transform.position.x, transform.position.y, transform.position.z + 0.5f);
        }
        if (Input.GetKey("o"))
        {
            this.transform.position =
                new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.5f);
        }
        if (Input.GetKey("e"))
        {
            ++angle;
            cameraTransform.localRotation =
                Quaternion.Euler(0f, angle, 0f);
        }
        if (Input.GetKey("q"))
        {
            --angle;
            cameraTransform.localRotation =
                Quaternion.Euler(0f, angle, 0f);
        }
    }
}
