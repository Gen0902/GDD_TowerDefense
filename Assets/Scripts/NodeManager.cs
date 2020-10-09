using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeManager : MonoBehaviour
{

    public static NodeManager Instance;

    public GameObject waypointsParent;

    [HideInInspector]
    public List<Vector2> wayPoints;
    private Transform[] wayPointsTr;


    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogWarning("More than one instance of NodeManager found !");
            return;
        }
        Instance = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        wayPointsTr = waypointsParent.GetComponentsInChildren<Transform>();

        for (int i = 0; i < wayPointsTr.Length; i++)
        {
            if (wayPointsTr[i] != waypointsParent.transform)
                wayPoints.Add(wayPointsTr[i].position);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
