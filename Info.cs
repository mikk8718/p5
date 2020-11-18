using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Info : MonoBehaviour
{
    //void start // General info //Manipulated in participant info
    public int IDNumber;
    public string TheOrder;
    public int TestDayNumber;
    //void update //Timers
    int TestNumber = 1;
    public Timer timer;
    float TestTime;
    float FullTime;
    float TimeInventoryGrabbed;
    float TimeRightInventoryOpened;
    //stop typing
    bool StopTyping = false;

    // Start is called before the first frame update
    void Start()
    {
        //Path of file
        string Path = Application.dataPath + "/ParticipantInfo.txt";
        //Create file if it does not exist
        if (!File.Exists(Path)) 
        {
            File.WriteAllText(Path, "Participants Information: \n\n");
        }

        //Get general data for text file
        string ID = "Participant ID: " + IDNumber + "\n";
        string Order = "Order: " + TheOrder + "\n";
        string TestDay = "Test Day: " + TestDayNumber + "\n";
        string DayTime = "Date: " + System.DateTime.Now + "\n\n";
        string HeadlineTestNr = "Test Number: ;";
        string HeadlineStartTime = "Duration of test (in sec): ;";
        string HeadlineMidTime = "Inventory grabbed to right category opened (in sec): ;";
        string HeadlineEndTime = "Right category opened to right object grabbed (in sec): " + "\n";
        //Add general data to text file
        File.AppendAllText(Path,ID);
        File.AppendAllText(Path,Order);
        File.AppendAllText(Path,TestDay);
        File.AppendAllText(Path,DayTime);
        File.AppendAllText(Path,HeadlineTestNr);
        File.AppendAllText(Path,HeadlineStartTime);
        File.AppendAllText(Path,HeadlineMidTime);
        File.AppendAllText(Path,HeadlineEndTime);
    }

    // Update is called once per frame
    void Update()
    {
        string Path = Application.dataPath + "/ParticipantInfo.txt";

            //Check timer values
            if (timer.EndTimer0 == true && timer.EndTimer1 == true && timer.EndTimer2 == true && StopTyping == false)
            {
                //Test Nr
                string TestNr = TestNumber + ";";
                File.AppendAllText(Path,TestNr);
                //timers
                FullTime = timer.FullTime;
                TestTime = timer.FullTime0;
                TimeInventoryGrabbed = timer.TimeInventoryGrabbed1;
                TimeRightInventoryOpened = timer.TimeRightInventoryOpened2;
                //Get Time data for text file
                string StartTime = TestTime + ";";
                string MidTime = TimeInventoryGrabbed + ";";
                string EndTime = TimeRightInventoryOpened + "\n";
                //Add time data to text file
                File.AppendAllText(Path,StartTime);
                File.AppendAllText(Path,MidTime);
                File.AppendAllText(Path,EndTime);
                StopTyping = true;
                
                TestNumber++;
                timer.FullTime0 = 0;
                timer.TimeInventoryGrabbed1 = 0;
                timer.TimeRightInventoryOpened2 = 0;
                timer.EndTimer0 = false;
                timer.EndTimer1 = false;
                timer.EndTimer2 = false;
                timer.StartTimer0 = true;
                StopTyping = false;

                //End the test and stop all timers
            if (TestNumber > 5)
            {
                StopTyping = true;
                timer.EndTimer = true;
                timer.EndTimer0 = true;
                timer.EndTimer1 = true;
                timer.EndTimer2 = true;
                timer.StartTimer0 = false;
                //print the entire time
                string EntireTime = "Duration of the entire test: " + FullTime + " sec" + "\n";
                File.AppendAllText(Path,EntireTime);
            }
        }
    }
}
