﻿using AutoMapper;
using MongoDB.Driver;
using MongoDbProject.Dtos.OrderDtos;
using MongoDbProject.Entities;
using MongoDbProject.Settings;

namespace MongoDbProject.Services.OrderServices
{
    public class OrderService : IOrderService
    {
        private readonly IMongoCollection<Order> _orderCollection;
        private readonly IMongoCollection<Customer> _customerCollection;
        private readonly IMongoCollection<Product> _productCollection;
        private readonly IMapper _mapper;

        public OrderService(IMapper mapper,IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _orderCollection = database.GetCollection<Order>(_databaseSettings.OrderCollectionName);
            _customerCollection = database.GetCollection<Customer>(_databaseSettings.CustomerCollectionName);
            _productCollection = database.GetCollection<Product>(_databaseSettings.ProductCollectionName);
            _mapper = mapper;
        }

        public async Task CreateOrderAsync(CreateOrderDto createOrderDto)
        {
            var value = _mapper.Map<Order>(createOrderDto);
            await _orderCollection.InsertOneAsync(value);
        }

        public async Task DeleteOrderAsync(string id)
        {
            await _orderCollection.DeleteOneAsync(x =>x.OrderId == id);
        }

        public async Task<List<ResultOrderDto>> GetAllOrderAsync()
        {
            var values = await _orderCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultOrderDto>>(values);
        }

        public async Task<GetByIdOrderDto> GetByIdOrderAsync(string id)
        {
            var value = await _orderCollection.Find(x => x.OrderId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdOrderDto>(value);
        }

        public async Task<List<ResultOrderWithCustomerAndProductDto>> GetOrderWithCustomerAndProductAsync()
        {
            var value = await _orderCollection.Find(x => true).ToListAsync();
            foreach (var item in value)
            {
                item.Customer = await _customerCollection.Find(x => x.CustomerId == item.CustomerId).FirstAsync();
                item.Product = await _productCollection.Find(x => x.ProductId == item.ProductId).FirstAsync();
            }
            return _mapper.Map<List<ResultOrderWithCustomerAndProductDto>>(value);
        }

        public async Task UpdateOrderAsync(UpdateOrderDto updateOrderDto)
        {
            var values =_mapper.Map<Order>(updateOrderDto);
            await _orderCollection.FindOneAndReplaceAsync(x => x.OrderId == updateOrderDto.OrderId, values);
        }
    }
}
