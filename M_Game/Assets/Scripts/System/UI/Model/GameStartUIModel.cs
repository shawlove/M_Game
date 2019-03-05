using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStartUIModel  {

    public static GameStartUIModel Instance
    {
        get
        {
            if (m_Instance == null)
                m_Instance = new GameStartUIModel();
            return m_Instance;
        }
    }
    private static GameStartUIModel m_Instance;



}
