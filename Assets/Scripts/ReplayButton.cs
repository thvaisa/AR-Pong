using UnityEngine;
using UnityEngine.UI;
using Mirror;

public class ReplayButton : MonoBehaviour {

    [SerializeField]
    private NetworkManager manager;
    private Button button;

    private void Awake() {
        button = GetComponent<Button>();
    }

    private void OnEnable() {
        button.onClick.AddListener(Replay);
    }

    private void OnDisable() {
        button.onClick.RemoveAllListeners();
    }

    private void Replay() {
        manager.StopServer();
        button.onClick.RemoveAllListeners();
    }
}
