using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using UnityEngine.UI;
using TMPro;
public class LamaMain : NetworkBehaviour
{
    public float timeValue = 60;
    [SerializeField]
    private TextMeshProUGUI timerText;
    // Update is called once per frame
    void Update()
    {
        if(timeValue > 0){
            timeValue -= Time.deltaTime;
        }
        else{
            timeValue = 0;
            
            
        }
        DisplayTime(timeValue);
    }
    void DisplayTime(float timeToDisplay){
        if(timeToDisplay < 0){
            timeToDisplay = 0;
            
        }
        float minutes = Mathf.FloorToInt(timeToDisplay/60);
        float seconds = Mathf.FloorToInt(timeToDisplay%60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes,seconds);
    }
}
