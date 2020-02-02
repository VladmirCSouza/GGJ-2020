using UnityEngine;

[CreateAssetMenu(fileName = "Scene Config", menuName = "Channel 3/New Scene Config", order = 1)]
public class SceneConfigurationScriptableObject : ScriptableObject
{
    [SerializeField]
    private int numberOfPieces = 1; 
    public int NumberOfPieces => numberOfPieces;

    [SerializeField, TextArea]
    private string gameMessage = "";
    public string GameMessage => gameMessage;
}
