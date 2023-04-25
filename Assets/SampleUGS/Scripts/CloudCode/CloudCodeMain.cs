using System;
using SampleUGS.Authentication;
using Unity.Services.Core;
using Unity.Services.Core.Environments;
using UnityEngine;

namespace SampleUGS.CloudCode
{
    public class CloudCodeMain : MonoBehaviour
    {
        #region Variable Field
        private const string s_productionEnv = "production";
        private const string s_developmentEnv = "development";
        
        [SerializeField] private bool _isDevelopment;
        [SerializeField] private AuthenticationEventChannel _authenticationEventChannel;
        [SerializeField] private CloudCodeEventChannel _cloudCodeEventChannel;

        #endregion

        private async void Awake()
        {
            try
            {
                InitializationOptions options = new InitializationOptions();
                options.SetEnvironmentName(_isDevelopment ? s_developmentEnv : s_productionEnv);
                await UnityServices.InitializeAsync(options);
                await _authenticationEventChannel.RequestSignInAnonymouslyAsync();
                
                await _cloudCodeEventChannel.RequestSayHelloAsync("World");
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
        }
    }
}
