using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Bot_Application2
{
    public class LUISClient
    {
        public static async Task<Luis_Type> ParseUserInput(string strInput)
        {
            string strRet = string.Empty;
            string strEscaped = Uri.EscapeDataString(strInput);

            using (var client = new HttpClient())
            {
                string uri = "https://api.projectoxford.ai/luis/v1/application?id=df2b06d4-695b-4e6f-85a6-f79b8ed698d7&subscription-key=9a54da9dd6e44f6081aa2eb78dece49d" + strEscaped;
                HttpResponseMessage msg = await client.GetAsync(uri);

                if (msg.IsSuccessStatusCode)
                {
                    var jsonResponse = await msg.Content.ReadAsStringAsync();
                    var _Data = JsonConvert.DeserializeObject<Luis_Type>(jsonResponse);
                    return _Data;
                }
            }
            return null;
        }

        public class Luis_Type
        {
            public string luis_schema_version { get; set; }
            public string name { get; set; }
            public string desc { get; set; }
            public string culture { get; set; }
            public Intent[] intents { get; set; }
            public Entity[] entities { get; set; }
            public string[] bing_entities { get; set; }
            public Action[] actions { get; set; }
            public Model_Features[] model_features { get; set; }
            public Regex_Features[] regex_features { get; set; }
            public Utterance[] utterances { get; set; }
        }

        public class Intent
        {
            public string Name { get; set; }
            public object[] Children { get; set; }
        }

        public class Entity
        {
            public string Name { get; set; }
            public object[] Children { get; set; }
        }

        public class Action
        {
            public string actionName { get; set; }
            public string intentName { get; set; }
            public Actionparameter[] actionParameters { get; set; }
        }

        public class Actionparameter
        {
            public string parameterName { get; set; }
            public string entityName { get; set; }
            public bool required { get; set; }
        }

        public class Model_Features
        {
            public string name { get; set; }
            public bool mode { get; set; }
            public string words { get; set; }
            public bool activated { get; set; }
        }

        public class Regex_Features
        {
            public string name { get; set; }
            public string pattern { get; set; }
            public bool activated { get; set; }
        }

        public class Utterance
        {
            public string text { get; set; }
            public string intent { get; set; }
            public Entity1[] entities { get; set; }
        }

        public class Entity1
        {
            public string entity { get; set; }
            public int startPos { get; set; }
            public int endPos { get; set; }
        }

    }
}