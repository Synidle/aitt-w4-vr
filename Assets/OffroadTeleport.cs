using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using Valve.VR;

public class OffroadTeleport : MonoBehaviour
{
    [SerializeField] Transform raycastBasis;

    private LineRenderer lineRenderer; 
    private Vector3 hitPoint;
    private float height;

    // Start is called before the first frame update
    void Start()
    {
        raycastBasis.TryGetComponent<LineRenderer>(out lineRenderer);
        //height = transform.position.y; 
    }

    private void FixedUpdate()
    {
        Ray raycast = new Ray(raycastBasis.position, raycastBasis.forward);
        RaycastHit hit;

        bool bHit = Physics.Raycast(raycast, out hit);
        if (bHit)
        {
            hitPoint = hit.point;

            lineRenderer?.SetPosition(0, raycastBasis.position);
            lineRenderer?.SetPosition(1, hitPoint);
        }
    }

    // Update is called once per frame
    void Update()
    { 

        if (SteamVR_Input.GetStateUp("OffroadTeleport", SteamVR_Input_Sources.LeftHand))
        {
            print("Teleport input up");

            TeleportTo(hitPoint);
        }
    }

    private void TeleportTo(Vector3 position)
    {
        transform.position = new Vector3(
            position.x, position.y+height, position.z);
    }
}
