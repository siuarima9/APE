using System;

namespace APE.Domain.Models
{
    public class Cliente
    {
        public Guid Id { get; private set; }
        public int IdGenero { get; private set; }
        public string Nome { get; private set; }
        public string Sobrenome { get; private set; }
        public string Cpf { get; private set; }

        public virtual Contato Contato { get; private set; }

        public class ClienteBuilder
        {
            private Guid id;
            private int IdGenero;
            private string nome;
            private string sobrenome;
            private string cpf;
            private Contato contato;

            public ClienteBuilder InformarId(Guid id)
            {
                this.id = id;

                return this;
            }

            public ClienteBuilder InformarGenero(int idGenero)
            {
                IdGenero = idGenero;

                return this;
            }

            public ClienteBuilder InformarContato(Contato contato)
            {
                this.contato = contato;

                return this;
            }

            public ClienteBuilder InformarNomeCompleto(string nome, string sobrenome)
            {
                this.nome = nome;
                this.sobrenome = sobrenome;

                return this;
            }

            public ClienteBuilder InformarCpf(string cpf)
            {
                this.cpf = cpf;

                return this;
            }

            public Cliente Build()
            {
                return new Cliente
                {
                    Id = id,
                    IdGenero = IdGenero,
                    Nome = nome,
                    Sobrenome = sobrenome,
                    Cpf = cpf,
                    Contato = contato
                };
            }
        }
    }
}
