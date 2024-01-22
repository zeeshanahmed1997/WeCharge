using System;
using Newtonsoft.Json;
using Xamarin.Essentials;

namespace WeCharge.Helpers
{
	public static class Utils
	{
        public static void StoreObjectInPreferences<T>(string key, T objectToStore)
        {
            var jsonString = JsonConvert.SerializeObject(objectToStore);
            Preferences.Set(key, jsonString);
        }
        public static T GetObjectFromPreferences<T>(string key) where T : new()
        {
            var jsonString = Preferences.Get(key, string.Empty);
            return string.IsNullOrEmpty(jsonString) ? new T() : JsonConvert.DeserializeObject<T>(jsonString);
        }
    }
}

