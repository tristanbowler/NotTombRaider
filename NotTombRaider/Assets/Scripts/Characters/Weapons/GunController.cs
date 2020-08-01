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
    void Start()
    {
        for(int i = 0; i<clipSize; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab, this.transform);
            reload.Add(bullet);
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
        }
    }

    public void Reload(GameObject bullet)
    {
        fired.Remove(bullet);
        reload.Add(bullet);
        bullet.transform.localPosition = bullet.GetComponent<BulletController>().startPosition;
        bullet.transform.localRotation = bullet.GetComponent<BulletController>().startRotation;
        bullet.SetActive(false);
    }

    public IEnumerator CoolDownTimer()
    {
        yield return new WaitForSeconds(1);
        coolDown = false;
    }
}
