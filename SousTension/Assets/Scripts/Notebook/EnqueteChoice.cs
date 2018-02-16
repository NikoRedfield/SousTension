using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnqueteChoice : MonoBehaviour {

    public Button HighlightChoice;
    public NavigateEnquete enquete;

    private void Awake()
    {
        if(HighlightChoice != null)
        {
            HighlightChoice.Select();
            HighlightChoice.OnSelect(null);
        }

    }

    public void ChoiceSang1()
    {
        PlayerData.Sang1 = true;
        enquete.SetCurrentIndex(1);
        enquete.DisplayData(enquete.GetCurrentIndex(), 0);
        this.gameObject.SetActive(false);
        return;
    }

    public void ChoiceSang2()
    {
        PlayerData.Sang2 = true;
        enquete.SetCurrentIndex(2);
        enquete.DisplayData(enquete.GetCurrentIndex(), 0);
        this.gameObject.SetActive(false);
        return;
    }

    public void ChoiceJournal1()
    {
        PlayerData.Journal1 = true;
        enquete.SetCurrentIndex(1);
        enquete.DisplayData(enquete.GetCurrentIndex(), 4);
        this.gameObject.SetActive(false);
        return;
    }

    public void ChoiceJournal2()
    {
        PlayerData.Journal2 = true;
        enquete.SetCurrentIndex(2);
        enquete.DisplayData(enquete.GetCurrentIndex(), 4);
        this.gameObject.SetActive(false);
        return;
    }
}
