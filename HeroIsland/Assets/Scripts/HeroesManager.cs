using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroesManager : MonoBehaviour
{
    #region Singleton
    public static HeroesManager instance;

    private void Awake()
    {
        instance = this;
    }
    #endregion

    public List<GameObject> heroes;

}
