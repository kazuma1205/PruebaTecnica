using System.ComponentModel.DataAnnotations;
using System.Data;

namespace PruebaTecnica.Components.Pages.ViewModels
{
    public class ViewLogin
    {
        [Required(AllowEmptyStrings = false, ErrorMessage ="ingrese bien el usuario")]
        public string? LoginName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "ingrese bien la contraseña")]
        public string? Password { get; set; }

    }
}
