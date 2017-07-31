using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCreate : MonoBehaviour {
    // Use this for initialization
    [SerializeField]
    GameObject Enemy_000;
    [SerializeField]
    GameObject Enemy_001;
    [SerializeField]
    GameObject Enemy_002;
    [SerializeField]
    GameObject Enemy_003;
    [SerializeField]
    GameObject Enemy_004;

    void Start () {

        Instantiate(Enemy_000, new Vector3(0,1,-3), Quaternion.identity);
        Instantiate(Enemy_000, new Vector3(0, 1, -2.5f), Quaternion.identity);
        Instantiate(Enemy_000, new Vector3(0, 1, -2), Quaternion.identity);
        Instantiate(Enemy_000, new Vector3(0, 1, -1.5f), Quaternion.identity);

        Instantiate(Enemy_001, new Vector3(-55, 1, -3), Quaternion.identity);
        Instantiate(Enemy_001, new Vector3(-55, 1, -2.5f), Quaternion.identity);
        Instantiate(Enemy_001, new Vector3(-55, 1, -2), Quaternion.identity);
        Instantiate(Enemy_001, new Vector3(-55, 1, -1.5f), Quaternion.identity);

        Instantiate(Enemy_002, new Vector3(-89.3f, 1, -3), Quaternion.identity);
        Instantiate(Enemy_002, new Vector3(-89.3f, 1, -2.5f), Quaternion.identity);
        Instantiate(Enemy_002, new Vector3(-89.3f, 1, -2), Quaternion.identity);
        Instantiate(Enemy_002, new Vector3(-89.3f, 1, -1.5f), Quaternion.identity);

        Instantiate(Enemy_003, new Vector3(-35, 1, -3), Quaternion.identity);
        Instantiate(Enemy_003, new Vector3(-35, 1, -2.5f), Quaternion.identity);
        Instantiate(Enemy_003, new Vector3(-35, 1, -2), Quaternion.identity);
        Instantiate(Enemy_003, new Vector3(-35, 1, -1.5f), Quaternion.identity);

        Instantiate(Enemy_004, new Vector3(-20.3f, 1, -3), Quaternion.identity);
        Instantiate(Enemy_004, new Vector3(-20.3f, 1, -2.5f), Quaternion.identity);
        Instantiate(Enemy_004, new Vector3(-20.3f, 1, -2), Quaternion.identity);
        Instantiate(Enemy_004, new Vector3(-20.3f, 1, -1.5f), Quaternion.identity);

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
