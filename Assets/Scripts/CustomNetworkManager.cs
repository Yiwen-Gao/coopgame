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

    public void Start() {
        // generator = new PlayerGenerator();
        // playerPrefab = generator.GetRandomPlayer();
    }
}
