using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleDialogBox : MonoBehaviour
{
    [SerializeField] private Text dialogText;

    [SerializeField] private GameObject actionSelect;
    [SerializeField] private GameObject movementSelect;
    [SerializeField] private GameObject movementDesc;

    [SerializeField] private List<Text> actionTexts;
    [SerializeField] private List<Text> movementTexts;

    [SerializeField] private Text ppText;
    [SerializeField] private Text typeText;
    [SerializeField] private float timeToWaitAfterText = 1f;
    [SerializeField] private float charactersPerSecond = 10.0f;

    public bool isWriting = false;

    public AudioClip[] characterSounds;

    public IEnumerator SetDialog(string message)
    {
        isWriting = true;
        dialogText.text = "";
        foreach (var character in message)
        {
            if (character != ' ')
            {
                SoundManager.SharedInstance.RandomSoundEffect(characterSounds);
            }
            dialogText.text += character;
            yield return new WaitForSeconds(1/charactersPerSecond);
        }

        yield return new WaitForSeconds(timeToWaitAfterText);
        isWriting = false;
    }

    public void ToggleDialogText(bool activated)
    {
        dialogText.enabled = activated;
    }

    public void ToggleActions(bool activated)
    {
        actionSelect.SetActive(activated);
    }

    public void ToggleMovements(bool activated)
    {
        movementSelect.SetActive(activated);
        movementDesc.SetActive(activated);
    }

    public void SelectAction(int selectedAction)
    {
        for(int i = 0; i < actionTexts.Count; i++)
        {
            actionTexts[i].color = (i == selectedAction ? ColorManager.SharedInstance.SelectedColor : Color.black);
        }
    }

    public void SetPokemonMovements(List<Move> moves)
    {
        for (int i = 0; i < movementTexts.Count; i++)
        {
            if (i < moves.Count)
            {
                movementTexts[i].text = moves[i].Base.Name;
            }
            else
            {
                movementTexts[i].text = "---";
            }
        }
    }
    
    public void SelectMovement(int selectedMovement, Move move)
    {
        for(int i = 0; i < movementTexts.Count; i++)
        {
            movementTexts[i].color = (i == selectedMovement ? ColorManager.SharedInstance.SelectedColor : Color.black);
        }

        ppText.text = $"PP {move.Pp}/{move.Base.Pp}";
        typeText.text = move.Base.Type.ToString().ToUpper();

        ppText.color = ColorManager.SharedInstance.PPColor((float)move.Pp/move.Base.Pp);
        movementDesc.GetComponent<Image>().color = ColorManager.TypeColor.GetColorFromType(move.Base.Type);
    }

}
