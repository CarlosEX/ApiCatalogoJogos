using ApiCatalogoJogos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogoJogos.Repositories {
    public class JogoRepository : IJogoRepository {
        
        private static Dictionary<Guid, Jogo> jogos = new Dictionary<Guid, Jogo>() {
            {Guid.Parse("119362aa-d46e-4b5b-aad4-88488d46033e"), new Jogo{Id = Guid.Parse("119362aa-d46e-4b5b-aad4-88488d46033e"), Nome = "Fifa 21", Produtora = "EA", Preco = 200}},
            {Guid.Parse("f705dbe5-ab63-49c2-bd34-32ec72018690"), new Jogo{Id = Guid.Parse("f705dbe5-ab63-49c2-bd34-32ec72018690"), Nome = "Fifa 19", Produtora = "EA", Preco = 180}},
            {Guid.Parse("188b28c7-2999-49c3-a99e-446d1c15ae2e"), new Jogo{Id = Guid.Parse("188b28c7-2999-49c3-a99e-446d1c15ae2e"), Nome = "Fifa 18", Produtora = "EA", Preco = 170}},
            {Guid.Parse("827e3c81-d3d0-447e-a008-ea849922be74"), new Jogo{Id = Guid.Parse("827e3c81-d3d0-447e-a008-ea849922be74"), Nome = "Fifa 17", Produtora = "EA", Preco = 190}},
            {Guid.Parse("13803536-93df-4513-94cb-cd84f0f9f69d"), new Jogo{Id = Guid.Parse("13803536-93df-4513-94cb-cd84f0f9f69d"), Nome = "Mortal Combate", Produtora = "Capcon", Preco = 230}},
            {Guid.Parse("50c56d0f-22b8-4fa2-81b2-4b87e2836f72"), new Jogo{Id = Guid.Parse("50c56d0f-22b8-4fa2-81b2-4b87e2836f72"), Nome = "Super Mário", Produtora = "Disney", Preco = 110}}            
        };

        public Task<List<Jogo>> Obter(int pagina, int quantidade) {
            return Task.FromResult(jogos.Values.Skip((pagina - 1) * quantidade).Take(quantidade).ToList());
        }

        public Task<Jogo> Obter(Guid id) {
            
            if (!jogos.ContainsKey(id))
                return null;

            return Task.FromResult(jogos[id]);
        }

        public Task<List<Jogo>> Obter(string nome, string produtora) {
            return Task.FromResult(jogos.Values.Where(
                jogo => jogo.Nome.Equals(nome) && 
                jogo.Produtora.Equals(produtora)).ToList());
        }
        public Task<List<Jogo>> ObterSemLambda(string nome, string produtora) {

            var retorno = new List<Jogo>();

            foreach(var jogo in jogos.Values) {
                if (jogo.Nome.Equals(nome) && jogo.Produtora.Equals(produtora))
                    retorno.Add(jogo);
            }

            return Task.FromResult(retorno);
        }

        public Task Inserir(Jogo jogo) {
            jogos.Add(jogo.Id, jogo);
            return Task.CompletedTask;
        }

        public Task Atualizar(Jogo jogo) {
            jogos[jogo.Id] = jogo;
            return Task.CompletedTask;
        }

        public Task Remover(Guid id) {
            jogos.Remove(id);
            return Task.CompletedTask;
        }
        public void Dispose() {

        }
    }
}
