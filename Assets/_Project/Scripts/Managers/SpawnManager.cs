using UnityEngine;
using Photon.Pun;
using TMPro;

public class SpawnManager : MonoBehaviourPunCallbacks
{
    public static SpawnManager Instance;
    private void Awake()
    {
        Instance = this;
    }
    public void SpawnPlayer()
    {
        float randomPosx = Random.Range(-10f, 10f);
        float randomPosz = Random.Range(-10f, 10f);
        Vector3 spawnPos = new Vector3(randomPosx, 1f, randomPosz);
        PhotonNetwork.Instantiate("NetworkPlayer", spawnPos, Quaternion.identity);
    }

}
