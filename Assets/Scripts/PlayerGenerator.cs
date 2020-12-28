using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGenerator : MonoBehaviour {

    private List<GameObject> allPlayers;

    // Start is called before the first frame update
    void Start() {
        // allPlayers = new List<GameObject>();
        // Object[] objs = Resources.LoadAll("Prefabs", typeof(GameObject));
        // foreach (GameObject obj in objs) {
        //     allPlayers.Add(obj);
        // }
    }

    // GameObject GetRandomPlayer() {
    //     int idx = Random.Range(0, allPlayers.Count);
    //     return allPlayers[idx];
    // }

    // List<GameObject> GetSubsetPlayers(int count) {
    //     if (count > 0) {
    //         return allPlayers.GetRange(0, count - 1);
    //     } else {
    //         return new List<GameObject>();
    //     }
    // }
}
