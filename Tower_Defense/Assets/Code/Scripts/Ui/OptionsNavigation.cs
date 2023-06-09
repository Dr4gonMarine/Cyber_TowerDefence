using UnityEngine;

public class OptionsNavigation : MonoBehaviour
{
    //[SerializeField] private GameObject _panelPrincipal;
    [SerializeField] private GameObject _inimigoseTorres;
    [SerializeField] private GameObject _Creditos;


   public void OpenInimigoseTorres()
   {    
    _inimigoseTorres.SetActive(true);
   }

    public void CloseInimigoseTorres()
    {
     _inimigoseTorres.SetActive(false);
    }

    public void OpenCreditos()
    {
        _Creditos.SetActive(true);
    }

    public void CloseCreditos()
    {
        _Creditos.SetActive(false);
    }   
}
