using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using UnityEngine.SceneManagement;

public class NambahScoreDua : NetworkBehaviour
{
    private NetworkVariable<int> Score2 = new NetworkVariable<int>(0, NetworkVariableReadPermission.Everyone);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Score2.Value == 5){

                SceneManager.LoadScene("B");

            
        }
    }
    
    void OnGUI(){
        GUI.Box (new Rect(5, 30, 120, 20), "Team B:  " + Score2.Value.ToString());
    }
    void OnTriggerEnter(Collider col){
        Score2.Value += 1;
        Destroy(GameObject.FindWithTag("Ball"));
    } 
}
