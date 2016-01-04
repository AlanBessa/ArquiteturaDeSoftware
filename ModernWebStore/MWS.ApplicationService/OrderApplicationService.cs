using MWS.Domain.Commands.OrderCommands;
using MWS.Domain.Entidades;
using MWS.Domain.Repositories;
using MWS.Domain.Services;
using MWS.Infra.Persistence;
using System;
using System.Collections.Generic;

namespace MWS.ApplicationService
{
    public class OrderApplicationService : ApplicationService, IOrderApplicationService
    {
        private IOrderRepository _orderRepository;
        private IUserRepository _userRepository;
        private IProductRepository _productRepository;

        public OrderApplicationService(
            IOrderRepository orderRepository,
            IUserRepository userRepository,
            IProductRepository productRepository,
            IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _orderRepository = orderRepository;
            _userRepository = userRepository;
            _productRepository = productRepository;
        }

        public List<Order> Get(string email, int skip, int take)
        {
            return _orderRepository.Get(email, skip, take);
        }

        public List<Order> GetCreated(string email)
        {
            return _orderRepository.GetCreated(email);
        }

        public List<Order> GetPaid(string email)
        {
            return _orderRepository.GetPaid(email);
        }

        public List<Order> GetDelivered(string email)
        {
            return _orderRepository.GetDelivered(email);
        }

        public List<Order> GetCanceled(string email)
        {
            return _orderRepository.GetCanceled(email);
        }

        public Order GetDetails(int id, string email)
        {
            return _orderRepository.GetDetails(id, email);
        }

        public Order Create(CreateOrderCommand command, string email)
        {
            var user = _userRepository.GetByEmail(email);
            var orderItems = new List<OrderItem>();
            foreach (var item in command.OrderItems)
            {
                var orderItem = new OrderItem();
                var product = _productRepository.Get(item.Product);

                orderItem.AddProduct(product, item.Quantity, item.Price);
                orderItems.Add(orderItem);
            }

            var order = new Order(orderItems, user.Id);
            order.Place();
            _orderRepository.Create(order);

            if (Commit())
                return order;

            return null;
        }

        public void Pay(int id, string email)
        {
            throw new NotImplementedException();
        }

        public void Delivery(int id, string email)
        {
            throw new NotImplementedException();
        }

        public void Cancel(int id, string email)
        {
            var order = _orderRepository.GetHeader(id, email);
            order.Cancel();

            _orderRepository.Update(order);

            Commit();
        }
    }
}