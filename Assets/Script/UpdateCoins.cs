using TMPro;
using UnityEngine;

public class UpdateCoins : MonoBehaviour
{
    [SerializeField]
    public TMP_Text myTMPText;
    

    private int currentScore = 0;
    
    public void UpdateText(int increment)
    {
        currentScore += increment;

        if (currentScore <= 5)
        {
            myTMPText.alignment = TextAlignmentOptions.TopLeft;
            myTMPText.text = currentScore.ToString();
        }
        else
        {
            myTMPText.alignment = TextAlignmentOptions.Center;
            myTMPText.text = "Você venceu";
            
            RectTransform textRect = myTMPText.GetComponent<RectTransform>();
            textRect.anchoredPosition3D = Vector3.zero;

            Time.timeScale = 0f;
        }

        
    }
        
}
