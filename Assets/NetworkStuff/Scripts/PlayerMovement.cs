using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class PlayerMovement : NetworkBehaviour
{
    private GridNetworkTransform gnt;
    // Start is called before the first frame update
    void Start()
    {
        gnt = this.GetComponent<GridNetworkTransform>();
        if (gnt == null)
        {
            throw new BadComponentException("This component requires a GridNetworkTransform on the object as well");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasAuthority)
        {
            return; //We don't want other people to be controlling us.
        }

        if (Input.GetButtonDown("Horizontal"))
        {
            CmdMove(Vector2Int.right * (Input.GetAxis("Horizontal") > 0 ? 1 : -1));
        } else if (Input.GetButtonDown(("Vertical"))) //we don't want diagonal movement (?)
        {
            CmdMove(Vector2Int.up * (Input.GetAxis("Vertical") > 0 ? 1 : -1));
        }
    }

    [Command]
    void CmdMove(Vector2Int dir)
    {
        gnt.coords += dir;
    }
}
