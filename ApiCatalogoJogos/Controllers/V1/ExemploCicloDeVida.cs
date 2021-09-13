using System;

namespace ApiCatalogoJogos.Controllers.V1 {
    public class ExemploCicloDeVida : IExemploSingleton, IExemploScoped, IExemploTransient {
        private readonly Guid _guid;

        public ExemploCicloDeVida() {
            _guid = Guid.NewGuid();
        }

        public Guid Id => _guid;
    }
}
