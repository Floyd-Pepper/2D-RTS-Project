using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CharactersManager {

    private static List<MovableCharacter> _Characters = new List<MovableCharacter>();
    private static List<MovableCharacter> _SelectedCharacters = new List<MovableCharacter>();

    public static List<MovableCharacter> Characters
    {
        get { return _Characters; }
        set { _Characters = value; }
    }

    public static List<MovableCharacter> SelectedCharacters
    {
        get { return _SelectedCharacters; }
        set { _SelectedCharacters = value; }
    }

    public static void ProcessClickOnBackground(int mouseClick)
    {
        // déplacer les personnages à la position de la souris
        if(mouseClick == 1)
        {
            foreach (MovableCharacter character in _SelectedCharacters)
            {
                Vector2 target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                character.SetDestinationPosition(target);
                character.SetCurrentAction(MovableCharacter.Action.NONE);
            }
        }
        // désélectionner tous les personnages
        else if(mouseClick == 0)
        {
            DeselectAllCharacters();
        }
     }

    public static void DeselectAllCharacters()
    {
        foreach (MovableCharacter character in _SelectedCharacters)
        {
            character.IsSelected = false;
        }
        _SelectedCharacters.Clear();
    }

    public static void AddToSelectedCharacters(MovableCharacter character)
    {
        foreach (MovableCharacter alreadySelected in _SelectedCharacters)
        {
            if(alreadySelected == character)
            {
                return;
            }
        }
        _SelectedCharacters.Add(character);
        character.IsSelected = true;
    }
}
