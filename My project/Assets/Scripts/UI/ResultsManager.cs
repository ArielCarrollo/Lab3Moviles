using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ResultsManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI finalscoretxt;
    [SerializeField] Score_LifeDataSO finalscore;
    [SerializeField] private PaletteSO paletteColor;
    private void Start()
    {
        finalscoretxt.GetComponent<TMP_Text>().color = paletteColor.color;
        finalscoretxt.text = "Final Score:" + finalscore.currentScore;
    }
}
