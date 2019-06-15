using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace be.client.Source
{
    public class ServiceBase
    {
        public String BaseUrl { get; set; }
        public Controller Controller { get; set; }

        protected void Invoke(String resource, String method, Object source)
        {
            try
            {
                Controller.ViewBag.ShowMessageError = false;
                var request = WebRequest.Create(BaseUrl + resource) as HttpWebRequest;
                request.Method = method;
                request.ContentType = "application/json";
                if (source != null)
                {
                    JsonSerializerSettings microsoftDateFormatSettings = new JsonSerializerSettings
                    {
                        DateFormatHandling = DateFormatHandling.MicrosoftDateFormat
                    };
                    using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                    {
                        string json = JsonConvert.SerializeObject(source, microsoftDateFormatSettings);
                        streamWriter.Write(json);
                    }
                }
                else
                {
                    request.ContentLength = 0;
                }

                request.GetResponse();
            }
            catch (WebException err)
            {
                var response = new StreamReader(err.Response.GetResponseStream()).ReadToEnd();
                var responseError = JsonConvert.DeserializeObject<Error>(response);
                SetErrorMessage(responseError);
                throw new WebException((responseError.Mensagem == null && responseError.ExceptionMessage == null ? "Não foi possivel atender a sua solicitação" : (responseError.Mensagem == null ? responseError.ExceptionMessage : responseError.Mensagem)));
            }
        }

        public T InvokeData<T>(String resource, String method, Object source)
        {
            try
            {
                Controller.ViewBag.ShowMessageError = false;
                var request = WebRequest.Create(BaseUrl + resource) as HttpWebRequest;
                request.Method = method;
                request.ContentType = "application/json";
                if (source != null)
                {
                    JsonSerializerSettings microsoftDateFormatSettings = new JsonSerializerSettings
                    {
                        DateFormatHandling = DateFormatHandling.MicrosoftDateFormat
                    };
                    using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                    {
                        string json = JsonConvert.SerializeObject(source, microsoftDateFormatSettings);
                        streamWriter.Write(json);
                    }

                }
                else
                {
                    request.ContentLength = 0;
                }
                var info = new StreamReader(request.GetResponse().GetResponseStream()).ReadToEnd();
                return JsonConvert.DeserializeObject<T>(info);

            }
            catch (WebException err)
            {
                var response = new StreamReader(err.Response.GetResponseStream()).ReadToEnd();
                var responseError = JsonConvert.DeserializeObject<Error>(response);
                SetErrorMessage(responseError);
                throw new WebException((responseError.Mensagem == null && responseError.ExceptionMessage == null ? "Não foi possivel atender a sua solicitação" : (responseError.Mensagem == null ? responseError.ExceptionMessage : responseError.Mensagem)));
            }
        }
        protected T Get<T>(String resource)
        {
            try
            {
                var request = WebRequest.Create(BaseUrl + resource) as HttpWebRequest;
                using (var response = request.GetResponse())
                {
                    var jsonString = new StreamReader(response.GetResponseStream()).ReadToEnd();
                    var json = JsonConvert.DeserializeObject<T>(jsonString);
                    return json;
                }
            }
            catch (WebException err)
            {
                var response = new StreamReader(err.Response.GetResponseStream()).ReadToEnd();
                var responseError = JsonConvert.DeserializeObject<Error>(response);
                SetErrorMessage(responseError);
                return (T)Activator.CreateInstance(typeof(T));
            }
        }

        protected Byte[] GetByteArray(String resource)
        {
            try
            {
                var request = WebRequest.Create(BaseUrl + resource) as HttpWebRequest;
                Byte[] byteArray;

                using (var response = request.GetResponse())
                {
                    byteArray = Conversor.StreamToByteArray(response.GetResponseStream());
                }

                return byteArray;
            }
            catch (WebException err)
            {
                var response = new StreamReader(err.Response.GetResponseStream()).ReadToEnd();
                var responseError = JsonConvert.DeserializeObject<Error>(response);
                SetErrorMessage(responseError);
                return null;
            }
        }

        public void SetErrorMessage(Error error)
        {
            Controller.ViewBag.ShowMessageError = true;
            Controller.ViewBag.ErrorMessage = (error.Mensagem == null ? error.ExceptionMessage : error.Mensagem);
        }
    }

}


public class Error
{
    public String Mensagem { get; set; }
    public String ExceptionMessage { get; set; }

    public Error(String Mensagem, String ExceptionMessage)
    {
        this.Mensagem = Mensagem;
        this.ExceptionMessage = ExceptionMessage;
    }
}

public static class Conversor
{
    public static byte[] StreamToByteArray(Stream input)
    {
        var output = new MemoryStream();

        byte[] buffer = new byte[16 * 1024];
        int read;
        while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
        {
            output.Write(buffer, 0, read);
        }

        return output.ToArray();
    }
}