namespace SaluFitApp.Web.Models
{
    public class ModalGenericoModel
    {
        public string IdModal { get; set; } = "modalGenerico";
        public string Titulo { get; set; }
        public string Accion { get; set; }
        public string InputLabel { get; set; }
        public string InputName { get; set; }
        public string InputType { get; set; } = "text";
        public bool TextArea { get; set; } = false;
        public bool Buscador { get; set; } = false;
        public string? TextAreaName { get; set; }
        public string? TextAreaPlaceholder { get; set; }
        public string? Bordes { get; set; }
        public string? Bordes2 { get; set; }
        public Dictionary<string, string>? HiddenFields { get; set; } = new();
    }
}
