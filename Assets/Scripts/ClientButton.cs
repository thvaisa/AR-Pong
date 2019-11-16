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

    private void Awake() {
        button = GetComponent<Button>();
    }

    private void OnEnable() {
        button.onClick.AddListener(OnClickHandler);
    }

    private void OnDisable() {
        button.onClick.RemoveAllListeners();
    }

    public void OnClickHandler() {
        manager.networkAddress = ipField.text;
        manager.StartClient();
        status.text = "Connecting...";
    }
}
