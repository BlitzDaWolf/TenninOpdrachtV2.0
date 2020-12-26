using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Tennis.App.Api
{
    public class GenericAPI
    {

        public const string BASEURL = "https://localhost:5001/api";

        public static async Task<TRead> GetById<TRead>(int id, string Endpoint) where TRead : class
        {
            using (HttpResponseMessage response = await ApiHelper.apiClient.GetAsync($"{BASEURL}/{Endpoint}/{id}"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var res = await response.Content.ReadAsAsync<TRead>();
                    return res;
                }
            }
            return null;
        }

        public static async Task<List<TRead>> GetAll<TRead>(string Endpoint) where TRead : class
        {
            using (HttpResponseMessage response = await ApiHelper.apiClient.GetAsync($"{BASEURL}/{Endpoint}"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var res = await response.Content.ReadAsAsync<List<TRead>>();
                    return res;
                }
            }
            return null;
        }

        public static async Task create<TCreate>(TCreate create, string Endpoint)
        {
            using (HttpResponseMessage response = await ApiHelper.apiClient.PostAsJsonAsync($"{BASEURL}/{Endpoint}", create))
            {
                if (response.IsSuccessStatusCode) { }
            }
        }

        public static async Task update<TUpdate>(TUpdate update, string Endpoint)
        {
            using (HttpResponseMessage response = await ApiHelper.apiClient.PutAsJsonAsync($"{BASEURL}/{Endpoint}", update))
            {
                if (response.IsSuccessStatusCode) { }
            }
        }

        public static async Task Remove<T>(int id, string Endpoint)
        {
            using (HttpResponseMessage response = await ApiHelper.apiClient.DeleteAsync($"{BASEURL}/{Endpoint}/{id}"))
            {
                if (response.IsSuccessStatusCode)
                {

                }
                else
                {

                }
            }
        }

        public static async Task<object> GetAll(string Endpoint, Type type)
        {
            using (HttpResponseMessage response = await ApiHelper.apiClient.GetAsync($"{BASEURL}/{Endpoint}"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var t = typeof(List<>).MakeGenericType(type);
                    var res = await response.Content.ReadAsAsync(t);
                    return res;
                }
            }
            return null;
        }
    }

    public interface IGenericGetAPI<TRead>
    {
        public Task<TRead> GetById(int id);
        public Task<List<TRead>> GetAll();
    }

    public interface IGenericCreateAPI<TCreate>
    {
        public Task create(TCreate create);
    }

    public interface IGenericUpdateAPI<TUpdate>
    {
        public Task update(TUpdate update);
    }
}
