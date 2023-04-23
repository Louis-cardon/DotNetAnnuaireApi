using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DotNetAnnuaireApp.Services;

public class SalarieService
{

    const string BASE_SEARCH_URL = "https://127.0.0.1:7004/api/";
    HttpClient client;


    public SalarieService() 
    {
        this.client = new();
        client.BaseAddress = new Uri("https://localhost:7004/api/");
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    }

    public async Task<ObservableCollection<Salarie>> GetAllSalarieAsync()
    {
        //var url = BASE_SEARCH_URL + "Salarie";

        var response = await client.GetStringAsync("Salarie");
        ObservableCollection<Salarie> result = new();

        if (response != null) 
        {
            result = new ObservableCollection<Salarie>(JsonConvert.DeserializeObject<List<Salarie>>(response));
        }

        return result;
    }

}
