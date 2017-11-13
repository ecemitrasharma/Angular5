using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{

    public class Schema
    {

        public string type { get; set; }
        public Response items { get; set; }
    }

    public class SwagModel
    {
        public Dictionary<string, object> paths { get; set; }

        public Dictionary<string, dynamic> definitions { get; set; }
    }






    public class Responses
    {
        public string description { get; set; }
        public Schema schema { get; set; }

    }

    public class Get
    {
        public List<string> tags { get; set; }
        public string operationId { get; set; }
        public List<object> consumes { get; set; }
        public List<string> produces { get; set; }
        public Dictionary<string, Response> responses { get; set; }
        public List<Parameter> parameters { get; set; }
    }
    public class Post
    {
        public List<string> tags { get; set; }
        public string operationId { get; set; }
        public List<object> consumes { get; set; }
        public List<string> produces { get; set; }
        public dynamic responses { get; set; }
        public List<Parameter> parameters { get; set; }


    }


    public class Put
    {
        public List<string> tags { get; set; }
        public string operationId { get; set; }
        public List<object> consumes { get; set; }
        public List<string> produces { get; set; }
        public Dictionary<string, Response> responses { get; set; }
        public List<Parameter> parameters { get; set; }
    }

    public class Delete
    {
        public List<string> tags { get; set; }
        public string operationId { get; set; }
        public List<object> consumes { get; set; }
        public List<string> produces { get; set; }
        public Dictionary<string, Response> responses { get; set; }
        public List<Parameter> parameters { get; set; }

    }




    public class Parameter
    {
        public JObject schema;
        public string name { get; set; }
        public string @in { get; set; }
        public bool required { get; set; }
        public string type { get; set; }


    }

    public class Response
    {
        public string description;
        public dynamic schema;
        public Response items { get; set; }

    }

    public class RootObject
    {
        public Get get { get; set; }
        public Post post { get; set; }

        public Put put { get; set; }

        public Delete delete { get; set; }

    }

    public class Properties
    {
        public string type { get; set; }

        [JsonProperty(PropertyName = "$ref")]

        public string refType { get; set; }
        public Items items { get; set; }

    }

    public class Mitra
    {

        public Dictionary<string, JObject> properties { get; set; }

        public string type { get; set; }
    }


    //for list type
    public class Items
    {
        public string type { get; set; }
        public Items items { get; set; }
    }

    public class RootObject1
    {
        public string type { get; set; }
        public Items items { get; set; }
    }








    class Program
    {

        public static string getBasicSyntax(string modName, string swaggerMethod, string modelName, string interfaceString, string baseUrl)
        {

            var dependecy = "['$http', '$q']";
            StringBuilder str = new StringBuilder("");
            //str.Append("///<reference path= './service.model.ts'/>" + System.Environment.NewLine);
            str.Append("import { Injectable }from '@angular/core';" + System.Environment.NewLine);
            str.Append("import { Http, Response } from '@angular/http';" + System.Environment.NewLine);
            str.Append("import { Headers, RequestOptions } from '@angular/http';" + System.Environment.NewLine);
            //str.Append("module customHttp {\n");
            str.Append(System.Environment.NewLine + "export interface ICustomNgHttpService{" + System.Environment.NewLine);
            str.Append(interfaceString);
            str.Append(System.Environment.NewLine + "}");
            //str.Append(System.Environment.NewLine + modelName + System.Environment.NewLine);
            
            str.Append("@Injectable()" + System.Environment.NewLine);

            str.Append(System.Environment.NewLine + "export class CustomNgHttpService implements ICustomNgHttpService {" + System.Environment.NewLine + @"
             baseUrl: string ='" + baseUrl + "';" + System.Environment.NewLine);
            str.Append("static $inject = " + dependecy + ";\n constructor(private http: Http){}");

            var commonMethod = System.Environment.NewLine +
     @"public GetCall<T>(url : string):Promise<T>{
     return this.http.get(url).toPromise()
    .then(i => <T>i.json())
 .catch(this.handleError);
    }

PostCall<T>(url: string, data: any,config:any): Promise<any> {
       
        return this.http.post(url, data)
        .toPromise()
        .then(i=> i.json())
        .catch(this.handleError)
    
}

PutCall<T> (url : string,data : any, config : any): Promise<T> {

 return this.http.put(url, data, config)
                .toPromise()
        .then(i=> i.json())
        .catch(this.handleError)
}

    DeleteCall<T>(url: string, data: any, config: any){
    return this.http.delete(url)
    .toPromise()
    .then(i=> i.json())
    .catch(this.handleError)
}

private handleError (error:   any) {
    // In a real world app, we might use a remote logging infrastructure<br/>
    let errMsg: string;
    if (error instanceof Response) {
      const body = error.json() || '';
      const err = body.error || JSON.stringify(body);
      errMsg = `${error.status} - ${error.statusText || ''} ${err}`;
    } else {
      errMsg = error.message ? error.message : error.toString();
    }
    console.error(errMsg);
    return Promise.reject(errMsg);


}";


            str.Append(commonMethod + System.Environment.NewLine);

            str.Append(swaggerMethod);



            //str.Append(@"static factory() {" + System.Environment.NewLine + @"var instance = ($q: ng.IQService, $http: ng.IHttpService) => new CustomNgHttpService($http, $q);
            //    return instance;" + System.Environment.NewLine + @"}");

            str.Append("}" + System.Environment.NewLine);

            //str.Append("angular.module('customHttp', ['Poseidon']).factory('CustomNgHttpService', CustomNgHttpService.factory());" + System.Environment.NewLine);

            //str.Append("}");




            return str.ToString();
        }


        static void Main(string[] args)
        {

            var aaaasasa = typeof(string);

            Console.WriteLine(Path.GetFullPath("./"));
            string baseUrl = "";
            string location = "";


            if (args.Length > 0)
            {
                baseUrl = args[0];
                location = args[1];
                Console.WriteLine(location);

            }
            else
            {
                baseUrl = "http://localhost:59436/";
                location = "../app/http-services/";

            }

            Console.Write(baseUrl + "--->" + location);


            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(baseUrl);
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            var url = "swagger/docs/v1";
            var response = client.GetAsync(url).Result;
            dynamic stringJson = response.Content.ReadAsStringAsync().Result.ToString();
            SwagModel abc = Newtonsoft.Json.JsonConvert.DeserializeObject<SwagModel>(stringJson);

            var modelName = "";

            foreach (var item in abc.definitions)
            {
                var model = item.Value.ToString();

                bool isArrayForModel = false;

                modelName += System.Environment.NewLine + System.Environment.NewLine + "interface ";

                modelName += "I" + item.Key + "{";

                var aaaaaa = JsonConvert.DeserializeObject<Mitra>(model);

                var fullName = "";

                foreach (var propname in aaaaaa.properties)
                {
                    isArrayForModel = false;
                    modelName += System.Environment.NewLine + propname.Key + " : ";

                    if (propname.Value != null)
                    {

                        var ttt = propname.Value.ToString();
                        var ww = JsonConvert.DeserializeObject<Properties>(ttt);

                        if (ww != null && ww.type == "array" && ww.items != null)
                        {
                            isArrayForModel = true;
                            ww.type = ww.items.type;
                        }


                        if (ww == null)
                        {
                            //for complex type
                            var type = getType("", propname.Value, isArrayForModel);

                            modelName += type + ";" + System.Environment.NewLine;


                        }
                        else if (ww.type != null)
                        {

                            var type = getType(ww.type, "", isArrayForModel);
                            modelName += type + ";";
                        }

                    }

                }

                modelName += System.Environment.NewLine + "}";

            }


            var method = "";
            var imethod = "";
            foreach (var item in abc.paths)
            {
                var str = abc.paths[item.Key].ToString();
                RootObject data = Newtonsoft.Json.JsonConvert.DeserializeObject<RootObject>(abc.paths[item.Key].ToString());

                // got get call
                if (data.get != null)
                {

                    var paramSignature = "";
                    var paramDefinition = "";

                    if (data.get.parameters != null)
                    {

                        for (int i = 0; i < data.get.parameters.Count; i++)
                        {
                            if (data.get.parameters[i].type == null)
                            {

                            }

                            paramSignature += (i == 0 ? "" : ",") + data.get.parameters[i].name + " : " + getType(data.get.parameters[i].type, data.get.parameters[i].schema, false);
                            paramDefinition += (i == 0 ? "'?'+" : "+'&'+") + "'" + data.get.parameters[i].name + "='+" + data.get.parameters[i].name;
                        }
                    }

                    var responseType = "";

                    if (data.get.responses != null)
                    {
                        if (data.get.responses.Values != null)
                        {
                            if (data.get.responses.Values.FirstOrDefault().schema != null)
                            {
                                responseType = getType("", data.get.responses.Values.FirstOrDefault().schema.ToString(), false);
                            }
                            else
                            {
                                responseType = "any";
                            }
                        }
                        else
                        {
                            responseType = getType("", data.get.responses, false);
                        }
                    }
                    imethod = imethod + data.get.operationId + "(" + paramSignature + @"): Promise<" + responseType + ">;" + System.Environment.NewLine;

                    method = method + data.get.operationId + "(" + paramSignature + @"): Promise<" + responseType + ">" + @"{
                    var url = this.baseUrl+'" + data.get.tags[0] + "'+'\\\\'+" + "'" + data.get.operationId.Split('_')[1] + (paramDefinition == "" ? "'" : "'+'\\\\'+") + paramDefinition + @"; " + System.Environment.NewLine + " return this.GetCall<" + responseType + ">(url);" + System.Environment.NewLine + "}";

                }

                //method += System.Environment.NewLine;

                // for post call

                if (data.post != null)
                {
                    var apiUrl = "";
                    var paramSignature = "";
                    var paramDefinition = "";

                    if (data.post.parameters != null)
                    {

                        for (int i = 0; i < data.post.parameters.Count; i++)
                        {
                            paramSignature += (i == 0 ? "" : ",") + data.post.parameters[i].name + " : " + getType(data.post.parameters[i].type, data.post.parameters[i].schema, false);
                            //paramDefinition += "{" + (i == 0 ? " " : ",") + "'" + data.post.parameters[i].name + "' : " + data.post.parameters[i].name;
                            paramDefinition += data.post.parameters[i].@in == "body" ? data.post.parameters[i].name + "," : "";
                        }


                    }

                    paramDefinition = paramDefinition.TrimEnd(',');

                    apiUrl = getApiUrl(data.post.parameters);

                    var uurrll = "this.baseUrl+'" + data.post.tags[0] + "'+'\\\\'+'" + data.post.operationId.Split('_')[1] + "'+" + apiUrl;
                    uurrll = uurrll.TrimEnd('+');

                    var responseType = "";

                    if (data.post.responses.Values != null)
                    {
                        responseType = getType("", data.post.responses.Values.FirstOrDefault().schema.ToString(), false);
                    }
                    else
                    {
                        responseType = getType("", data.post.responses, false);
                    }


                    imethod = imethod + data.post.operationId + "(" + paramSignature + @"): Promise<" + responseType + ">;" + System.Environment.NewLine;
                    method = method + data.post.operationId + "(" + paramSignature + @"): Promise<" + responseType + ">" + @"{
                    var url = " + uurrll + @"; " + System.Environment.NewLine + " return this.PostCall<" + responseType + ">(url, " + (paramDefinition == "" ? "''" : paramDefinition) + ", '');" + System.Environment.NewLine + "}";

                }


                //method += System.Environment.NewLine;


                // for put call

                if (data.put != null)
                {

                    var paramSignature = "";
                    var paramDefinition = "";
                    var apiUrl = "";

                    if (data.put.parameters != null)
                    {




                        for (int i = 0; i < data.put.parameters.Count; i++)
                        {
                            paramSignature += (i == 0 ? "" : ",") + data.put.parameters[i].name + " : " + getType(data.put.parameters[i].type, data.put.parameters[i].schema, false);
                            //paramDefinition += "{" + (i == 0 ? " " : ",") + "'" + data.post.parameters[i].name + "' : " + data.post.parameters[i].name;
                            paramDefinition += data.put.parameters[i].@in == "body" ? data.put.parameters[i].name + "," : "";
                        }


                    }

                    paramDefinition = paramDefinition.TrimEnd(',');

                    apiUrl = getApiUrl(data.put.parameters);

                    var uurrll = "this.baseUrl+'" + data.put.tags[0] + "'+'\\\\'+'" + data.put.operationId.Split('_')[1] + "'+" + apiUrl;
                    uurrll = uurrll.TrimEnd('+');

                    var responseType = "";

                    if (data.put.responses != null)
                    {

                        if (data.put.responses.Values != null && data.put.responses.Values.FirstOrDefault().schema != null)
                        {

                            responseType = getType("", data.put.responses.Values.FirstOrDefault().schema, false);
                        }


                        if (data.put.responses.Values != null && data.put.responses.Values.FirstOrDefault() != null && data.put.responses.Values.FirstOrDefault().description.IndexOf("No Content") >= 0)
                        {
                            responseType = "void";
                        }
                        else if (responseType == "")
                        {


                            responseType = getType("", data.put.responses, false);
                        }


                    }


                    //imethod = imethod + data.put.operationId + "(" + paramSignature + @"): Promise<" + responseType + ">;" + System.Environment.NewLine;
                    //method = method + data.put.operationId + "(" + paramSignature + @"): Promise<" + responseType + ">" + @"{
                    //var url = this.baseUrl+'" + data.put.tags[0] + "'+'\\\\'+'" + data.put.operationId.Split('_')[1] + @"'; " + System.Environment.NewLine + " return this.PutCall<" + responseType + ">(url, " + paramDefinition + " ,'');" + System.Environment.NewLine + "}";
                    imethod = imethod + data.put.operationId + "(" + paramSignature + @"): Promise<" + responseType + ">;" + System.Environment.NewLine;
                    method = method + data.put.operationId + "(" + paramSignature + @"): Promise<" + responseType + ">" + @"{
                    var url = " + uurrll + @"; " + System.Environment.NewLine + " return this.PutCall<" + responseType + ">(url, " + paramDefinition + ", '');" + System.Environment.NewLine + "}";


                }
                //method += System.Environment.NewLine;

                // for delete call

                if (data.delete != null)
                {

                    var paramSignature = "";
                    var paramDefinition = "";
                    var uurrll = "";
                    var apiUrl = "";

                    if (data.delete.parameters != null)
                    {
                        for (int i = 0; i < data.delete.parameters.Count; i++)
                        {
                            paramSignature += (i == 0 ? "" : ",") + data.delete.parameters[i].name + " : " + getType(data.delete.parameters[i].type, data.delete.parameters[i].schema, false);
                            //paramDefinition += "{" + (i == 0 ? " " : ",") + "'" + data.post.parameters[i].name + "' : " + data.post.parameters[i].name;
                            paramDefinition += data.delete.parameters[i].@in == "body" ? data.delete.parameters[i].name + "," : "";
                        }
                    }

                    paramDefinition = paramDefinition.TrimEnd(',');
                    apiUrl = getDeleteApiUrl(data.delete.parameters);

                    uurrll = "this.baseUrl+'" + data.delete.tags[0] + "\\\\'+'" + data.delete.operationId.Split('_')[1] + "'+" + apiUrl;
                    uurrll = uurrll.TrimEnd('+');
                    var responseType = "";

                    if (data.delete.responses != null)
                    {
                        if (data.delete.responses.Values != null)
                        {
                            responseType = getType("", data.delete.responses.Values.FirstOrDefault().schema, false);
                        }
                        else
                        {
                            responseType = getType("", data.delete.responses, false);
                        }



                    }

                    imethod = imethod + data.delete.operationId + "(" + paramSignature + @"): Promise<" + responseType + ">;" + System.Environment.NewLine;
                    method = method + data.delete.operationId + "(" + paramSignature + @"): Promise<" + responseType + ">" + @"{
                    var url = " + uurrll + @"; " + System.Environment.NewLine + " return this.DeleteCall<" + responseType + ">(url, " + (paramDefinition == "" ? "''" : paramDefinition) + ", '');" + System.Environment.NewLine + "}";


                }

                method += System.Environment.NewLine;
                var fileString = getBasicSyntax("", method, modelName, imethod, baseUrl);
                var dir = location;  // folder location
                Directory.CreateDirectory(dir);
                File.WriteAllText(Path.Combine(dir, "common.service.ts"), fileString);
                File.WriteAllText(Path.Combine(dir, "service.model.ts"), modelName);
            }
        }

        public static string getType(string type, object schema, bool isArr)
        {
            bool isArray = false;

            if (schema == null && type == null && type == "")
            {
                return "any";
            }

            if (schema != null && schema.ToString().IndexOf("No Content") > 0)
            {
                return "void";
            }



            isArray = isArr;

            if (schema != null)
            {

                var listresponse = JsonConvert.DeserializeObject<RootObject1>(schema.ToString());
                if (listresponse != null)
                {

                    type = listresponse.type;
                    isArray = isArray || type == "array";
                    if (listresponse.items != null)
                    {
                        type = listresponse.items.type;
                    }
                }
            }

            if (schema != null && (type == "" || type == null))
            {

                var abc = JsonConvert.DeserializeObject<Dictionary<string, Responses>>(schema.ToString());
                if (abc != null && abc.Count > 0 && abc.FirstOrDefault().Value.schema != null)
                {

                    type = abc.FirstOrDefault().Value.schema.type;
                    isArray = isArray || type == "array";
                }
            }

            if (type == "array")
            {
                if (schema != null && schema.ToString().IndexOf("$ref") > 0)
                {
                    var lalalal = schema.ToString().Split(new string[] { "definitions/" }, StringSplitOptions.None)[1].Trim().Replace("\"", string.Empty).Replace(System.Environment.NewLine, "").Replace("}", "");
                    lalalal = lalalal + (isArray == true ? "[]" : "");
                    return "I" + lalalal;


                }
                else if (schema != null)
                {
                    var ababab = JsonConvert.DeserializeObject<Dictionary<string, Response>>(schema.ToString());
                    if (ababab != null)
                    {
                        schema = ababab.Values.FirstOrDefault().schema;
                    }
                }


            }
            if (schema != null)
            {
                var listresponse = JsonConvert.DeserializeObject<RootObject1>(schema.ToString());

                if (listresponse != null && listresponse.items != null)
                {
                    type = listresponse.items.type;
                    if (type == "array" && listresponse.items != null && listresponse.items.items != null)
                    {
                        type = listresponse.items.items.type;
                        isArray = isArray || type == "array";

                    }

                }
                else if (listresponse != null && listresponse.type != "array")
                {
                    type = listresponse.type;
                    isArray = isArray || type == "array";
                }

            }


            if (schema != null && type != "")
            {
                var model = JsonConvert.DeserializeObject<Schema>(schema.ToString());

                if (model != null)
                {

                    type = type == "array" ? model.type : type;
                    isArray = isArray || type == "array";
                }
            }




            if (type == null || type == "")
            {

                if (schema != null)
                {
                    if (schema.ToString().IndexOf("$ref") > 0)
                    {


                        var newText = schema.ToString().Trim().Replace("\"", string.Empty).Replace(System.Environment.NewLine, "").Replace("}", "");
                        var newType = newText.ToString().Split(new string[] { "}}" }, StringSplitOptions.None)[0].Split(new string[] { "definitions/" }, StringSplitOptions.None)[1];
                        newType = newType + (isArray == true ? "[]" : "");
                        return "I" + newType;
                    }
                }
            }

            isArray = isArray || type == "array";


            switch (type)
            {
                case "integer":
                    {
                        return "number" + (isArray == true ? "[]" : "");
                    }
                case "string":
                    {
                        return "string" + (isArray == true ? "[]" : "");
                    }
                case "boolean":
                    {
                        return "boolean" + (isArray == true ? "[]" : "");
                    }

            }

            return "any" + (isArray == true ? "[]" : "");
        }

        public static string getApiUrl(List<Parameter> parameter)
        {

            var apiUrl = "";

            if (parameter == null)
            {
                return "";
            }

            for (int i = 0; i < parameter.Count; i++)
            {

                var type = parameter[i].@in;

                if (type == "body")
                {
                }
                else if (type == "query")
                {
                    apiUrl += (apiUrl.IndexOf("?") >= 0 ? "+'&" : "'?") + parameter[i].name + "='+" + parameter[i].name;
                }
                else if (type == "path")
                {
                }

            }
            return apiUrl;
        }


        public static string getDeleteApiUrl(List<Parameter> parameter)
        {

            var apiUrl = "";
            if (parameter == null)
            {
                return "";
            }

            for (int i = 0; i < parameter.Count; i++)
            {

                var type = parameter[i].@in;

                if (type == "body")
                {
                }
                else if (type == "query")
                {
                    apiUrl += (apiUrl.IndexOf("?") >= 0 ? "+'&" : "'?") + parameter[i].name + "='+" + parameter[i].name;
                }
                else if (type == "path")
                {
                    apiUrl += "'\\\\" + "'+" + parameter[i].name;

                }

            }
            return apiUrl;
        }

    }

}








