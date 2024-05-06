using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ValidarClave : MonoBehaviour
{
    public TextMeshProUGUI cajaDeTexto;
    public TextMeshProUGUI pantalla;
    private Button botonValidar;
    public GameObject tapaArcon;
    // Start is called before the first frame update

    //Estos elementos estar�n ocultos en el ba�l hasta que se resuelva el enigma.
    public GameObject abrelatas;
    public GameObject cpu;
    public GameObject receta;

    private void Start()
    {
        botonValidar = GetComponent<Button>();
        botonValidar.onClick.AddListener(validarClave);
    }

    public void validarClave()
    {
        if (!Parametros.enigmaBuclesResuelto)
        {
            string textoCaja = cajaDeTexto.text;
            if (!string.IsNullOrEmpty(textoCaja))
            {
                textoCaja = textoCaja.Substring(0, textoCaja.Length - 1);
                //pantalla.text = "L1: " + textoCaja.Length + " L2: " + "reloj".Length;
                if (textoCaja == Parametros.claveEnigmaBucle)
                {
                    Parametros.enigmaBuclesResuelto = true;
                    pantalla.text = "Enigma 3 resuelto!!!  El ba�l se est� abriendo...";
                    abrelatas.SetActive(true);
                    cpu.SetActive(true);
                    receta.SetActive(true);
                    StartCoroutine(AbrirTapaDespuesDeEspera());
                }
                else
                {
                    pantalla.text = "Has fallado";
                    Invoke("textoInicial", 1f);
                }
            }
        }
        else
        {
            pantalla.text = "Enigma ya resuelto.  Comprueba el contenido del ba�l...";
        }
    }

    private void textoInicial()
    {
        pantalla.text = "Teclea la clave. No pierdas demasiado tiempo...";
    }

    IEnumerator AbrirTapaDespuesDeEspera()
    {
        yield return new WaitForSeconds(2f);
        //Animator animator = tapaArcon.GetComponent<Animator>();
        //animator.SetBool("abrirArcon", true);
        tapaArcon.transform.Rotate(new Vector3(-100f, 0f, 0f));
    }
}
