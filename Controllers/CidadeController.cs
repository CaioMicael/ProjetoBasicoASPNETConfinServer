using ConFinServer.Model;
using Microsoft.AspNetCore.Mvc;

namespace ConFinServer.Controllers
{
    [Route("api/controllerCidade")]
    [ApiController]
    public class CidadeController : ControllerBase
    {
        private static CidadeModel ModelCidade = new CidadeModel();
        private static List<CidadeModel> listaCidade = new List<CidadeModel>();

        [HttpGet]
        public List<CidadeModel> Listar()
        {
            return listaCidade;
        }

        [HttpPost]
        public string incluirCidade(CidadeModel ModelCidade )
        {
            listaCidade.Add(ModelCidade);
            return "Cidade cadastrada com sucesso.";
        }

        [HttpPut]
        public string alterarCidade(CidadeModel ModelCidade )
        {
            var CidadeExiste = listaCidade.Where(lc => lc.Codigo == ModelCidade.Codigo).FirstOrDefault();
            if (CidadeExiste != null)
            {
                CidadeExiste.Nome   = ModelCidade.Nome;
                CidadeExiste.Estado = ModelCidade.Estado;
                return "A cidade de código " + CidadeExiste.Codigo + " Foi alterada com sucesso.";
            }
            return "Não encontramos a cidade código para alterar.";
        }

        [HttpDelete]
        public string excluirCidade(CidadeModel ModelCidade)
        {
            var CidadeExiste = listaCidade.Where(lc => lc.Codigo == ModelCidade.Codigo).FirstOrDefault();
            if (CidadeExiste != null)
            {
                listaCidade.Remove(CidadeExiste);
                return "A cidade de código " + CidadeExiste.Codigo + " foi excluída com sucesso.";
            }
            return "Não encontramos a cidade código " + CidadeExiste.Codigo + " para excluir.";
        }
    }
}
