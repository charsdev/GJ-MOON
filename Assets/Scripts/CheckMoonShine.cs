using UnityEngine;

public class CheckMoonShine : MonoBehaviour
{

    public DialogueCanvasController dialogue;

    public void CheckDialogue()
    {
        if (Inventory.Instance.hasMoonShine)
        {
            GameManager.GameManagerInstance.score += 1;
            dialogue.ActivateCanvasWithText("Gracias me has curado");
        }
        else
        {
            dialogue.ActivateCanvasWithText("Necesito Moonshine si no morire...");
        }
    }
}
