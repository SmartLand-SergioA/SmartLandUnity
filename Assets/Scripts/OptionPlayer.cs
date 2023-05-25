using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

[RequireComponent(typeof(Button))] //Fuerza al objeto tenga un componente button
[RequireComponent(typeof(Image))]
public class OptionPlayer : MonoBehaviour
{
    private Text m_text = null;
    private Button m_button = null;
    private Image m_image = null;
    private Color m_colorOriginal = Color.black;

    public Option Option {get; set;}

    private void Awake()
    {
        m_button = GetComponent<Button>();
        m_image = GetComponent<Image>();
        m_text = transform.GetChild(0).GetComponent<Text>();
        m_colorOriginal = m_image.color;
    }

    public void Construct(Option option, Action<OptionPlayer> callback ) //Action<Option> callback sirve para notificar que opcion esta eligiendo el jugador
    {
        m_text.text = option.text;
        m_button.enabled = true;
        m_image.color = m_colorOriginal;
        Option = option;

        m_button.onClick.AddListener(delegate
        {
            callback(this);
        });
    }

    public void SetColor(Color c) //metodo para saber el color de si escogio una pregunta incorrecta o correcta
    {
        m_button.enabled = false;
        m_image.color = c;
    }

}
