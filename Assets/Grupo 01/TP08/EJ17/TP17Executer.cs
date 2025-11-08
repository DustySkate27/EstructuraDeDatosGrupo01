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


    public void AddPlanet(PlanetConfig planet)
    {
        if (!originAssigned)
        {
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

    public void ExecuteRoad()
    {
        Debug.Log(spaceMonitor.VisitingPlanets());
        if (spaceMonitor.VisitingPlanets() != null)
        {
            weightUI.text = spaceMonitor.VisitingPlanets().ToString();
        }
        else
        {
            weightUI.text = "There's no valid road";
        }
    }

    public void ClearRoad()
    {
        planetsVisitedUI.text = string.Empty;
        weightUI.text = string.Empty;
        spaceMonitor.ClearVisitList();
        originAssigned = false;
    }



    //LOS CÓDIGOS A CONTINUACIÓN SON FUNCIONALES Y ESTÁN AUTOMATIZADOS, PERO SE DESCONTINUARON POR PETICIÓN DE KEVIN Y FEDE.
    //NO ES NECESARIO QUE LOS LEAN
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
