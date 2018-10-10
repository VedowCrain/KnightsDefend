using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class CharacterController : MonoBehaviour
{
    public Animator chrAnim;
    public float speed = .5f;

    public float timeToCombo = .4f;
    public bool pressedAttack = true;
    public bool pressedAttackWithinComboLimit = false;
    float comboTimer = 0;

    public AudioSource audioSource;
    public AudioClip[] footstepClips;

    public FirstPersonController fpsController;

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

        if (Input.GetMouseButtonDown(0))
        {

            if (pressedAttackWithinComboLimit && comboTimer > 0)
            {
                chrAnim.SetTrigger("Attack 2");
                pressedAttackWithinComboLimit = false;
            }
            else
            {
                chrAnim.SetTrigger("Attack 1");
            }

            pressedAttackWithinComboLimit = true;
            comboTimer = timeToCombo;
        }
        comboTimer -= Time.deltaTime;
        if (comboTimer <= 0 && pressedAttackWithinComboLimit)
        {
            pressedAttackWithinComboLimit = false;
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            chrAnim.SetTrigger("Special");
        }

    }

    public void FootR()
    {
        Debug.Log("Foot R");
        PlayFootStepAudio();
    }

    public void FootL()
    {
        Debug.Log("Foot L");
        PlayFootStepAudio();
    }

    public void Hit()
    {
        //Do Damage
        Debug.Log("Attacked");
    }

    public void PlayFootStepAudio()
    {
        if (!fpsController.CharController.isGrounded)
        {
            return;
        }
        // pick & play a random footstep sound from the array,
        // excluding sound at index 0
        int n = Random.Range(1, footstepClips.Length);
        audioSource.clip = footstepClips[n];
        audioSource.PlayOneShot(audioSource.clip);
        // move picked sound to index 0 so it's not picked next time
        footstepClips[n] = footstepClips[0];
        footstepClips[0] = audioSource.clip;
    }
}
