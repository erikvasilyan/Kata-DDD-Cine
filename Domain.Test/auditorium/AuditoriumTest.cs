using Domain.auditorium;
using Domain.customer;
using Domain.exceptions;
using Domain.seat;

namespace Domain.Test.auditorium;

public class AuditoriumTest
{
    [Fact]
    public void reserve_seat_should_reserve_the_seat_for_the_given_customer()
    {
        var sut = createSut(3);
        var customerId = CustomerId.Generate();
        var seatNumber = new SeatNumber(1);

        var actual = sut.ReserveSeat(customerId, seatNumber);
        
        Assert.Equal(customerId, actual.AssignedTo);
    }
    
    [Fact]
    public void reserve_seat_should_reserve_the_seat_with_the_given_number()
    {
        var sut = createSut(3);
        var customerId = CustomerId.Generate();
        var seatNumber = new SeatNumber(1);

        var actual = sut.ReserveSeat(customerId, seatNumber);
        
        Assert.Equal(seatNumber, actual.Number);
    }
    
    [Fact]
    public void reserve_seat_should_throw_when_seat_is_busy()
    {
        var sut = createSut(3);
        var customerId = CustomerId.Generate();
        var seatNumber = new SeatNumber(1);
        sut.ReserveSeat(customerId, seatNumber);

        Assert.Throws<SeatIsBusyException>(() => sut.ReserveSeat(customerId, seatNumber));
    }
    
    private static Auditorium createSut(int seatsCount)
    {
        var auditoriumId = AuditoriumId.Generate();
        return Auditorium.Create(auditoriumId, seatsCount);
    }
}