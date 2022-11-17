namespace VendaImoveis.Application.Options
{
    public class FileSettings
    {
        public string ImobiliariaImgDirectory { get; set; } = "img\\imobiliaria";
        public string PropriedadeImgDirectory { get; set; } = "img\\propriedade";

        public string[] DefaultFileTypes { get; set; } = new string[0];

        public string DefaultImobiliariaImgPath { get; set; } = "";
        public string DefaultPropriedadeImgPath { get; set; } = "";
    }
}
