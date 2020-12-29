using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGenerator {

    private List<GameObject> allPlayers;
    private HashSet<int> existingPlayers;

    public PlayerGenerator() {
        allPlayers = new List<GameObject>();
        Object[] objs = Resources.LoadAll("Players", typeof(GameObject));
        foreach (GameObject obj in objs) {
            allPlayers.Add(obj);
        }

        existingPlayers = new HashSet<int>();
    }

    public GameObject GetRandomPlayer() {
        int idx;
        do {
            idx = Random.Range(0, allPlayers.Count);
        } while (existingPlayers.Contains(idx)); 

        Debug.Log("hello " + allPlayers.Count);
        existingPlayers.Add(idx);
        return allPlayers[idx];
    }

    List<GameObject> GetSubsetPlayers(int count) {
        if (count > 0 && allPlayers.Count > 0) {
            count %= allPlayers.Count;
            return allPlayers.GetRange(0, count - 1);
        } else {
            return new List<GameObject>();
        }
    }
}
