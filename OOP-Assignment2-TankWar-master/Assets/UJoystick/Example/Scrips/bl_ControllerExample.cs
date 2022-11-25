using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bl_ControllerExample : MonoBehaviour {

    [SerializeField] public bool isTorret = false;

    public GameObject shellPrefab;
    private Transform fireposition;
    public float shellSpeed = 10;

    public float Start_Delay;
    private float delay;

    /// <summary>
    /// Step #1
    /// We need a simple reference of joystick in the script
    /// that we need add it.
    /// </summary>
	[SerializeField]private bl_Joystick Joystick;//Joystick reference for assign in inspector

    [SerializeField]private float Speed = 5;


    private Rigidbody rigidbody;
    public int number = 1; //judge a player by different number 
    
    public float angularSpeed = 30;

    private void Start()
    {
        rigidbody = this.GetComponent<Rigidbody>();
        fireposition = transform.Find("FirePosition");
    }

    void Update()
    {
        //Step #2
        //Change Input.GetAxis (or the input that you using) to Joystick.Vertical or Joystick.Horizontal

        /*
        float v = Joystick.Vertical; //get the vertical value of joystick
        float h = Joystick.Horizontal;//get the horizontal value of joystick
        */

        float v = Joystick.Vertical; //Input.GetAxis("Verticalplayer" + number);
        rigidbody.velocity = transform.forward * v * Speed; //Fore-and-aft movement speed

        float h = Joystick.Horizontal; //Input.GetAxis("player" + number + "Horizontal");
        rigidbody.angularVelocity = transform.up * h * angularSpeed; //rotational speed 

        //in case you using keys instead of axis (due keys are bool and not float) you can do this:
        //bool isKeyPressed = (Joystick.Horizontal > 0) ? true : false;

        //ready!, you not need more.
        Vector3 translate = (new Vector3(h, 0, v) * Time.deltaTime) * Speed;
        transform.Translate(translate);

        if(isTorret==true)
        {
            if (delay <= 0)
            {
                if (Joystick.Horizontal > 0 || Joystick.Horizontal < 0)
                {
                    GameObject go = GameObject.Instantiate(shellPrefab, fireposition.position, fireposition.rotation) as GameObject;
                    go.GetComponent<Rigidbody>().velocity = go.transform.forward * shellSpeed;
                    delay = Start_Delay;
                }
            }
            else
            {
                delay -= Time.deltaTime;
            }
        }
    }
}