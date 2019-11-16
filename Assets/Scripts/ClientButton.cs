using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Mirror;

public class ClientButton : MonoBehaviour {

    [SerializeField]
    private NetworkManager manager;
    [SerializeField]
    private TextMeshProUGUI status;
    [SerializeField]
    private TMP_InputField ipField;
    private Button button;
    private TextMeshProUGUI text;

    private void Awake() {
        button = GetComponent<Button>();
        text = GetComponentInChildren<TextMeshProUGUI>();
    }

    private void OnEnable() {
        button.onClick.AddListener(Connect);
    }

    private void OnDisable() {
        button.onClick.RemoveAllListeners();
    }

    private void Connect() {
        manager.networkAddress = ipField.text;
        manager.StartClient();
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(Disconnect);
        text.text = "Disconnect";
        status.text = "Connecting...";
    }

    private void Disconnect() {
        manager.StopClient();
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(Connect);
        text.text = "Connect";
        status.text = "Disconnecting...";
    }
}
