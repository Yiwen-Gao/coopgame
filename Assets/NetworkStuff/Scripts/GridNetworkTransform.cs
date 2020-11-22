using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class GridNetworkTransform : NetworkBehaviour
{
    [SyncVar(hook = nameof(UpdatePosition))] public Vector2Int coords;

    public override void OnStartServer()
    {
        base.OnStartServer();
        coords = Vector2Int.zero;
    }

    void UpdatePosition(Vector2Int oldPos, Vector2Int newPos)
    {
        transform.position = new Vector3(newPos.x,newPos.y,0);
    }
}
