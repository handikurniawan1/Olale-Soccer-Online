using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using UnityEngine.SceneManagement;

public class NambahScore : NetworkBehaviour
{
    private NetworkVariable<int> Score1 = new NetworkVariable<int>(0, NetworkVariableReadPermission.Everyone);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Score1.Value == 5){
            
            SceneManager.LoadScene("A");
            
        }
    }
    void OnGUI(){
        GUI.Box (new Rect(5, 5, 120, 20), "Team A:  " + Score1.Value.ToString());
    }
    void OnTriggerEnter(Collider col){
        Score1.Value += 1;
        Destroy(GameObject.FindWithTag("Ball"));
    } 
}
