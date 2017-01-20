using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Util;

namespace UI {
    public class WorldText : Singleton<WorldText> {
        [SerializeField]
        private RectTransform backgroundRectTransform;
        [SerializeField]
        private RectTransform textRectTransform;
        [SerializeField]
        private Text textValue;

        public void SetText(string text) {
            RemoveText();
            StartCoroutine("SetNewText", text);
        }

        public void RemoveText() {
            StopCoroutine("SetNewText");
        }

        private IEnumerator SetNewText(string text) {
            backgroundRectTransform.gameObject.SetActive(true);
            textValue.text = text;
            textRectTransform.sizeDelta = new Vector2(textValue.preferredWidth, textValue.preferredHeight);
            backgroundRectTransform.sizeDelta = new Vector2(textValue.preferredWidth + 10, textValue.preferredHeight + 10);
            yield return new WaitForSeconds(7);
            backgroundRectTransform.gameObject.SetActive(false);
        }



    }
}
