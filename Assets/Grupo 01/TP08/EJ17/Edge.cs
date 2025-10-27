using UnityEngine;

[CreateAssetMenu(fileName = "new Edge", menuName = "The Space/Edges")]
public class Edge : ScriptableObject
{
    [SerializeField] public int weight;
    [SerializeField] public Planet targetPlanet;
}
