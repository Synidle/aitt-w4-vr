using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using Valve.VR;

public class OffroadTeleport : MonoBehaviour
{    
    private Vector3 hitPoint;
    private LineRenderer lineRenderer;

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (SteamVR_Input.GetStateDown("OffroadTeleport", SteamVR_Input_Sources.LeftHand))
        {
            Ray raycast = new Ray(transform.position, transform.forward);
            RaycastHit hit;

            print("Teleport input down");

            bool bHit = Physics.Raycast(raycast, out hit);
            if (bHit)
            {
                hitPoint = hit.point;

                lineRenderer.SetPosition(0, transform.position);
                lineRenderer.SetPosition(1, hitPoint);
            }
        }

        if (SteamVR_Input.GetStateUp("OffroadTeleport", SteamVR_Input_Sources.LeftHand))
        {
            print("Teleport input up");

            TeleportTo(hitPoint);
        }
    }

    private void TeleportTo(Vector3 position)
    {
        transform.position = new Vector3(
            position.x, transform.position.y, position.z);
    }
}
