using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    
    [SerializeField] private NetworkManagerLobby networkManager = null;

    [Header("UI")]
    [SerializeField] private GameObject landingPagePanel = null;

    //When we want to host
    public void HostLobby()
    {
        //start a host
        networkManager.StartHost();

        //disable landing page
        landingPagePanel.SetActive(false);
    }
}
