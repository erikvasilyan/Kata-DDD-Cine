using Domain.reservation;
using Domain.seat;

namespace Domain.repositories;

public interface SeatReservationRepository : BaseRepository<SeatReservation, SeatReservationId>
{
    Task<SeatReservation> GetBySeatId(SeatId seatId);
}