using UnityEngine;

public class TP17Executer : MonoBehaviour
{
    private string originPlanet;
    private string destinationPlanet;
    private bool originAssigned = false;

    [SerializeField] private SpaceMonitor spaceMonitor;

    public void AssignNames(string input)
    {
        if (!originAssigned)
        {
            originPlanet = input;
            originAssigned = true;
        }
        else
        {
            destinationPlanet = input;
            originAssigned = false;
            Debug.Log(spaceMonitor.GetRoad(originPlanet, destinationPlanet));
        }
    }
}
