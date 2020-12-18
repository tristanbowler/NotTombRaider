using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject bulletPrefab;
    public List<GameObject> fired;
    public List<GameObject> reload;
    public int clipSize;
    public bool coolDown = false;
    public float bulletForce = 10;
    public bool isPlayerWeapon;
    public GameObject player;
    void Start()
    {
        for(int i = 0; i<clipSize; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab, this.transform.position, this.transform.rotation, this.transform);
            reload.Add(bullet);
            bullet.GetComponent<BulletController>().startPosition = this.transform.position;
            bullet.GetComponent<BulletController>().startRotation = this.transform.rotation;
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
            bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.forward.normalized* bulletForce);
            bullet.GetComponent<BulletController>().Line();
            StartCoroutine(Die(bullet.gameObject));
        }
    }

    private IEnumerator Die(GameObject bullet)
    {
        yield return new WaitForSeconds(2);
        Reload(bullet);

    }
    public void Reload(GameObject bullet)
    {
        fired.Remove(bullet);
        reload.Add(bullet);
        //bullet.transform.localPosition = this.transform.position;
        //bullet.transform.localRotation = this.transform.rotation;
        bullet.SetActive(false);
    }

    public IEnumerator CoolDownTimer()
    {
        yield return new WaitForSeconds(1);
        coolDown = false;
    }
}
