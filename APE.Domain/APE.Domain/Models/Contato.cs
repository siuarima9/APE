using System;

namespace APE.Domain.Models
{
    public class Contato
    {
        public Guid Id { get; private set; }
        public Guid IdCliente { get; private set; }
        public string DddTelefone { get; private set; }
        public string NumeroTelefone { get; private set; }
        public string Email { get; private set; }
        public virtual Cliente Cliente { get; private set; }

        public void VincularCliente(Guid idCliente)
        {
            IdCliente = idCliente;
        }

        public void AlterarEmail(string email)
        {
            Email = email;
        }

        public void AlterarTelefone(string ddd, string numero)
        {
            DddTelefone = ddd;
            NumeroTelefone = numero;
        }


        public class ContatoBuilder
        {
            private Guid? id;
            private Guid idCliente;
            private string dddTelefone;
            private string numeroTelefone;
            private string email;
            private Cliente cliente;

            public ContatoBuilder InformarId(Guid id)
            {
                this.id = id;

                return this;
            }

            public ContatoBuilder InformarIdCliente(Guid idCliente)
            {
                this.idCliente = idCliente;

                return this;
            }

            public ContatoBuilder InformarDddTelefone(string dddTelefone)
            {
                this.dddTelefone = dddTelefone;

                return this;
            }

            public ContatoBuilder InformarNumeroTelefone(string numeroTelefone)
            {
                this.numeroTelefone = numeroTelefone;

                return this;
            }

            public ContatoBuilder InformarEmail(string email)
            {
                this.email = email;

                return this;
            }

            public ContatoBuilder InformarCliente(Cliente cliente)
            {
                this.cliente = cliente;

                return this;
            }

            public Contato Build()
            {
                return new Contato
                {
                    Id = id ?? Guid.NewGuid(),
                    DddTelefone = dddTelefone,
                    NumeroTelefone = numeroTelefone,
                    Email = email,
                    IdCliente = idCliente,
                    Cliente = cliente
                    
                };
            }
        }
    }
}
