using Domain.common;

namespace Domain.customer;

public class Customer : Entity<CustomerId>
{ 
    public CustomerName Name { get; init; }
    public DNI DNI { get; init; }

    private Customer(CustomerId id, CustomerName name, DNI dni) : base(id)
    {
        Name = name;
        DNI = dni;
    } 
    
    public static Customer Create(CustomerId id, CustomerName name, DNI dni) 
        => new Customer(id, name, dni);
}