using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseMissions : MonoBehaviour
{
    [SerializeField] private GameObject[] _missions;
    [SerializeField] private GameObject _chooseButton;

    public void OnClickChoose()
    {
        int random = Random.Range(0, _missions.Length);

        switch (random)
        {
            case 0:
                _missions[0].gameObject.SetActive(true);
                break;
            case 1:
                _missions[1].gameObject.SetActive(true);
                break;
            case 2:
                _missions[2].gameObject.SetActive(true);
                break;
        }

        _chooseButton.SetActive(false);
    }
}
