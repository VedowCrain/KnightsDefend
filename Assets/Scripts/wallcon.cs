using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallcon : MonoBehaviour
{
    public KeyCode Rotate = KeyCode.Q;
    public KeyCode Place = KeyCode.E;
    public Vector3 currentRot;
    public bool placeStatus;
    private bool placed;
    public Transform wall_obj;

    public Material woodWall_Mat;
    public Material stoneWall_Mat;

    public float wallHP;

    public Transform cub_obj;


	// Use this for initialization
	void Start ()
    {
        currentRot.x = transform.rotation.x;
        currentRot.y = transform.rotation.y;
        currentRot.z = transform.rotation.z;
        placeStatus = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if ((Input.GetKeyDown(Rotate)) && (placeStatus!=true))
        {
            //Debug.Log("Rotate");
            transform.Rotate(0, 90, 0);

        }

        if ((Input.GetKeyDown(Place)) && (placed!=true))
        {
            placeStatus = true;
            Instantiate(wall_obj, wall_obj.position, wall_obj.rotation);
            placed = true;
        }

        if ((Input.GetKeyDown("1")) && (placeStatus != true))
        {
            cub_obj.GetComponent<Renderer>().material = woodWall_Mat;
            wallHP = 100;
        }

        if ((Input.GetKeyDown("2")) && (placeStatus != true))
        {
            cub_obj.GetComponent<Renderer>().material = stoneWall_Mat;
            wallHP = 200;
        }
    }
}
