using System;
using Unity.Services.RemoteConfig;
using UnityEngine;

namespace SampleUGS.RemoteConfig
{
    public class RemoteConfigController : MonoBehaviour
    {
        #region Private Functions
        private T GetDataFromJson<T>(string key) where T : new()
        {
            try
            {
                string json = RemoteConfigService.Instance.appConfig.GetJson(key);
                if (string.IsNullOrEmpty(json)) return default;

                return JsonUtility.FromJson<T>(json);
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
            return default;
        }

        private string GetDataFromString(string key)
        {
            try
            {
                return RemoteConfigService.Instance.appConfig.GetString(key);
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
            return null;
        }
        #endregion
    }
    
    public struct userAttributes
    {
        
    }

    public struct appAttributes
    {

    }
    
    public struct filterAttributes
    {
        public string[] key;
        public string[] type;
        public string[] schemaId;
    }
}
