using Domain.customer;

namespace Domain.seat;

public class AvailableSeat : Seat
{
    private AvailableSeat(SeatId id, SeatNumber number) : base(id, number) { }
    
    public static AvailableSeat Create(SeatId id, SeatNumber number) => new(id, number);

    public ReservedSeat Reserve(CustomerId customerId)
        => ReservedSeat.Create(Id, Number, customerId);

    public override AvailableSeatDto ToDto() => new(Id, Number);
}