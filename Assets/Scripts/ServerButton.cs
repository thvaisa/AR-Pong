using UnityEngine;
using UnityEngine.UI;
using Mirror;

public class ServerButton : MonoBehaviour {

    [SerializeField]
    private NetworkManager manager;
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
        manager.StartServer();
    }
}
