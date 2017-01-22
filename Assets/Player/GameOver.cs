using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {

    void Start() {
        GameObject.Find("score").GetComponent<Text>().text = KeepingItems.Instance.FinalScore.ToString();
    }

    public void RestartGame() {
        SceneManager.LoadScene("main_menu");
    }

    public void ExitGame() {
        Application.Quit();
    }
}
