using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalPortal : MonoBehaviour
{
    public GameObject objectToDestroy;
    public GameObject objectToActivate;

    void Update()
    {
        // Ki?m tra n?u objectToDestroy ?� b? null
        if (objectToDestroy == null)
        {
            // K�ch ho?t objectToActivate (n?u c�)
            if (objectToActivate != null)
            {
                objectToActivate.SetActive(true);
            }

            // Lo?i b? script n�y kh?i GameObject ?? ng?n vi?c ki?m tra th�m
            Destroy(this);
        }
    }
}