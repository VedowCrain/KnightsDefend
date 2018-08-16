using UnityEngine;
using UnityEngine.UI;

public class GameFlow : MonoBehaviour
{
    public static float currentHP = 500f;
    public static float maxHP = 500f;

    public static float currentStam = 200f;
    public static float maxStam = 200f;

    public float staminaDrain;
    public float staminaRecovery;

    public Image healthMeter;
    public Image staminaMeter;

    public KeyCode runForward;

    public float timeCheck = 0;
    public float stamTimeCheck = 0;

    public GameObject Player;

    void Start ()
    {
        healthMeter.GetComponent<Image> ();
        staminaMeter.GetComponent<Image>();
    }
	
	void Update ()
    {
        if (Input.GetKey(runForward))
        {
            timeCheck += Time.deltaTime;
        }
       else
        {
            if (currentStam<maxStam)
            {
                stamTimeCheck += Time.deltaTime;
                currentStam += staminaRecovery;
            }
        }

       if (timeCheck>.50)
        {
            timeCheck = 0;
            currentStam -= staminaDrain;
        }

        
        staminaMeter.fillAmount = currentStam / maxStam;
        //staminaMeter.GetComponent<RectTransform>().localScale = new Vector3(currentStam / maxStam, 1, 1);
    }   //healthMeter.GetComponent<RectTransform>().localScale = new Vector3(1,currentHP / maxHP,1);
}
//https://www.youtube.com/watch?v=I2Y1L8lqdAk&list=PL4UezTfGBADBg477BmLEM-lKVzt2sOPO1