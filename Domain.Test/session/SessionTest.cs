using Domain.common;
using Domain.customer;
using Domain.exceptions;
using Domain.movie;
using Domain.sala;
using Domain.seat;
using Domain.session;

namespace Domain.Test.session;

public class SessionTest
{
    [Fact]
    public void reserve_seat_should_reserve_the_seat_for_the_given_customer()
    {
        var salaSeat = SalaSeat.Create(SeatId.Generate(), new SeatNumber(1));
        var customerId = CustomerId.Generate();
        var sut = createSut([salaSeat]);

        var actual = sut.ReserveSeat(customerId, salaSeat.Id);
        
        Assert.Equal(customerId, actual.AssignedTo);
    }
    
    [Fact]
    public void reserve_seat_should_throw_when_seat_is_busy()
    {
        var salaSeat = SalaSeat.Create(SeatId.Generate(), new SeatNumber(1));
        var customerId = CustomerId.Generate();
        var sut = createSut([salaSeat]);
        sut.ReserveSeat(customerId, salaSeat.Id);

        Assert.Throws<SeatIsBusyException>(() => sut.ReserveSeat(customerId, salaSeat.Id));
    }
    
    private static Session createSut(List<SalaSeat> seats)
    {
        return Session.Create(
            SessionId.Generate(), 
            MovieId.Generate(), 
            SalaId.Generate(),
            CDateTime.Now, 
            seats);
    }
}