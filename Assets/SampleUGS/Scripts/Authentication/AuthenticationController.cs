using System.Threading.Tasks;
using Unity.Services.Authentication;
using Unity.Services.Core;
using UnityEngine;

namespace SampleUGS.Authentication
{
    [DefaultExecutionOrder(-100)]
    public class AuthenticationController : MonoBehaviour
    {
        #region Variable Field

        [SerializeField] private AuthenticationEventChannel eventChannel;
        
        #endregion

        private void OnEnable()
        {
            eventChannel.OnRequestSignInAnonymouslyAsync += RequestSignInAnonymouslyAsync;
        }

        private void OnDisable()
        {
            eventChannel.OnRequestSignInAnonymouslyAsync -= RequestSignInAnonymouslyAsync;
        }

        #region Subscribers
        
        private async Task RequestSignInAnonymouslyAsync()
        {
            try
            {
                await AuthenticationService.Instance.SignInAnonymouslyAsync();
                Debug.Log($"PlayerID: {AuthenticationService.Instance.PlayerId}"); 
            }
            catch (AuthenticationException ex)
            {
                Debug.LogException(ex);
            }
            catch (RequestFailedException ex)
            {
                Debug.LogException(ex);
            }
        }
        
        #endregion
    }
}
