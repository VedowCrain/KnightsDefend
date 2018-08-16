using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimations : MonoBehaviour
{
    public Animator m_Char;
    public float Walk = 0;
    public float Idle = 0;
    public float Run = 0;
    public float BackPeddle = 0;
    public int AnimSpeed;
    
    // Use this for initialization
	void Start ()
    {
       
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W) && (Walk <= 0.6f && Walk >= -1f))
        {
            m_Char.SetFloat("Vertical", Walk += 2.5f * Time.deltaTime);
        }

        if ((Walk >= 0 && Walk <= 0.7) && !Input.GetKey(KeyCode.W))
        {
            m_Char.SetFloat("Vertical", Walk -= 0.7f * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift) && (Walk >= 0.6f && Walk <= 1))
        {
            m_Char.SetFloat("Vertical", Walk += 2.5f * Time.deltaTime);
        }

        if ((Walk >= 0.7 && Walk <= 2f) && !Input.GetKey(KeyCode.LeftShift))
        {
            m_Char.SetFloat("Vertical", Walk -= 0.8f * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S) && (Walk <= -0f && Walk >= -1f))
        {
            m_Char.SetFloat("Vertical", Walk -= 3f * Time.deltaTime);
        }

        if ((Walk >= -1.1f && Walk <= 0) && !Input.GetKey(KeyCode.S))
        {
            m_Char.SetFloat("Vertical", Walk += 0.7f * Time.deltaTime);
        }
    }
}
