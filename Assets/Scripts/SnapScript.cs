using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapScript : MonoBehaviour
{
    public Transform Wall;
    public Transform currentFocus_Obj;
    public Vector3 currentGrid = new Vector3(0, 0, 0);

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown (KeyCode.Tab))
        {
            currentFocus_Obj = (Transform)Instantiate(Wall, currentGrid, Wall.rotation);
        }	
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "GridCollider")
        {
            if (currentFocus_Obj.GetComponent<wallcon>().placeStatus != true)
            {
                currentFocus_Obj.GetComponent<Transform> ().position = new Vector3 (other.transform.position.x, other.transform.position.y, other.transform.position.z);
            }
        }
    }
}
