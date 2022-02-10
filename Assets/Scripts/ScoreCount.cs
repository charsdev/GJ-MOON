using UnityEngine;
using TMPro;

public class ScoreCount : MonoBehaviour
{
    public TextMeshProUGUI scoreTxt;

    private void Update()
    {
        scoreTxt.text = GameManager.GameManagerInstance.score.ToString() + " / " + GameManager.GameManagerInstance.finalScore.ToString();
        WinGame();
    }
    
    private void WinGame()
    {
        GameManager.GameManagerInstance.winGame = GameManager.GameManagerInstance.score == GameManager.GameManagerInstance.finalScore;
    }
}
