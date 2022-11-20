using AquaApp.Models;
using AquaApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace AquaApp.ViewModels
{
    public class RegistroViewModel : BaseViewModel
    {
        public ApiAccess apiAccess { get; set; }

        public RegistroViewModel()
        {
            apiAccess = new ApiAccess();
            Title = "Registro de ocorrências";
        }

        public List<Registro> RetornaRegistros()
        {
            List<Registro> registros = apiAccess.ConsultarRegistro();
            return registros;
        }
    }
}