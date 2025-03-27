using Domain.customer;

namespace Domain.seat;

public class AvailableSeat : ReservationSeat
{
    private AvailableSeat(SeatId id) : base(id) { }
    
    public static AvailableSeat Create(SeatId id) => new(id);

    public ReservedSeat Reserve(CustomerId customerId) => ReservedSeat.Create(Id, customerId);

    public override AvailableSeatDto ToDto() => new(Id);
}