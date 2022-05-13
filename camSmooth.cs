using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class camSmooth : MonoBehaviour
{
    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    void LateUpdate()
    {
        if (bulletCollider.bdaa == 1)
        {
            
            Vector3 desiredPosition = bulletCollider.meskin.transform.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;

            transform.LookAt(bulletCollider.meskin.transform);
        }
    }
}
