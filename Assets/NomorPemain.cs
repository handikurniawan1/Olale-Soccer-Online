using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using TMPro;
public class NomorPemain : NetworkBehaviour
{
    [SerializeField] private TextMeshProUGUI nomor;
    private NetworkVariable<int> nomorpemain = new NetworkVariable<int>(0, NetworkVariableReadPermission.Everyone);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        nomor.text = " " + nomorpemain.Value.ToString();
        if(!IsServer) return;
        nomorpemain.Value = NetworkManager.Singleton.ConnectedClients.Count;
    }
}
