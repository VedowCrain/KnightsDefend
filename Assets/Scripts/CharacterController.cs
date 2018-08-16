using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public Animator chrAnim;
    public float speed = .5f;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float translation = Input.GetAxis("Vertical") * speed;
        float strafe = Input.GetAxis("Horizontal");

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 1;
        }
        else
        {
            speed = .5f;
        }
        chrAnim.SetFloat("Vertical", translation);
        chrAnim.SetFloat("Horizontal", strafe);
    }
}
