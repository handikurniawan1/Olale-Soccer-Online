using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.Netcode;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
public class NetworkUI : NetworkBehaviour
{
    [SerializeField] private Button serverButton;
    [SerializeField] private Button hostButton;
    [SerializeField] private Button clientButton;
    [SerializeField] private Button exitButton;
    [SerializeField] private TextMeshProUGUI playerCountText;
    [SerializeField] private Button physiscsButton;

    private NetworkVariable<int> playersNum = new NetworkVariable<int>(0, NetworkVariableReadPermission.Everyone);
    private void Awake(){
        serverButton.onClick.AddListener(call: () => NetworkManager.Singleton.StartServer());
        hostButton.onClick.AddListener(call: () => NetworkManager.Singleton.StartHost());
        clientButton.onClick.AddListener(call: () => NetworkManager.Singleton.StartClient());
        exitButton.onClick.AddListener(Keluar);
    }
    private void Update(){
        playerCountText.text = "Players Count: " + playersNum.Value.ToString();
        if(!IsServer) return;
        playersNum.Value = NetworkManager.Singleton.ConnectedClients.Count;
    }
    void Keluar()
    {
        SceneManager.LoadScene("Main Menu Lobby");
        Debug.Log("Game closed");
    }
}
