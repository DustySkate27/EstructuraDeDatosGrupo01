using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class TP17Executer : MonoBehaviour
{
    private string originPlanet;
    private string destinationPlanet;
    private bool originAssigned = false;

    [SerializeField] private SpaceMonitor spaceMonitor;

    [SerializeField] private TextMeshProUGUI weightUI;
    [SerializeField] private TextMeshProUGUI planetsVisitedUI;

    public void ExecuteRoad()
    {
        Debug.Log(spaceMonitor.VisitingPlanets());
        if (spaceMonitor.VisitingPlanets() != null)
        {
            weightUI.text = spaceMonitor.VisitingPlanets().ToString();
            spaceMonitor.ClearVisitList();
            originAssigned = false;
        }
        else
        {
            weightUI.text = "There's no valid road";
            spaceMonitor.ClearVisitList();
            originAssigned = false;
        }
    }

    public void AddPlanet(PlanetConfig planet)
    {
        if (!originAssigned)
        {
            planetsVisitedUI.text = string.Empty;
            weightUI.text = string.Empty;
            planetsVisitedUI.text += $"{planet.PlanetName} -> ";
            spaceMonitor.AddPlanetToVisit(planet);
            originAssigned = true;
        }
        else
        {
            planetsVisitedUI.text += $"{planet.PlanetName} -> ";
            spaceMonitor.AddPlanetToVisit(planet);
        }
        
    }

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

    /*
     * 
         _____
    ,-:` \;',`'-, 
  .'-;_,;  ':-;_,'.
 /;   '/    ,  _`.-\
| '`. (`     /` ` \`|
|:.  `\`-.   \_   / |
|     (   `,  .`\ ;'|
 \     | .'     `-'/
  `.   ;/        .'
    `'-._____.


    */
}
