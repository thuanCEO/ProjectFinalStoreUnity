using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalPortal : MonoBehaviour
{
    public GameObject objectToDestroy;
    public GameObject objectToActivate;

    void Update()
    {
        // Ki?m tra n?u objectToDestroy ?ã b? null
        if (objectToDestroy == null)
        {
            // Kích ho?t objectToActivate (n?u có)
            if (objectToActivate != null)
            {
                objectToActivate.SetActive(true);
            }

            // Lo?i b? script này kh?i GameObject ?? ng?n vi?c ki?m tra thêm
            Destroy(this);
        }
    }
}