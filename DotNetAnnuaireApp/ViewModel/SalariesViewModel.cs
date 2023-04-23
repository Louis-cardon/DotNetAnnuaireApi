using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetAnnuaireApp.ViewModel;

public class SalariesViewModel : BaseViewModel
{
    SalarieService salarieService;

    public ObservableCollection<Salarie> Salaries { get; set; } = new();

    public SalariesViewModel(SalarieService salarieService) 
    {
        Title = "Salariés";
        this.salarieService = salarieService;
    }

    [RelayCommand]
    async Task GetSalariesAsync()
    {
        if(IsBusy) return;

        try
        {
            IsBusy = true;

            var salaries = await salarieService.GetAllSalarieAsync();
            Salaries.Clear();
            foreach (var salarie in salaries)
                Salaries.Add(salarie);

        }
        catch(Exception ex) 
        {
            Debug.WriteLine(ex);
            await Shell.Current.DisplayAlert("Erreur", "Impossible de récupérer la liste des produits", "OK");
        }
        finally { IsBusy = false; }
    }

}
