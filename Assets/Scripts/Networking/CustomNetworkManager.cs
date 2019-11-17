using UnityEngine;
using Mirror;

// Custom NetworkManager that simply assigns the correct racket positions when
// spawning players. The built in RoundRobin spawn method wouldn't work after
// someone reconnects (both players would be on the same side).
public class CustomNetworkManager : NetworkManager {

    #region Fields
    [SerializeField]
    private Transform leftPaddleSpawn;
    [SerializeField]
    private Transform rightPaddleSpawn;
    [SerializeField]
    private Transform ballSpawn;
    private GameObject ball;
    #endregion

    public override void OnServerAddPlayer(NetworkConnection conn)
    {
        // add player at correct spawn position
        Transform start = numPlayers == 0 ? leftPaddleSpawn : rightPaddleSpawn;
        GameObject player = Instantiate(playerPrefab, start.position, start.rotation);
        NetworkServer.AddPlayerForConnection(conn, player);

        // spawn ball if two players
        if (numPlayers == 2)
        {
            ball = Instantiate(spawnPrefabs.Find(prefab => prefab.name == "NetworkedBall"), ballSpawn.position, Quaternion.identity);
            NetworkServer.Spawn(ball);
        }
    }

    public override void OnStopServer()
    {
        // destroy ball
        // if (ball != null)
        //     NetworkServer.Destroy(ball);

        Debug.Log(GameObject.Find("World"));

        foreach (NetworkTransform nt in FindObjectsOfType<NetworkTransform>()){
            Debug.Log("zaheer");
            NetworkServer.Destroy(nt.gameObject);
        }

        // call base functionality (actually destroys the player)
        base.OnStopServer();
    }
}
