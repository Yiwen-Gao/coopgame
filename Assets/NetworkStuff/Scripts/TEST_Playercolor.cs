using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class TEST_Playercolor : NetworkBehaviour
{
    [SyncVar(hook = nameof(ChangeColor))] public Color playercolor;

    private MeshRenderer cached_mr;
    //Sync variables will automatically sync their values between the server and the clients.
    //This behavior ONLY works when the value is changed on the SERVER.
    
    //the hook will run the named function when the value of playercolor is changed.
    //it will be called with two arguments: the old value, and the new value.
    //it will only be called on clients - not the server.

    public override void OnStartServer()
    //OnStartServer is called when the object is initialized, but only on the server.
    {
        base.OnStartServer();
        playercolor = Random.ColorHSV(0, 1,1,1,1,1);
        ChangeColor(Color.black,playercolor); 
        // we call changecolor here because the hook will not automatically run it on the server.
        // technically, the host has both a server AND a client running, but if we were
        // to host a dedicated server, the server only would not see the color change
        // without this line.
    }

    public void ChangeColor(Color old_c,Color new_c)
    {
        if (cached_mr == null) cached_mr = GetComponent<MeshRenderer>();
        cached_mr.material.SetColor("_EmissionColor",new_c);
    }
}
