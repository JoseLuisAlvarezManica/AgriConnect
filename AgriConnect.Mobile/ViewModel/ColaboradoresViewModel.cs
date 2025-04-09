using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgriConnect.Mobile.ViewModel
{
    public partial class ColaboradoresViewModel:ObservableObject
    {
        public ObservableCollection<ColaboradoresModels> Colaboradores { get; set; } = new();
        [RelayCommand]
        public async Task ListarColaboradores()
        {
            Colaboradores.Clear();
            Colaboradores.Add(new ColaboradoresModels() { Nombre = "Jose Luis", Apellidos = "Manica" });
            Colaboradores.Add(new ColaboradoresModels() { Nombre = "Brad", Apellidos = "Pit" });
            Colaboradores.Add(new ColaboradoresModels() { Nombre = "John", Apellidos = "Doe" });
            Colaboradores.Add(new ColaboradoresModels() { Nombre = "Jane", Apellidos = "Doe" });
            Colaboradores.Add(new ColaboradoresModels() { Nombre = "JoJo", Apellidos = "Doe" });
            Colaboradores.Add(new ColaboradoresModels() { Nombre = "JaJa", Apellidos = "Doe" });
        }
    }
}
