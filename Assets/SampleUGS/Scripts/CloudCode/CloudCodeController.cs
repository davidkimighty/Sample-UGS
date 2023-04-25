using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SharedLibrary;
using Unity.Services.CloudCode;
using UnityEngine;

namespace SampleUGS.CloudCode
{
    [DefaultExecutionOrder(-100)]
    public class CloudCodeController : MonoBehaviour
    {
        #region Variable Field
        private const string s_moduleName = "Sample_UGS_CloudCode";

        [SerializeField] private CloudCodeEventChannel _eventChannel;

        #endregion

        private void OnEnable()
        {
            _eventChannel.OnRequestSayHelloAsync += SayHello;
        }

        private void OnDisable()
        {
            _eventChannel.OnRequestSayHelloAsync -= SayHello;
        }

        #region Subscribers
        private async Task SayHello(string name)
        {
            try
            {
                string result = await CloudCodeService.Instance.CallModuleEndpointAsync(s_moduleName, CloudCodeFunctions.SayHello.ToString(),
                    new Dictionary<string, object>
                    {
                        {"name", name}
                    });

                Message message = JsonUtility.FromJson<Message>(result);
                if (message != null)
                    Debug.Log($"[ CloudCode ] {message.content}");
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
        }

        #endregion
    }
    
    public enum CloudCodeFunctions
    {
        None,
        SayHello
    }
}
