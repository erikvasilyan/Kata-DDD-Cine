using Domain.customer;

namespace Domain.repositories;

public interface CustomerRepository : BaseRepository<Customer, CustomerId>;