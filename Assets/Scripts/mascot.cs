using UnityEngine;
using Mirror;
using TMPro;

public class Mascot : NetworkBehaviour {

    [SerializeField]
    private RectTransform gameOver;
 
    [ServerCallback]
    void OnTriggerEnter(Collider collision) {
        if (collision.gameObject.name == "floor") {
            gameOver.gameObject.SetActive(true);
            if (gameObject.name == "chicken") {
                gameOver.Find("Result").GetComponent<TextMeshProUGUI>().text = "The Pig WON!";
            } else {
                gameOver.Find("Result").GetComponent<TextMeshProUGUI>().text = "The Chicken WON!";
            }
        }
    }
}
