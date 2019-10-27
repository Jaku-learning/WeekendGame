using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSystem : MonoBehaviour, IWeapon
{
    public static WeaponSystem instance { get; set; }

    [SerializeField] private int noWeaponDamage;
    [SerializeField] private ParticleSystem areaEffect;

    //[SerializeField] private GameObject weaponPrefab;
    [SerializeField] private GameObject shootPrefab;

    public bool rangeWeapon { get; set; }

    private string weaponName;
    private int weaponDamage;
    private int projectilesPerShoot;
    private float weaponSpread;
    private float fireRate;

    [SerializeField] private float startTimeBetweenArea;
    [SerializeField] private float timeBetweenArea;

    private Transform weaponTransform;

    [SerializeField] private GameObject areaHitbox;

    public float timeBetweenShots;
    public float startTimeBetweenShots;


    public WeaponSystem(string weaponName, float fireRate, int weaponDamage, int projectilesPerShoot, bool rangeWeapon)
    {
        this.weaponName = weaponName;
        this.fireRate = fireRate;
        this.weaponDamage = weaponDamage;
        this.projectilesPerShoot = projectilesPerShoot;
        this.rangeWeapon = rangeWeapon;
        this.weaponSpread = 0f;
    }

    public WeaponSystem(string weaponName, float fireRate, int weaponDamage, int projectilesPerShoot, float weaponSpread, bool rangeWeapon)
    {
        this.weaponName = weaponName;
        this.fireRate = fireRate;
        this.weaponDamage = weaponDamage;
        this.projectilesPerShoot = projectilesPerShoot;
        this.rangeWeapon = rangeWeapon;
        this.weaponSpread = weaponSpread;
    }

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        weaponTransform = GetComponent<Transform>();
    }


    private void Update()
    {
        CheckIfRange();
        Attack();
    }

    public void Attack()
    {
        if (timeBetweenArea <= 0)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                StartCoroutine(DamageArea());
                timeBetweenArea = startTimeBetweenArea;
                PlayAreaEffect();
            }
        }
        else
        {
            timeBetweenArea -= Time.deltaTime;
        }
        
    }

    public void CheckIfRange()
    {
        if (rangeWeapon)
        {
            if (timeBetweenShots <= 0)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    Instantiate(shootPrefab, Player.instance.transform.position, Quaternion.identity);
                    timeBetweenShots = startTimeBetweenShots;
                }
            }
            else
            {
                timeBetweenShots -= Time.deltaTime;
            }
        }
        else
        {
            return;
        }
    }

    public int GetWeaponDamage()
    {
        return weaponDamage;
    }

    IEnumerator DamageArea()
    {
        CameraShake.Shake(0.4f, 0.6f);
        areaHitbox.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        areaHitbox.SetActive(false);
        CameraShake.Shake(0f, 0f);
    }

    public int GetProjectilesAmount()
    {
        return projectilesPerShoot;
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("enemy"))
        {
            EnemyManager.instance.TakeDamage(noWeaponDamage);
        }
    }

    void PlayAreaEffect()
    {
        areaEffect.Play();
    }


}
