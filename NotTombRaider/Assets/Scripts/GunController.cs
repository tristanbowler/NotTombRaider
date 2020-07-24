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
    public Vector3 playerForward;
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
        playerForward = this.transform.parent.forward;
        if (Input.GetKey(KeyCode.Space) && coolDown == false)
        {
            FireBullet();
            coolDown = true;
            StartCoroutine(CoolDownTimer());
        }
    }

    public void FireBullet()
    {
        GameObject bullet = reload[0];
        fired.Add(bullet);
        reload.Remove(bullet);
        bullet.SetActive(true);
        bullet.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, bulletForce));
    }

    public void Reload(GameObject bullet)
    {
        fired.Remove(bullet);
        reload.Add(bullet);
        bullet.transform.position = bullet.GetComponent<BulletController>().startPosition;
        bullet.transform.rotation = new Quaternion(0, 0, 0, 0);
        bullet.SetActive(false);
    }

    private IEnumerator CoolDownTimer()
    {
        yield return new WaitForSeconds(1);
        coolDown = false;
    }
}
