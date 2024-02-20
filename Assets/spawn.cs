using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class spawn : NetworkBehaviour
{
    [SerializeField] private float waktudajjal;
    [SerializeField] private GameObject objectprefab;
    private Vector3 m_CurrentNewLaserPosition = new Vector3();
    private float m_CurrentMeteorSpawnTime = 0f;
    private bool isSpawning=true;
    private void Start(){
        m_CurrentNewLaserPosition.x = transform.position.x;
        m_CurrentNewLaserPosition.z = transform.position.z;
        m_CurrentNewLaserPosition.y = transform.position.y;
    }

    void Update(){
        if (!(IsServer && isSpawning))
            return;

        UpdateMeteorSpawning();
    }
    
    public void spn(){
        waktudajjal=(Random.Range(10f, 10f));
        NetworkObjectSpawner.SpawnNewNetworkObject(objectprefab, m_CurrentNewLaserPosition);  
    }
    private void UpdateMeteorSpawning()
    {
        m_CurrentMeteorSpawnTime += Time.deltaTime;
        if (m_CurrentMeteorSpawnTime > waktudajjal)
        {
            spn();

            m_CurrentMeteorSpawnTime = 0f;
        }
    }
}
