using Domain.customer;
using Domain.repositories;
using Domain.sala;
using Domain.session;

namespace Application.services;

public class ReservationService
{
    private SalaRepository salaRepository;
    private CustomerRepository customerRepository;
    private SessionRepository sessionRepository;
    
    public ReservationResponseDto reserveSeatForSession(string requestCustomerId, string requestSessionId, int requestSeatNumber)
    {
        var customerId = CustomerId.fromString(requestCustomerId);
        var sessionId = SessionId.fromString(requestSessionId);
        var seatNumber = new SeatNumber(requestSeatNumber);
        
        var customer = customerRepository.GetById(customerId);
        var session = sessionRepository.GetById(sessionId);
        var sala = salaRepository.GetById(session.SalaId);
        
        var seat = sala.getSeat(seatNumber);
        var reservedSeat = session.ReserveSeat(customer.Id, seat.Id);
        
        return new ReservationResponseDto(customer.Id.ToString(), session.Id.ToString(), seat.Number.ToInt());
    }
}