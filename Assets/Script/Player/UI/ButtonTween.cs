using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonTween : MonoBehaviour
{
    
        public Vector3 from = Vector3.one;
        public Vector3 to = Vector3.one * 0.95f;

        private void Start() {
            GetComponent<Button>().onClick.AddListener(() =>
            StartCoroutine(Scaling()));
            GetComponent<RectTransform>().localScale = from;
        }

        IEnumerator Scaling() {
            GetComponent<RectTransform>().localScale = to;
            yield return new WaitForSeconds(Time.fixedDeltaTime * 3);
            GetComponent<RectTransform>().localScale = from;
        }
    
}
