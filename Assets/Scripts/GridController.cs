using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.Rendering;

public class GridController : MonoBehaviour
{
    public Camera mainCamera;
    public Transform target;

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Vector3 snap = new Vector3(
                    Mathf.Floor(hit.point.x) + 0.5f,
                    10,
                    Mathf.Floor(hit.point.z) + 0.5f
                );

                Ray downRay = new Ray(snap, Vector3.down);
                RaycastHit downHit;

                if (Physics.Raycast(downRay, out downHit))
                {
                    snap.y = Mathf.Floor(downHit.point.y);
                    target.position = snap;
                }
            }
        }
    }
}