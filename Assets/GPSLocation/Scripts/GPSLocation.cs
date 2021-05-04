using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GPSLocation : MonoBehaviour
{
    public Text GPSStatus;
    public Text latitudeValue;
    public Text longitudeValue;
    public Text altitudeValue;
    public Text horizontalAccuracyValue;
    // Start is called before the first frame update
    void Start()
    {
    
    }
    IEnumerator GPSLoc()
    {
        if (!Input.location.isEnableByUser)
            yield break;

        Input.location.Start();
        int maxWait = 20;
        while(Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        if(maxWait < 1)
        {
            GPSStatus.text = "Time out";
            yield break;

        }

        if (Input.location.status == LocationServiceStatus.Failed)
        {
            GPSStatus.text = "Unable to determine device location";
            yield break;
        }
        else
        {
            //access granted
            GPSStatus.text = "Running";
        }
    }//end of GPSLoc

    private void UpdateGPSData()
    {
        if(Input.location.status == LocationServiceStatus.Running)
        {
            // access granted to gps values and it has been init
            GPSStatus.text = "Running";
            latitudeValue.text = Input.location.lastData.latitude.Tostring();
        }
        else
        {

        }
    }
}
