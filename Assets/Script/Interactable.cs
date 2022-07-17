using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Interactable : MonoBehaviour
{
    public string textInformation;
    public Text textMeshPro;
    public GameObject panelInformationText;
    public void ShowMessage()
    {
        if (!panelInformationText.active)
        {
            textMeshPro.text = textInformation;
            panelInformationText.SetActive(true);
            StartCoroutine(WaitToHide());
        }
    }
    public void HideMessage()
    {
        textMeshPro.text = "";
        panelInformationText.SetActive(false);
    }
    IEnumerator WaitToHide()
    {
        yield return new WaitForSeconds(2f);
        panelInformationText.SetActive(false);
    }
}
