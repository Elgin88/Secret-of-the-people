using System.Collections;
using TMPro;
using UnityEngine;

public class CanvasTempFPSIndicator : MonoBehaviour
{
    [SerializeField] private TMP_Text _tmpText;

    private WaitForSeconds _delay = new WaitForSeconds(0.5f);

    private void Start()
    {
        if (_tmpText == null)
        {
            Debug.Log("No serializefiel in " + gameObject.name);
        }

        StartCoroutine(ShowFPS());
    }

    private IEnumerator ShowFPS()
    {
        while (true)
        {
            _tmpText.text = Mathf.Round((1 / Time.deltaTime)).ToString();

            yield return _delay;
        }
    }
}