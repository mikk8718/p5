using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class Timer : MonoBehaviour
{
    //Timers and results
    public float FullTime,FullTime0,TimeInventoryGrabbed1, TimeRightInventoryOpened2;
    //Booleans to start timers
    public bool StartTimer0 = true;
    bool StartTimer1 = false;
    bool StartTimer2 = false;
    //Booleans to make sure that timers can't get restarted
    public bool EndTimer = false;
    public bool EndTimer0 = false;
    public bool EndTimer1 = false;
    public bool EndTimer2 = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (EndTimer == false)
        {
            FullTime += Time.deltaTime;
        }
        
        TimeStuff0();
       TimeStuff1();
       TimeStuff2();
       TimeStuff3();

    }
    //Starts and stops timers when certain conditions are met 
    void TimeStuff0()
    {
        if (StartTimer0 == true)
        {
            FullTime0 += Time.deltaTime;
        }
        if (StartTimer0 == true && EndTimer0 == true)
        {
            StartTimer0 = false;
        }
    }

    void TimeStuff1()
    {
        if (Input.GetKey(KeyCode.Mouse0) && EndTimer1 == false)
        {
            StartTimer1 = true;
        }
        if (StartTimer1 == true)
        {
            TimeInventoryGrabbed1 += Time.deltaTime;
        }
    }

    void TimeStuff2()
    {
         if (Input.GetKey(KeyCode.Mouse2) && StartTimer1 == true && EndTimer2 == false)
        {
            StartTimer2 = true;
        }
        if (StartTimer2 == true)
        {
            TimeRightInventoryOpened2 += Time.deltaTime;
            StartTimer1 = false;
            EndTimer1 = true;
        }
    }

    void TimeStuff3()
    {
        if (Input.GetKey(KeyCode.Mouse1) && StartTimer2 == true && EndTimer0 == false)
        {
            StartTimer2 = false;
            EndTimer2 = true;
            EndTimer0 = true;
        }
    }
}
