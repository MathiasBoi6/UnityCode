using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine;

public class Node : MonoBehaviour
{
    private Renderer rend;
    private Color startColor = Color.white;
    private Color hoverColor = Color.yellow;
    private Color OccuColor = Color.red;
    private GameObject tower = null;
    private (int, int) identity;

    public void SetIdentity(int a, int b)
    {
        identity = (a, b);
    }
    public (int, int) GetIdentity()
    {
        return identity;
    }

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        /*
        if (tower != null)
        {
            Debug.Log("Cannot Place");
            return;
        }
        else
        {
            GameObject towerSelected = BuildManager.buildInstance.GetTowerSelected();
            tower = Instantiate(towerSelected, transform.position, transform.rotation);
        }
        */

        BuildManager.buildInstance.Select();
    }

    public void CustomColor(Color color)
    {
        rend.material.color = color;
    }

    public void Highlight()
    {
        rend.material.color = hoverColor;
    }
    public void Unlight()
    {
        rend.material.color = startColor;
    }
    public void Occulight()
    {
        rend.material.color = OccuColor;
    }

    public bool IsOccupied()
    {
        if(tower == null)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public void SetTower(GameObject towerSet)
    {
        tower = towerSet;
    }
    public void ClearTower()
    {
        tower = null;
    }

    void OnMouseEnter()
    {
        BuildManager.buildInstance.UpdateSelection(identity.Item1, identity.Item2);
    }
}
