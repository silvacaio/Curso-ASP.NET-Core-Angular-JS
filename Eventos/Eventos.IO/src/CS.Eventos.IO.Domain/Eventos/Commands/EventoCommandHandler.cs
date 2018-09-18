using CS.Eventos.IO.Domain.CommandHandlers;
using CS.Eventos.IO.Domain.Core.Bus;
using CS.Eventos.IO.Domain.Core.Events;
using CS.Eventos.IO.Domain.Core.Notifications;
using CS.Eventos.IO.Domain.Eventos.Commands;
using CS.Eventos.IO.Domain.Eventos.Events;
using CS.Eventos.IO.Domain.Eventos.Repository;
using CS.Eventos.IO.Domain.Interfaces;
using System;
using static CS.Eventos.IO.Domain.Eventos.Evento;

namespace CS.Eventos.IO.Domain.Eventos.Commands
{
    public class EventoCommandHandler : CommandHandler,
        IHandler<RegistrarEventoCommand>,
        IHandler<RemoverEventoCommand>,
        IHandler<AtualizarEventoCommand>,
        IHandler<IncluirEnderecoEventoCommand>,
        IHandler<AtualizarEnderecoEventoCommand>
    {
        private readonly IEventoRepository _eventoRepository;
        private readonly IBus _bus;

        public EventoCommandHandler(IEventoRepository eventoRepository,
                                    IUnitOfWork uow,
                                    IBus bus,
                                    IDomainNotificationHandler<DomainNotification> _notification) : base(uow, bus, _notification)
        {
            _eventoRepository = eventoRepository;
            _bus = bus;
        }

        public void Handle(RegistrarEventoCommand message)
        {
            var endereco = new Endereco(message.Endereco.Id, message.Endereco.Logradouro, message.Endereco.Numero, message.Endereco.Complemento, message.Endereco.Bairro, message.Endereco.CEP, message.Endereco.Cidade, message.Endereco.Estado, message.Endereco.EventoId);
            var evento = EventoFactory.NovoEventoCompleto(message.Id, //TODO Precisa???
                                                        message.Nome,
                                                        message.DataInicio,
                                                        message.DateFinal,
                                                        message.Gratuito,
                                                        message.Valor,
                                                        message.Online,
                                                        message.NomeEmpresa,
                                                        message.OrganizadorId,
                                                        endereco,
                                                        message.CategoriaId);

            if (!EventoValido(evento)) return;

            // TODO: 
            //Validações de negocio!
            //valida se já existe um evento com o nome igual, mesma data...
            //Organizador pode registrar o evento?

            //Persistencia
            _eventoRepository.Adicionar(evento);

            if (Commit())
            {
                //Notificar processo concluido               
                _bus.RaiseEvent(new EventoRegistradoEvent(
                                        evento.Id,
                                        evento.Nome,
                                        evento.DataInicio,
                                        evento.DateFinal,
                                        evento.Gratuito,
                                        evento.Valor,
                                        evento.Online,
                                        evento.NomeEmpresa));
            }
        }

        public void Handle(RemoverEventoCommand message)
        {
            if (!EventoExistente(message.Id, message.MessageType)) return;
            _eventoRepository.Remover(message.Id);

            if (Commit())
                _bus.RaiseEvent(new EventoRemovidoEvent(message.Id));

        }

        public void Handle(AtualizarEventoCommand message)
        {
            //TODO: Obter duas vezes o evento????????
            if (!EventoExistente(message.Id, message.MessageType)) return;

            var eventoAtual = _eventoRepository.ObterPorId(message.Id);

            //TODO: validar se o evento pertence a pessoa que está  editando

            var evento = EventoFactory.NovoEventoCompleto(message.Id,
                                                          message.Nome,
                                                          message.DataInicio,
                                                          message.DateFinal,
                                                          message.Gratuito,
                                                          message.Valor,
                                                          message.Online,
                                                          message.NomeEmpresa,
                                                          message.OrganizadorId,
                                                          eventoAtual.Endereco,
                                                          message.CategoriaId);

            //TODO: pq não está na entity do evento? Nãi é ele a responsavel por saber o que é obrigatorio por ela ou não?
            if (!evento.Online && evento.Endereco == null)
            {
                _bus.RaiseEvent(new DomainNotification(message.MessageType, "Não é possível atualizar um evento sem informar o endereço"));
                return;
            }

            if (!EventoValido(evento)) return;

            _eventoRepository.Atualizar(evento);

            if (Commit())
            {
                //Notificar processo concluido                
                _bus.RaiseEvent(new EventoAtualizadoEvent(
                                        evento.Id,
                                        evento.Nome,
                                        evento.DescricaoCurta,
                                        evento.DescricaoLonga,
                                        evento.DataInicio,
                                        evento.DateFinal,
                                        evento.Gratuito,
                                        evento.Valor,
                                        evento.Online,
                                        evento.NomeEmpresa));
            }
        }

        private bool EventoValido(Evento evento)
        {
            if (evento.EhValido()) return true;

            NotificarValidacoesErro(evento.ValidationResult);
            return false;
        }

        private bool EventoExistente(Guid id, string messageType)
        {
            var evento = _eventoRepository.ObterPorId(id);
            if (evento != null) return true;

            _bus.RaiseEvent(new DomainNotification(messageType, "Evento não encontrado"));
            return false;
        }

        public void Handle(IncluirEnderecoEventoCommand message)
        {
            var endereco = new Endereco(message.Id, message.Logradouro, message.Numero, message.Complemento, message.Bairro, message.CEP, message.Cidade, message.Estado, message.EventoId.Value);
            if (!endereco.EhValido())
            {
                NotificarValidacoesErro(endereco.ValidationResult);
            }

            _eventoRepository.AdicionarEndereco(endereco);

            if (Commit())
            {
                _bus.RaiseEvent(new EnderecoEventoAdicionadoEvent(message.Id, message.Logradouro, message.Numero, message.Complemento, message.Bairro, message.CEP, message.Cidade, message.Estado, message.EventoId.Value));
            }
        }

        public void Handle(AtualizarEnderecoEventoCommand message)
        {
            var endereco = new Endereco(message.Id, message.Logradouro, message.Numero, message.Complemento, message.Bairro, message.CEP, message.Cidade, message.Estado, message.EventoId.Value);
            if (!endereco.EhValido())
            {
                NotificarValidacoesErro(endereco.ValidationResult);
            }

            _eventoRepository.AtualizarEndereco(endereco);

            if (Commit())
            {
                _bus.RaiseEvent(new EnderecoEventoAtualizadoEvent(message.Id, message.Logradouro, message.Numero, message.Complemento, message.Bairro, message.CEP, message.Cidade, message.Estado, message.EventoId.Value));
            }
        }
    }
}
