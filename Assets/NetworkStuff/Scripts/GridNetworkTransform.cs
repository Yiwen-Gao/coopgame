using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class GridNetworkTransform : NetworkBehaviour
{
    [SyncVar(hook = nameof(UpdatePosition))] public Vector2Int coords; //please don't directly set these!

    [SyncVar(hook = nameof(UpdateRotation))] public int rotation; //please don't directly set these!
    //they should be set server-side using the SetPosition and SetRotation commands, to ensure
    //syncing works properly

    public override void OnStartServer()
    {
        base.OnStartServer();
        coords = Vector2Int.zero;
    }

    void UpdatePosition(Vector2Int oldPos, Vector2Int newPos)
    {
        transform.position = new Vector3(newPos.x,newPos.y,0);
    }
    
    void UpdateRotation(int oldRot, int newRot)
    {
        transform.eulerAngles = new Vector3(0,0,newRot);
    }

    [Server]
    public void SetPosition(Vector2Int v)
    {
        coords = v;
    }

    [Server]
    public void SetRotation(int r)
    {
        rotation = r;
    }
}
