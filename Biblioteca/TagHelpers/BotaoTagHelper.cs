using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Biblioteca.TagHelpers
{
    //<botao></botao>
    public class BotaoTagHelper : TagHelper
    {
        public string? Texto { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "button";
            output.Attributes.SetAttribute("class", "btn btn-primary");
            output.Content.SetContent(
                string.IsNullOrEmpty(Texto) ? "Cadastrar" : Texto);
        }
    }
}
