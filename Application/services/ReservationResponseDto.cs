namespace Application.services;

public record ReservationResponseDto(string customerId, string sessionId, int seatNumber);