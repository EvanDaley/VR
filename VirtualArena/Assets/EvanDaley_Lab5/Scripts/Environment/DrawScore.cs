using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DrawScore : MonoBehaviour {

    public static DrawScore Instance;
    private Text m_Text;

    public void Awake()
    {
        Instance = this;
    }

    public string Text
    {
        get
        {
            return m_Text.text;
        }
        set
        {
            if (m_Text == null)
                m_Text = gameObject.GetComponent<Text>();

            m_Text.text = value;
        }
    }
}
