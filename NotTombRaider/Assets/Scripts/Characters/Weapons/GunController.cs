using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject bulletPrefab;
    public GameObject parentObject;
    public List<GameObject> fired;
    public List<GameObject> reload;
    public int clipSize;
    public bool coolDown = false;
    public float bulletForce = 10;
    public bool isPlayerWeapon;
    public GameObject player;
    public GameObject fireParticles;
    public Vector3 bulletRotation;

    void Start()
    {
        for(int i = 0; i<clipSize; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab, parentObject.transform.position, parentObject.transform.rotation, parentObject.transform);
            bullet.transform.localRotation = Quaternion.Euler(bulletRotation);
            bullet.GetComponent<BulletController>().parentObject = this.parentObject;
            reload.Add(bullet);
            bullet.GetComponent<BulletController>().startPosition = bullet.transform.position;
            
            bullet.GetComponent<BulletController>().startRotation = bullet.transform.localRotation;
            bullet.GetComponent<BulletController>().gun = this;
            bullet.SetActive(false);
        }
    }

   
    // Update is called once per frame
    void Update()
    {
         
    }

    public void FireBullet()
    {
        if (!coolDown)
        {
            
            coolDown = true;
            StartCoroutine(CoolDownTimer());
            GameObject bullet = reload[0];
            fired.Add(bullet);
            reload.Remove(bullet);
            bullet.SetActive(true);
            bullet.transform.parent = null; 
            
            bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.forward*bulletForce);
            StartCoroutine(Die(bullet.gameObject));
            
        }
    }

    private IEnumerator Die(GameObject bullet)
    {
        yield return new WaitForSeconds(2);
        fireParticles.SetActive(false);
        Reload(bullet);

    }
    public void Reload(GameObject bullet)
    {
        fired.Remove(bullet);
        reload.Add(bullet);
        Debug.Log("Parent OBJ: " + parentObject.name);
        
        Debug.Log("Parent: " + bullet.transform.parent);
        bullet.SetActive(false);
    }

    public IEnumerator CoolDownTimer()
    {
        yield return new WaitForSeconds(1);
        coolDown = false;
    }
}
