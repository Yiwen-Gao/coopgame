using System.Collections;
using System.Collections.Generic;
using Mirror;
using NobleConnect.Mirror;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class CustomNetworkManager : NobleNetworkManager {

    private PlayerGenerator generator;
    private Grid myGrid;
    public void Start() {
        generator = new PlayerGenerator();
        myGrid = new Grid();
    }

    public override void OnServerAddPlayer(NetworkConnection conn) {
        //playerPrefab = generator.GetRandomPlayer();

        Transform startPos = GetStartPosition();
            GameObject player = startPos != null
                ? Instantiate(playerPrefab, startPos.position, startPos.rotation)
                : Instantiate(playerPrefab);

            NetworkServer.AddPlayerForConnection(conn, player);
        myGrid.AddPlayer();
    }
}
