using TMPro;
using UnityEngine;

public class UpdateCoins : MonoBehaviour
{
    public TMP_Text myTMPText;
    
    public void UpdateText(string newtext)
    {
        myTMPText.text = newtext;
    }
        
}
