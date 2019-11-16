using UnityEngine;
using Mirror;

public class GameClient : MonoBehaviour {
    void Update() {
        if (NetworkClient.isConnected && !ClientScene.ready) {
            ClientScene.Ready(NetworkClient.connection);
            if (ClientScene.localPlayer == null) {
                ClientScene.AddPlayer();
            }
        }
    }
}
