using HtmlAgilityPack;
using scrap.Model;
using ScrapySharp.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scrap.Service
{
    internal class ServiceScrap<T> where T : IModelo, new()
    {
        public string urlbase_;
        public ServiceScrap(string urlbase)
        {
            urlbase_ = urlbase;
        }
        public List<T> Servicio()
        {
            String url = $"https://www.pc-kombo.com/us/components/{urlbase_}";
            var httpClient = new HttpClient();
            var html = httpClient.GetStringAsync(url).Result;
            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);

            var titulos = htmlDocument.DocumentNode.CssSelect("h5.name");
            var precios = htmlDocument.DocumentNode.CssSelect("span.price");
            var descripciones = htmlDocument.DocumentNode.CssSelect("div.subtitle");
            var imagenes = htmlDocument.DocumentNode.CssSelect("div.subtitle");

            var componentes = new List<T>();

            for (int i = 0; i < titulos.Count(); i++)
            {
                var componente = new T
                {
                    Nombre = titulos.ElementAt(i).InnerText,
                    Precio = precios.ElementAt(i).InnerText.Replace("USD", null).Replace(" ", null),
                    Descripcion = descripciones.ElementAt(i).InnerText.Replace(" ", "").Replace("\n", " ").Replace("\t", "").Trim(),
                    
                };

                componentes.Add(componente);
            }

            return componentes;
        }
    }
}
