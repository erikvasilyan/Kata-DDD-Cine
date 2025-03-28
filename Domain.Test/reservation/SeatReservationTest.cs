using Domain.customer;
using Domain.exceptions;
using Domain.reservation;
using Domain.seat;
using Domain.session;

namespace Domain.Test.reservation;

public class SeatReservationTest
{
    [Fact]
    public void create_should_create_not_reserved_seat_reservation()
    {
        var sut = CreateSut();
        
        var actual = sut.IsReserved();
        
        Assert.False(actual);
    }
    
    [Fact]
    public void create_should_create_seat_reservation_without_reserved_customer()
    {
        var sut = CreateSut();

        var actual = sut.ReservedBy;
        
        Assert.Null(actual);
    }

    [Fact]
    public void reserve_should_reserve_the_seat_for_the_given_customer()
    {
        var sut = CreateSut();
        var customerId = CustomerId.Generate();
        
        var actual = sut.Reserve(customerId);
        
        Assert.Equal(customerId, actual.ReservedBy);
    }
    
    [Fact]
    public void reserve_should_set_the_seat_as_reserved()
    {
        var sut = CreateSut();
        
        var actual = sut.Reserve(CustomerId.Generate());
        
        Assert.True(actual.IsReserved());
    }
    
    [Fact]
    public void reserve_should_throw_when_seat_is_already_reserved()
    {
        var sut = CreateSut();
        
        sut.Reserve(CustomerId.Generate());
        
        Assert.Throws<SeatIsAlreadyReservedException>(() => sut.Reserve(CustomerId.Generate()));
    }
    
    private static SeatReservation CreateSut() 
        => SeatReservation.Create(SeatReservationId.Generate(), SessionId.Generate(), SeatId.Generate());
    
}