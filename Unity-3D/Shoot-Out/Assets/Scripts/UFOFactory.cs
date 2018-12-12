using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UFOFactory : System.Object
{
    private static UFOFactory _instance;
	public GameObject disk; 
    private static List<GameObject> diskList; 
         

    public static UFOFactory getInstance()
    {
        if (_instance == null)
        {
            _instance = new UFOFactory();
            diskList = new List<GameObject>();
        }

        return _instance;
    }

	public GameObject getDiskObject(int id)
	{
		if (id > -1 && id < diskList.Count)
		{
			return diskList[id];
		}

		return null;
	}

    public int getDiskId()
    {
        for (int i = 0; i < diskList.Count; ++i)
        {
            if (!diskList[i].activeInHierarchy)
            {
                return i;
            }
        }

        diskList.Add(GameObject.Instantiate(disk) as GameObject);
        return diskList.Count - 1;
    }

    
    public void free(int id)
    {
        if (id > -1 && id < diskList.Count)
        {

            diskList[id].GetComponent<Rigidbody>().velocity = Vector3.zero;
        
            diskList[id].transform.localScale = disk.transform.localScale;

            diskList[id].SetActive(false);
        }
    }
}