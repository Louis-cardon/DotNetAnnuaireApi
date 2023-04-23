using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetAnnuaireApp.Services;

public class SalarieService
{

    const string BASE_SEARCH_URL = "https://localhost:7004/api/";
    HttpClient client;


    public SalarieService(HttpClient httpClient) 
    {
        this.client = httpClient;
    }

    public async Task<ObservableCollection<Salarie>> GetAllSalarieAsync()
    {
        var url = BASE_SEARCH_URL + "Salarie";

        var response = await client.GetStringAsync(url);

        ObservableCollection<Salarie> result = new();

        if (response != null) 
        {
            result = new ObservableCollection<Salarie>(JsonConvert.DeserializeObject<List<Salarie>>(response));
        }

        return result;
    }

}
