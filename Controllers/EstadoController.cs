using ConFinServer.Model;
using Microsoft.AspNetCore.Mvc;

namespace ConFinServer.Controllers
{
	[Route("api/controller")]
	[ApiController]
	public class EstadoController : ControllerBase
	{
		private static List<Estado> lista = new List<Estado>();
		private static Estado estado = new Estado();

		[HttpGet]
		public string Estado()
		{
			return estado.Sigla;
		}

		[HttpGet]
		[Route("Lista")]
		public List<Estado> EstadoLista()
		{
			ArgumentNullException.ThrowIfNull(lista);
			return lista;
		}

		[HttpPost]
		public string PostEstado(Estado estado)
		{
			lista.Add(estado);
			return "Estado cadastrado com sucesso!";
		}

		[HttpPut]
		public string PutEstado(Estado estado)
		{
			var EstadoExiste = lista.Where(l => l.Sigla == estado.Sigla).FirstOrDefault();
			if (EstadoExiste != null)
			{
				EstadoExiste.Nome = estado.Nome;
				return "Estado alterado com sucesso!";
			}
            return "Estado não encontrado!";
		}

		[HttpDelete]
		public string DeleteEstado(Estado estado)
		{
            var EstadoExiste = lista.Where(l => l.Sigla == estado.Sigla).FirstOrDefault();
            if (EstadoExiste != null)
            {
				lista.Remove(EstadoExiste);
                return "Estado excluído com sucesso!";
            }
            return "Estado não encontrado!";
        }

		[HttpDelete("ExcluirByQuery")]
		public string DeleteEstadoByQuery([FromQuery] string sigla)
        {
            var EstadoExiste = lista.Where(l => l.Sigla == sigla).FirstOrDefault();
            if (EstadoExiste != null)
            {
                lista.Remove(EstadoExiste);
                return "Estado excluído com sucesso!";
            }
            return "Estado não encontrado!";
        }

        [HttpDelete("ExcluirByHeader")]
        public string DeleteEstadoByHeader([FromHeader] string sigla)
        {
            var EstadoExiste = lista.Where(l => l.Sigla == sigla).FirstOrDefault();
            if (EstadoExiste != null)
            {
                lista.Remove(EstadoExiste);
                return "Estado excluído com sucesso!";
            }
            return "Estado não encontrado!";
        }

        [HttpDelete("{sigla}")]
        public string DeleteEstadoByRoute([FromRoute] string sigla)
        {
            var EstadoExiste = lista.Where(l => l.Sigla == sigla).FirstOrDefault();
            if (EstadoExiste != null)
            {
                lista.Remove(EstadoExiste);
                return "Estado excluído com sucesso!";
            }
            return "Estado não encontrado!";
        }
    }
}
