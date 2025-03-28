using Domain.exceptions;
using Domain.sala;
using Domain.seat;

namespace Domain.Test.sala;

public class SalaTest
{
    [Fact] 
    public void create_sala_should_create_sala_with_given_seats_count()
    {
        const int seatsCount = 3;
        var sut = CreateSut(seatsCount);

        var actual = sut.Seats;
        
        Assert.Equal(seatsCount, actual.Count);
    }
    
    [Fact]
    public void get_seat_should_return_seat_with_given_number()
    {
        const int seatsCount = 3;
        var seatNumber = new SeatNumber(3);
        var sut = CreateSut(seatsCount);

        var actual = sut.getSeat(seatNumber);
        
        Assert.Equal(seatNumber, actual.Number);
    }
    
    [Fact]
    public void get_seat_should_throw_when_seat_not_found()
    {
        const int seatsCount = 3;
        var seatNumber = new SeatNumber(4);
        var sut = CreateSut(seatsCount);

        Assert.Throws<SeatNotFoundException>(() => sut.getSeat(seatNumber));
    }
    
    [Fact]
    public void get_all_seats_ids_should_return_all_seats_ids()
    {
        const int seatsCount = 3;
        var sut = CreateSut(seatsCount);

        var actual = sut.GetAllSeatsIds();
        
        Assert.Equal(seatsCount, actual.Count);
    }
    
    private static Sala CreateSut(int seatsCount)
        => Sala.Create(SalaId.Generate(), seatsCount);
}