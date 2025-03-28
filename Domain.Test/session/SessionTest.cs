using Domain.common;
using Domain.movie;
using Domain.sala;
using Domain.seat;
using Domain.session;

namespace Domain.Test.session;

public class SessionTest
{
    [Fact]
    public void start_booking_should_create_reservations_for_all_seats()
    {
        var sut = CreateSut();
        var firstSeat = SeatId.Generate();
        var secondSeat = SeatId.Generate();
        var seats = new List<SeatId> { firstSeat, secondSeat };
        var expected = "";
        
        var actual = sut.StartBooking(seats);
        
        Assert.Matches(expected, actual.ToString());
    }
    
    private static Session CreateSut() 
        => Session.Create(SessionId.Generate(), MovieId.Generate(), SalaId.Generate(), CDateTime.Now);
}