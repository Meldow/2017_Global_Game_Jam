using System.Collections;
using UnityEngine;

public class DestroyMeAfterSeconds : MonoBehaviour {
    public float timeToLive = 3;
    // Use this for initialization
    void Start() {
        StartCoroutine(FutureSuicide(timeToLive));
    }

    IEnumerator FutureSuicide(float timer) {
        yield return new WaitForSeconds(timer);
        Destroy(gameObject);
    }
}
