using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Mirror;

public class ServerButton : MonoBehaviour {

    [SerializeField]
    private NetworkManager manager;
    [SerializeField]
    private TextMeshProUGUI status;
    private Button button;
    private TextMeshProUGUI text;

    private void Awake() {
        button = GetComponent<Button>();
        text = GetComponentInChildren<TextMeshProUGUI>();
    }

    private void OnEnable() {
        button.onClick.AddListener(StartServer);
    }

    private void OnDisable() {
        button.onClick.RemoveAllListeners();
    }

    private void StartServer() {
        manager.StartServer();
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(StopServer);
        text.text = "Stop Server";
        status.text = "Starting server...";
    }

    private void StopServer() {
        manager.StopServer();
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(StartServer);
        text.text = "Start Server";
        status.text = "Stopping server...";
    }
}
