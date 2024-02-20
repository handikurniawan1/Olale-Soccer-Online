using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class voulumelagu : MonoBehaviour
{
    public float vol = 0.7f;

    public void MuteToggle(bool muted){
        if(muted){
            AudioListener.volume = 0;
        }
        else{
            AudioListener.volume = vol;
        }
             
    }

}
