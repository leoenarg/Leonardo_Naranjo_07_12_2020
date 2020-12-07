using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TestBertoni.Models;
using Newtonsoft.Json;

namespace TestBertoni.Helper
{
    public class HttpClientHelper
    {
        static HttpClient client;

        public HttpClientHelper()
        {
            client = new HttpClient();
        }

        public async Task<List<Album>> GetAlbumsAsync()
        {
            List<Album> albumns = null;
            HttpResponseMessage response = await client.GetAsync("https://jsonplaceholder.typicode.com/albums");
            if (response.IsSuccessStatusCode)
            {
                albumns = JsonConvert.DeserializeObject<List<Album>>(await response.Content.ReadAsStringAsync());
            }
            return albumns;
        }

        public async Task<List<Photo>> GetPhotosAsync(int albumId)
        {
            List<Photo> photos = null;
            HttpResponseMessage response = await client.GetAsync(string.Format("https://jsonplaceholder.typicode.com/photos?albumId={0}",albumId));
            if (response.IsSuccessStatusCode)
            {
                photos = JsonConvert.DeserializeObject<List<Photo>>(await response.Content.ReadAsStringAsync());
            }
            return photos;
        }

        public async Task<List<Comment>> GetCommentsAsync(int postId)
        {
            List<Comment> comments = null;
            HttpResponseMessage response = await client.GetAsync(string.Format("https://jsonplaceholder.typicode.com/comments?postId={0}", postId));
            if (response.IsSuccessStatusCode)
            {
                comments = JsonConvert.DeserializeObject<List<Comment>>(await response.Content.ReadAsStringAsync());
            }
            return comments;
        }
    }
}
