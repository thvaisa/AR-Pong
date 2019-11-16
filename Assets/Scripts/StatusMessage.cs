using UnityEngine;
using Mirror;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class StatusMessage : MonoBehaviour {

    [SerializeField]
    private NetworkManager manager;
    private TextMeshProUGUI text;

    private void Awake() {
        text = GetComponent<TextMeshProUGUI>();
    }

    private void Update() {
        if (NetworkServer.active) {
            text.text = "Server active.";
        }

        if (NetworkClient.isConnected) {
            text.text = "Client connected: " + manager.networkAddress;
        }

        if (!NetworkServer.active && !NetworkClient.active) {
            text.text = "Welcome!";
        }
    }
}