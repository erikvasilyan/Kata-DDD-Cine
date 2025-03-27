using Domain.customer;

namespace Domain.seat;

public class ReservedSeat : ReservationSeat {
    public CustomerId AssignedTo { get; init; }

    private ReservedSeat(SeatId id, CustomerId assignedTo) : base(id) {
        AssignedTo = assignedTo;
    }
    
    public static ReservedSeat Create(SeatId id, CustomerId assignedTo) 
        => new(id, assignedTo);

    public override ReservedSeatDto ToDto() => new(Id, AssignedTo);
}