using Domain.customer;

namespace Domain.seat;

public class ReservedSeat : Seat {
    public CustomerId AssignedTo { get; init; }

    private ReservedSeat(SeatId id, SeatNumber number, CustomerId assignedTo) : base(id, number) {
        AssignedTo = assignedTo;
    }
    
    public static ReservedSeat Create(SeatId id, SeatNumber number, CustomerId assignedTo) 
        => new ReservedSeat(id, number, assignedTo);

    public override ReservedSeatDto ToDto() => new(Id, Number, AssignedTo);
}