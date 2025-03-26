using Domain.customer;
using Domain.seat;

namespace Domain.Test.seat;

public class AvailableSeatTest
{
    [Fact]
    public void reserve_should_reserve_seat_for_customer()
    {
        var seatNumber = new SeatNumber(1);
        var customerId = CustomerId.Generate();
        var sut = createSut(seatNumber);

        var actual = sut.Reserve(customerId);
        
        Assert.Equal(sut.Id, actual.Id);
    }
    
    [Fact]
    public void reserve_should_reserve_seat_with_the_given_number()
    {
        var seatNumber = new SeatNumber(1);
        var customerId = CustomerId.Generate();
        var sut = createSut(seatNumber);

        var actual = sut.Reserve(customerId);
        
        Assert.Equal(sut.Number, actual.Number);
    }
    
    private static AvailableSeat createSut(SeatNumber seatNumber)
    {
        var seatId = SeatId.Generate();
        return AvailableSeat.Create(seatId, seatNumber);
    }
}