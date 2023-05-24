using System;
using System.Collections.Generic;
using System.Text;
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
            _eventChannel.OnRequestSpinReelsAsync += SpinSlotMachine;
        }

        private void OnDisable()
        {
            _eventChannel.OnRequestSayHelloAsync -= SayHello;
            _eventChannel.OnRequestSpinReelsAsync -= SpinSlotMachine;
        }

        #region Subscribers
        private async Task SayHello(string name)
        {
            try
            {
                Message message = await CloudCodeService.Instance.CallModuleEndpointAsync<Message>(s_moduleName, CloudCodeFunctions.SayHello.ToString(),
                    new Dictionary<string, object>
                    {
                        {"name", name}
                    });

                Debug.Log($"[ CloudCode ] {message.content}");
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
        }

        private async Task SpinSlotMachine(int numberOfReels)
        {
            try
            {
                SpinResult reels = await CloudCodeService.Instance.CallModuleEndpointAsync<SpinResult>(s_moduleName, CloudCodeFunctions.SpinSlotMachine.ToString(),
                    new Dictionary<string, object>
                    {
                        {"numberOfReels", 3}
                    });

                StringBuilder builder = new StringBuilder();
                foreach (string spin in reels.spins)
                    builder.Append(spin + ",");
                Debug.Log($"[ CloudCode ] Slot Machine Result [ {builder.ToString()} ]");
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
        SayHello,
        SpinSlotMachine
    }
}
