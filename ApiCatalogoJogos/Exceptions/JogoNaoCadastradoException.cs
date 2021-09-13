using System;

namespace ApiCatalogoJogos.Exceptions {
    public class JogoNaoCadastradoException : Exception {
        public JogoNaoCadastradoException()
            : base("Este não esta cadastrado") {
        }
    }
}
