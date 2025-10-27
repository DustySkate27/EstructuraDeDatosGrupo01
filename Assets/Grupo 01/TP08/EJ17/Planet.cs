using UnityEngine;

[CreateAssetMenu(fileName = "new Planet", menuName = "The Space/Planets")]
public class Planet : ScriptableObject
{
    [SerializeField] public string planet;
}
