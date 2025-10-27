using System.Collections.Generic;
using UnityEngine;

public class PlanetConfig : MonoBehaviour
{
    [SerializeField] private Planet planet;
    public List<Edge> edgeList;

    public string PlanetName => planet.name;


}
