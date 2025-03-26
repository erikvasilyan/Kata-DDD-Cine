namespace Domain.seat;

public record AvailableSeatDto(SeatId SeatId, SeatNumber SeatNumber) : SeatDto;