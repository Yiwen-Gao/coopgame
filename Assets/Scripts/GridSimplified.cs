using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class GridSimplified: NetworkBehaviour
{
    public List<GameObject> myPlayers;
    public GameObject debugPrefab;

    // 0 = empty, 1 = target, 
    int[,] myGrid;
    GameObject[,] myGridObjects;

    int gridSize = 15;

    // Start is called before the first frame update
    void Start()
    {
        //myPlayers = Player.getPlayers();


        //DrawGrid();

        //Init();
        AddPlayer();
    }

    public void AddPlayer()
    {
        Debug.Log("ADDING PLAYER");
        myPlayers = new List<GameObject>();
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject p in players)
        {
            myPlayers.Add(p);
        }
        myGrid = new int[gridSize, gridSize];
        myGridObjects = new GameObject[gridSize, gridSize];
        Init();

        DrawGrid();
    }

    List<GameObject> ListPlayers()
    {
        //NetworkManager networkManager = NetworkManager.singleton;
        //List<PlayerController> pc = networkManager.client.connection.playerControllers;

        List<GameObject> players = new List<GameObject>();
        GameObject[] pc = GameObject.FindGameObjectsWithTag("Player");
        Debug.Log("PLAYER LENGTH: " + pc.Length);
        for (int i = 0; i < pc.Length; i++)
        {
                players.Add(pc[i]);
        }
        return players;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("COUNTING");
        List<GameObject> p = ListPlayers();
        if(p.Count != myPlayers.Count)
            AddPlayer();
        //get players location and transformation (currPlayer.GetComponent<>(GridNetworkTransform))
    }

    void DrawGrid()
    {
        for (int i = 0; i < gridSize; i++)
        {
            for (int j = 0; j < gridSize; j++)
            {
                if(myGridObjects[i,j] != null && myGrid[i,j] == 1)
                    Destroy(myGridObjects[i, j]);
                if (myGridObjects[i, j] == null && myGrid[i, j] != 1)
                {
                    myGridObjects[i, j] = (GameObject)(Instantiate(debugPrefab, new Vector3(i, j, 0.001f), Quaternion.identity));
                }
            }
        }
    }
    //void DebugGrid()
    //{
    //    for (int i = 0; i < gridSize; i++)
    //    {
    //        for (int j = 0; j < gridSize; j++)
    //        {
    //            if (myGrid[i, j] == 1 && myGridObjects != null)
    //                Destroy(myGridObjects[i, j]);
    //        }
    //    }
    //}

    //assume each character's head is (0,0)
    //create the random target location
    void Init()
    {
        if (myPlayers.Count == 0)
            return;

        Random rnd = new Random();

        int[] boundary = new int[4];

        int r = (int)(gridSize/2);
        int c = (int)(gridSize / 2);

        Player firstPlayer = myPlayers[0].GetComponent(typeof(Player)) as Player;
        PlacePlayer(firstPlayer, r, c, boundary);

        int side = 0;
        for (int i = 1; i < myPlayers.Count; i++)
        {
            Player player = myPlayers[i].GetComponent(typeof(Player)) as Player;

            //0 = top, 1 = left, 2 = bottom, 3 = right
            //int side = (int)(rnd.random() * 4);
            int playerHeight = GetHeight(player);
            int playerWidth = GetWidth(player);

            if (side == 0)
            {
                PlacePlayer(player, boundary[side] - playerHeight, (boundary[1] + boundary[3]) / 2, boundary);
            }
            if (side == 1)
            {
                PlacePlayer(player, (boundary[0] + boundary[2]) / 2, boundary[side] - playerWidth, boundary);
            }
            if (side == 2)
            {
                PlacePlayer(player, boundary[side], (boundary[1] + boundary[3]) / 2, boundary);
            }
            if (side == 3)
            {
                PlacePlayer(player, (boundary[0] + boundary[2]) / 2, boundary[side], boundary);
            }
            side += 1;
        }
    }

    private void PlacePlayer(Player player, int r, int c, int[] boundary)
    {
        float[,] pos = player.GetPositions();

        for (int i = 0; i < pos.GetLength(0); i++)
        {
            if (boundary[0] == 0 || pos[i,0] + r <= boundary[0])
            {
                boundary[0] = (int)pos[i, 0] + r - 1;
            }
            if (boundary[1] == 0 || pos[i, 1] + c <= boundary[1])
            {
                boundary[1] = (int)pos[i, 1] + c - 1;
            }
            if (pos[i, 0] + r >= boundary[2])
            {
                boundary[2] = (int)pos[i, 0] + r + 1;
            }
            if (pos[i, 1] + c >= boundary[3])
            {
                boundary[3] = (int)pos[i, 1] + c + 1;
            }

            myGrid[r + (int)pos[i, 0], c + (int)pos[i, 1]] = 1;
        }
    }

    private int GetHeight(Player player)
    {
        int height = 1;
        float[,] pos = player.GetPositions();

        for (int i = 1; i < pos.GetLength(0); i++)
        {
            if (pos[i, 0] > height - 1)
            {
                height = (int)pos[i, 0] + 1;
            }
        }
        return height;
    }
    private int GetWidth(Player player)
    {
        int width = 1;
        float[,] pos = player.GetPositions();

        for (int i = 1; i < pos.GetLength(0); i++)
        {
            if (pos[i, 1] > width - 1)
            {
                width = (int)pos[i, 1] + 1;
            }
        }
        return width;
    }

    void CheckSuccess()
    {
        
    }

}
