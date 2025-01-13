using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] private TMP_Text actualAmmoText;
    [SerializeField] private TMP_Text rechargedText;
    [SerializeField] private float timerToDespawnTextRecharged;
    private float currentTimerToDespawnTextRecharged;
    public ArmaSO pistolaSO;
    public ArmaSO bazocaSO;

    private GameObject currentWeapon;

    [Header("Weapons")]
    [SerializeField]
    private GameObject weapon1;
    [SerializeField]

    private GameObject weapon2;

    void Start()
    {
        if (weapon1 != null && weapon2 != null)
        {
            weapon1.SetActive(true);
            weapon2.SetActive(false);
            currentWeapon = weapon1;
            UpdateAmmoText();
        }
        else
        {
            Debug.LogError("Weapons not assigned in the Inspector!");
        }

        currentTimerToDespawnTextRecharged = timerToDespawnTextRecharged;
        RefillAllAmmo(true);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SwitchWeapon(weapon1);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SwitchWeapon(weapon2);
        }

        if (currentTimerToDespawnTextRecharged < -10f)
        {
            return;
        }

        currentTimerToDespawnTextRecharged -= Time.deltaTime;
        if (currentTimerToDespawnTextRecharged <= 0)
        {
            rechargedText.gameObject.SetActive(false);
        }
    }

    void SwitchWeapon(GameObject weaponToActivate)
    {
        if (weaponToActivate != null && currentWeapon != weaponToActivate)
        {
            if (currentWeapon != null)
            {
                currentWeapon.SetActive(false);
            }

            weaponToActivate.SetActive(true);
            currentWeapon = weaponToActivate;
            UpdateAmmoText();
        }
    }

    void UpdateAmmoText()
    {
        var bazoca = currentWeapon.GetComponent<Bazoca>();
        if (bazoca != null)
        {
            actualAmmoText.text = bazoca.misDatos.balasCargador.ToString();
            return;
        }

        var armaAutomatica = currentWeapon.GetComponent<ArmaAutomatica>();
        if (armaAutomatica != null)
        {
            actualAmmoText.text = armaAutomatica.misDatos.balasCargador.ToString();
            return;
        }

        actualAmmoText.text = "N/A";
    }

    public void RefillAllAmmo(bool firstLoadingGame = false)
    {
        pistolaSO.balasCargador = pistolaSO.balasBolsa;
        bazocaSO.balasCargador = bazocaSO.balasBolsa;

        if (!firstLoadingGame)
        {
            currentTimerToDespawnTextRecharged = timerToDespawnTextRecharged;
            rechargedText.gameObject.SetActive(true);
        }

        UpdateAmmoText();
    }
}
