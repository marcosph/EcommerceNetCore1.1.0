﻿using System;
using Gzt.Domain.Commands;
using Gzt.Domain.Core.Bus;
using Gzt.Domain.Core.Events;
using Gzt.Domain.Core.Notifications;
using Gzt.Domain.Events;
using Gzt.Domain.Interfaces;
using Gzt.Domain.Models;

namespace Gzt.Domain.CommandHandlers
{
    public class CustomerCommandHandler : CommandHandler,
        IHandler<RegisterNewCustomerCommand>,
        IHandler<UpdateCustomerCommand>,
        IHandler<RemoveCustomerCommand>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IBus Bus;

        public CustomerCommandHandler(ICustomerRepository customerRepository, 
                                      IUnitOfWork uow, 
                                      IBus bus,
                                      IDomainNotificationHandler<DomainNotification> notifications) :base(uow, bus, notifications)
        {
            _customerRepository = customerRepository;
            Bus = bus;
        }

        public void Handle(RegisterNewCustomerCommand message)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return;
            }

            var customer = new Customer(Guid.NewGuid(), message.Name, message.Email, message.BirthDate);

            if (_customerRepository.GetByEmail(customer.Email) != null)
            {
                Bus.RaiseEvent(new DomainNotification(message.MessageType, "The customer e-mail has already been taken."));
                return;
            }
            
            _customerRepository.Add(customer);

            if (Commit())
            {
                Bus.RaiseEvent(new CustomerRegisteredEvent(customer.Id, customer.Name, customer.Email, customer.BirthDate));
            }
        }

        public void Handle(UpdateCustomerCommand message)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return;
            }

            var customer = new Customer(message.Id, message.Name, message.Email, message.BirthDate);
            var existingCustomer = _customerRepository.GetByEmail(customer.Email);

            if (existingCustomer != null)
            {
                if (!existingCustomer.Equals(customer))
                {
                    Bus.RaiseEvent(new DomainNotification(message.MessageType,"The customer e-mail has already been taken."));
                    return;
                }
            }

            _customerRepository.Update(customer);

            if (Commit())
            {
                Bus.RaiseEvent(new CustomerUpdatedEvent(customer.Id, customer.Name, customer.Email, customer.BirthDate));
            }
        }

        public void Handle(RemoveCustomerCommand message)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return;
            }

            _customerRepository.Remove(message.Id);

            if (Commit())
            {
                Bus.RaiseEvent(new CustomerRemovedEvent(message.Id));
            }
        }

        public void Dispose()
        {
            _customerRepository.Dispose();
        }
    }
}